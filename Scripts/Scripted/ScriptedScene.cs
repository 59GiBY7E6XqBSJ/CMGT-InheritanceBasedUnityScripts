using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ScriptedScene : MonoBehaviour
{
    enum CurrentScene
    {
        None = 0,
        Prologue = 1,
        Scene1 = 2
    };
    [SerializeField] CurrentScene currentScene = CurrentScene.Prologue;

    [Header("Custom Callbacks")]
    [SerializeField] EventTrigger.TriggerEvent customCallback;

    // Start is called before the first frame update
    public virtual void Start()
    {
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        customCallback.Invoke(eventData);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
