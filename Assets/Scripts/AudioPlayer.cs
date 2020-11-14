using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip takeStell;
    [SerializeField] 
    int volumeTakeStell;

    [SerializeField]
    bool play1 = false; //for testing 

    public AudioClip dropStell;
    [SerializeField]
    int volumeDropStell;
    [SerializeField]
    bool play2 = false;//for testing 
    
    public AudioClip DropPlayerSound;
    [SerializeField]
    int volumeDropPlayerSound;
    [SerializeField]
    bool play3 = false;//for testing 

    public AudioClip validationClip;
    [SerializeField]
    int volumeValidation;
    [SerializeField]
    bool play4 = false;//for testing 

    public AudioClip themeClip;
    [SerializeField] float volume;


    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        audioSource.Play();

    }
    private void FixedUpdate()
    {
        if (play1)
        {
            PlayTakeStellSound();
            play1 = false;
        }
        if (play2)
        {
            PlayDropeStellSound();
            play2 = false;
        }
        if (play3)
        {
            PlayDropPlayer();
            play3 = false;
        }
        if (play4)
        {
            PlayValidationSound();
            play4 = false;
        }
        
    }

    void PlayTakeStellSound()
    {
        audioSource.PlayOneShot(takeStell ,volumeTakeStell) ;
    }

    void PlayDropeStellSound()
    {
        audioSource.PlayOneShot(dropStell,volumeDropStell);
    }

    void PlayValidationSound()
    {
        audioSource.PlayOneShot(validationClip, volumeValidation);
    }

    void PlayDropPlayer()
    {
        audioSource.PlayOneShot(DropPlayerSound, volumeDropPlayerSound);
    }   
    // Update is called once per frame
    void Update()
    {
        
    }
}
