using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public void PlaySound()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }
    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}
