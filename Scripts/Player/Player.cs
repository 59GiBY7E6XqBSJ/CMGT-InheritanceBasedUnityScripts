using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public bool canMove = true;
    [SerializeField] public bool canRotate = true;
    [SerializeField] [Range(0.01f, 100)] public float movementSpeed = 1.0f;
    [SerializeField] [Range(0.0f, 1.0f)] public float movementLerp = 0.5f;
    [SerializeField] [Range(0.01f, 10.0f)] public float rotationSpeed = 3.0f;

    [Header("Scripts")]
    [SerializeField] public PlayerControls playerControls;
    [SerializeField] public MouseRotate mouseRotate;
    [SerializeField] public Footsteps footsteps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
