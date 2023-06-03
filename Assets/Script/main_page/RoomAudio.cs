using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAudio : MonoBehaviour
{
    GameObject startSound;
    AudioSource startSceneAudio;
    AudioSource lobbySceneAudio;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        startSound = GameObject.Find("StartBackGroundSound");
        startSceneAudio = startSound.GetComponent<AudioSource>();
        lobbySceneAudio = GetComponent<AudioSource>();
        StartCoroutine(FadeMusic(startSceneAudio, 2, 0));
        StartCoroutine(FadeMusic(lobbySceneAudio, 5, 1));
    }

    public IEnumerator FadeMusic(AudioSource audio, float duration, float targetVolume)
    {

        float currentTime = 0;
        float start = audio.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
