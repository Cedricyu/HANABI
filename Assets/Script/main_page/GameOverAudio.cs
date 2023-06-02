using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    GameObject roomAudio;
    AudioSource roomSceneAudio;
    AudioSource gameOverAudio;
    void Start()
    {
        roomAudio = GameObject.Find("RoomAudio");
        roomSceneAudio = roomAudio.GetComponent<AudioSource>();
        gameOverAudio = GetComponent<AudioSource>();
        StartCoroutine(FadeMusic(roomSceneAudio, 0.5f, 0));
        StartCoroutine(FadeMusic(gameOverAudio, 2, 1));
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
