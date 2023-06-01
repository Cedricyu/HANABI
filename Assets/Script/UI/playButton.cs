using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button mybutton_;
    public AudioSource myAudioSource;
    public AudioClip successSoundEffect;
    public AudioClip failSoundEffect;

    void Start()
    {
        mybutton_ = GetComponent<Button>();
        myAudioSource = GetComponent<AudioSource>();
    }
    public void playSoundEffect(bool b)
    {
        if (b)
        {
            myAudioSource.PlayOneShot(successSoundEffect);
        }
        else
        {
            myAudioSource.PlayOneShot(failSoundEffect);
        }

    }
}
