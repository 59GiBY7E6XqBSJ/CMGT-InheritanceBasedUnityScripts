using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Tooltip : MonoBehaviour
{
    private protected bool isTooltipActive = false;

    private protected int layerMask;

    [SerializeField]
    Camera camera;
    [SerializeField]
    GameObject tooltip;

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
    [SerializeField]
    bool disableOnInteract = true;
    private protected bool interactedWith = false;

    // Start is called before the first frame update
    void Start()
    {
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

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f, layerMask) && hit.collider.gameObject == gameObject)
        {
            ShowTooltip(hit.collider.gameObject); 
        }
        else
        {        
            tooltip.active = false;
            isTooltipActive = false;
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
            Debug.Log("F key pressed");

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
