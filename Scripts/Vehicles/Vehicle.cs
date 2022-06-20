using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private protected SceneContainer sceneContainer;
    
    [Header("Scripts")]
    [SerializeField] public Player player;

    [Header("Camera")]
    [SerializeField] public Camera playerCamera;
    [SerializeField] public Camera vehicleCamera;

    [Header("Vehicle")]
    [SerializeField] public GameObject attachPoint;
    [SerializeField] public GameObject getOnTooltip;
    [SerializeField] public GameObject getOffTooltip;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        sceneContainer = FindObjectOfType<SceneContainer>();

        if (sceneContainer != null)
        {
            player = sceneContainer.player;
            playerCamera = sceneContainer.camera;
            Debug.Log("[Vehicle] SceneContainer Aquired");
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
    }

    public virtual void GetOnVehicle()
    {
        player.canMove = false;

        player.isOnVehicle = true;
        player.footsteps.isOnSurface = false;
		player.footsteps.StopAllSounds();
        getOffTooltip.SetActive(true);
        getOnTooltip.SetActive(false);
    }

    public virtual void GetOffVehicle()
    {
        player.canMove = true;

        player.isOnVehicle = false;
        player.footsteps.isOnSurface = true;
        getOffTooltip.SetActive(false);
        getOnTooltip.SetActive(true);
    }
}
