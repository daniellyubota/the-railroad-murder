using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pictures;

    [SerializeField]
    private TMP_Text description;

    private void OnEnable()
    {
        DisablePics();
    }
    public void DisablePics()
    {
        foreach (GameObject picture in pictures)
        {
            picture.SetActive(false);
            description.text = "";
        }
    }
    public string ActiveObject()
    {
            foreach (GameObject picture in pictures)
            {
                if (picture.activeSelf)
                {
                    return picture.name;
                }
            }
        return null;
    }
}
