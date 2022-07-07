using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    // Start is called before the first frame update
    public AudioClip Button;
    public AudioClip delete;
    public AudioClip result;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ButtonSound()
    {
        audioSource.PlayOneShot(Button);
    }
    public void deleteSound()
    {
        audioSource.PlayOneShot(delete);
    }
    public void resultSound()
    {
        audioSource.PlayOneShot(result);
    }


}
