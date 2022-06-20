using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Tooltip : MonoBehaviour
{
    private protected SceneContainer sceneContainer;
    private protected Player player;
    
    // Is the tooltip active
    private protected bool isTooltipActive = false;

    // Has player interacted with the tooltip
    private protected bool interactedWith = false;

    // Layermask for the tooltip interactions
    private protected int layerMask;

    [Header("Activation")]
    [SerializeField] public float distance = 10.0f;
    [SerializeField] public bool isVehicleTooltip = false;
    
    [SerializeField] Camera camera;
    [SerializeField] GameObject tooltip;
    
    enum CentreMode
    {
       Screen = 0, 
       Mouse = 1,
       Object = 2
    };
    [SerializeField]
    CentreMode centreMode = CentreMode.Screen;

    [SerializeField]
    EventTrigger.TriggerEvent pressInteractCallback;
    [SerializeField] bool disableOnInteract = true;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneContainer = FindObjectOfType<SceneContainer>();

        if (sceneContainer != null)
        {
            player = sceneContainer.player;
            camera = sceneContainer.camera;
            Debug.Log("[Tooltip] SceneContainer Aquired");
        }

        //tooltip = GameObject.Find(tooltipName);

        tooltip.active = false;

        layerMask = LayerMask.GetMask("Tooltip");
    }

    // Update is called once per frame
    void Update()
    {
        if (disableOnInteract && interactedWith)
            return;

        if (isTooltipActive)
        {
            OnTooltipShow();
        }

        if (camera != null)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, layerMask) && hit.collider.gameObject == gameObject)
            {
                //Check if hit.collider.gameObject has a tooltip script
                Tooltip tooltipScript = hit.collider.gameObject.GetComponent<Tooltip>();
                if (tooltipScript != null)
                {
                    if (!player.isOnVehicle)
                        ShowTooltip(hit.collider.gameObject); 
                    else if (player.isOnVehicle && tooltipScript.isVehicleTooltip)
                        ShowTooltip(hit.collider.gameObject);   
                }
                else 
                {
                    if (!player.isOnVehicle)
                        ShowTooltip(hit.collider.gameObject); 
                }
            }
            else
            {        
                tooltip.active = false;
                isTooltipActive = false;
            }
        }
        else 
        {
            tooltip.active = false;
            isTooltipActive = false;
            Debug.Log("<color=red>Error: </color>Camera is not set in the Tooltip script or SceneContainer is not present in the scene.");
        }
    }

    public virtual void ShowTooltip(GameObject hitObject)
    {
        tooltip.active = true;
        isTooltipActive = true;
        if (centreMode == CentreMode.Screen)
        {
            tooltip.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        }
        else if (centreMode == CentreMode.Mouse)
        {
            tooltip.transform.position = Input.mousePosition;
        }
        else if (centreMode == CentreMode.Object)
        {
            tooltip.transform.position = hitObject.transform.position;
        }
    }

    public virtual void HideTooltip()
    {
        tooltip.active = false;
        isTooltipActive = false;
    }

    public virtual void OnTooltipShow()
    {
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (pressInteractCallback != null)
            {
                pressInteractCallback.Invoke(eventData);
                HideTooltip();
                interactedWith = true;
                if (disableOnInteract)
                    gameObject.SetActive(false);
            }
        }
    }
}
