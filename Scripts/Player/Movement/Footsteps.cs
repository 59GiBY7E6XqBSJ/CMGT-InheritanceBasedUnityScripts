using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private protected bool hasPlayed = false;
    private protected bool isWalking = false;

    [SerializeField] public bool isOnSurface = false;
    [SerializeField] [Range(0, 1)] float delayBetweenSteps = 0.5f;

    [Header("Sounds")]
    [SerializeField] GameObject[] footstepSounds; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnSurface)
        {
            isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
            if (isWalking && !hasPlayed)
            {
                hasPlayed = true;
                StartCoroutine(PlayFootstepSound(delayBetweenSteps));
            }
            else if (!isWalking)
            {
                hasPlayed = false;
                StopAllCoroutines();
            }
        }   
    }

    public void StopAllSounds()
    {
        StopAllCoroutines();
    }

    IEnumerator PlayFootstepSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!isWalking)
            yield break;

        int randomIndex = Random.Range(0, footstepSounds.Length);
        footstepSounds[Random.Range(0, footstepSounds.Length)].GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        footstepSounds[randomIndex].GetComponent<AudioSource>().Play();

        hasPlayed = false;
    }
}
