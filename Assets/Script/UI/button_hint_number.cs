using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_hint_number : MonoBehaviour
{
    public Button mybutton_;
    public AudioSource myAudioSource;
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        mybutton_ = GetComponent<Button>();
        myAudioSource = GetComponent<AudioSource>();
        soundEffect = GetComponent<AudioSource>().clip;
        //hint_number_control=0;    
    }
    public void playSoundEffect()
    {
        myAudioSource.PlayOneShot(soundEffect);
    }


}
