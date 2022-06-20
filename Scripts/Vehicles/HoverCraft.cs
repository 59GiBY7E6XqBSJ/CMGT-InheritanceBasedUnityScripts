using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCraft : Vehicle
{
    protected private Rigidbody rb;

    private protected bool isPlayerOn = false;

    private protected Quaternion oldRotation;

    [Header("Movement")]
	[SerializeField] bool invertControls = false;
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;

    [Header("Light")]
    [SerializeField] GameObject light;

    Vector3 rotationLeft;
    Vector3 rotationRight;
    Vector3 rotation;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (isPlayerOn)
        {
            Vector3 velocity = rb.velocity;

            if (Input.GetKey(KeyCode.W))
            {
                if (!invertControls)
                    velocity += gameObject.transform.forward * -movementSpeed;
                else
                    velocity += gameObject.transform.forward * movementSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (!invertControls)
                    velocity += gameObject.transform.forward * movementSpeed;
                else
                    velocity += gameObject.transform.forward * -movementSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                //if (!invertControls)
                    rotation = new Vector3(0, -rotationSpeed, 0);
                //else
                //    rotation = new Vector3(0, rotationSpeed, 0);

                rb.AddTorque(rotation, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //if (!invertControls)
                    rotation = new Vector3(0, rotationSpeed, 0);
                //else
                //    rotation = new Vector3(0, -rotationSpeed, 0);

                rb.AddTorque(rotation, ForceMode.Acceleration);
            } 

            rb.velocity = velocity;
        }
    }

    public override void GetOnVehicle()
    {
        base.GetOnVehicle();

        isPlayerOn = true;

        if (attachPoint != null)
        {
            // Disable players collider
            player.GetComponent<Collider>().enabled = false;

            // Save the old rotation
            oldRotation = player.transform.rotation;

            player.transform.parent = attachPoint.transform;
            player.transform.localPosition = Vector3.zero;
            player.transform.localRotation = Quaternion.identity;

            light.SetActive(true);
        }
    }

    public override void GetOffVehicle()
    {
        base.GetOffVehicle();

        isPlayerOn = false;

        if (attachPoint != null)
        {
            // Enable players collider
            player.GetComponent<Collider>().enabled = true;

            player.transform.parent = null;
            player.transform.position = attachPoint.transform.position;

            player.transform.rotation = oldRotation;
            //player.transform.rotation = Quaternion.identity;
            //attachPoint.transform.rotation;

            light.SetActive(false);
        }
    }
}
