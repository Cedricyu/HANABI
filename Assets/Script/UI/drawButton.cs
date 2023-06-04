using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button mybutton_;
    public AudioSource myAudioSource;
    public AudioClip soundEffect;
    void Start()
    {
        mybutton_ = GetComponent<Button>();
        myAudioSource = GetComponent<AudioSource>();
        soundEffect = GetComponent<AudioSource>().clip;
    }
    public void playSoundEffect()
    {
        myAudioSource.PlayOneShot(soundEffect);
    }
}
