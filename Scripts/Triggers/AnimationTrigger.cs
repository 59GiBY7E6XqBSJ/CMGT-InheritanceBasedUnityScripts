using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class AnimationTrigger : MonoBehaviour
{
    enum TriggerMode
    {
       Bool = 0
    };
    [SerializeField]
    TriggerMode triggerMode = TriggerMode.Bool;

    [SerializeField]
    string boolName = "";

    [SerializeField]
    EventTrigger.TriggerEvent customCallback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
       
    }

    public virtual void OnTriggerEvent(int eventId = 0)
    {
        
    }
}
