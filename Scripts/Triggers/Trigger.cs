using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    enum TriggerMode
    {
       Trigger = 0, 
       Animator = 1
    };
    [SerializeField] TriggerMode triggerMode = TriggerMode.Trigger;

    [Header("Animator")]
    [SerializeField] public Animator animator;
    [SerializeField] string animatorTrigger = "";

    [Header("Custom Callbacks")]
    [SerializeField] EventTrigger.TriggerEvent customCallback;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (triggerMode == TriggerMode.Animator && animator != null)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(animatorTrigger))
            {
                OnTriggerEvent((int)triggerMode);
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (triggerMode == TriggerMode.Trigger)
        {
            OnTriggerEvent((int)triggerMode);
        }
    }

    public virtual void OnTriggerEvent(int eventId = 0)
    {
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        customCallback.Invoke(eventData);
    }
}
