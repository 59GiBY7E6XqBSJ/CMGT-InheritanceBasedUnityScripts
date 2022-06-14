using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Trigger
{
    [SerializeField] string sceneName;
    protected private bool hasBeenChanged = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEvent(int eventId = 0)
    {
        base.OnTriggerEvent(eventId);

        if (!hasBeenChanged)
        {
            StartCoroutine(LoadAsyncScene());
            hasBeenChanged = true;
        }
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
