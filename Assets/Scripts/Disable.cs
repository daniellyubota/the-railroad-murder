using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public GameObject sprite;
    private void Start()
    {
        sprite.SetActive(false);
    }
}
