using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSuccessAudio : MonoBehaviour
{

    GameObject roomAudio;
    AudioSource roomSceneAudio;
    AudioSource gameSuccessAudio;
    void Start()
    {
        roomAudio = GameObject.Find("RoomAudio");
        roomSceneAudio = roomAudio.GetComponent<AudioSource>();
        gameSuccessAudio = GetComponent<AudioSource>();
        StartCoroutine(FadeMusic(roomSceneAudio, 0.5f, 0));
        StartCoroutine(FadeMusic(gameSuccessAudio, 2, 1));
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
