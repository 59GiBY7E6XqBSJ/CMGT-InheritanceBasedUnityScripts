using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioFadeScript
{
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime, float FadeTo = 0)
    {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > FadeTo)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }

        if (FadeTo == 0)
        {
            audioSource.Stop();

            audioSource.volume = startVolume;
        }  
    }
 
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float FadeTo = 1.0f, float startVolume = 0.2f, bool renew = true)
    {
        //float startVolume = 0.2f;
        if (renew)
        {
            audioSource.volume = 0;
            audioSource.Play();
        }
        

        while (audioSource.volume < FadeTo)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }

        if (renew)
        {
            audioSource.volume = FadeTo;
        }
    }
}