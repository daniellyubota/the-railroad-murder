using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    private void Start()
    {
        audioSource.Play();
    }


}
