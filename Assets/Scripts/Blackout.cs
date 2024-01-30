using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackout : MonoBehaviour
{
    public GameObject GlobalLight2D;
    public GameObject wall1;
    public GameObject wall2;

    void Start()
    {
        GlobalLight2D.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = new Color(174 / 255f, 173 / 255f, 253 / 255f, 255 / 255f);
        GlobalLight2D.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 0.12f;
        wall1.GetComponent<SpriteRenderer>().color = new Color(13 / 255f, 11 / 255f, 14 / 255f, 255 / 255f);
        wall2.GetComponent<SpriteRenderer>().color = new Color(13 / 255f, 11 / 255f, 14 / 255f, 255 / 255f);
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
