using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    AudioClip onMouseOverSound;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    int volumeMouseOverSound;
    // Start is called before the first frame update

    private void OnMouseOver()
    {
        audioSource.PlayOneShot(onMouseOverSound, volumeMouseOverSound);
    }
}
