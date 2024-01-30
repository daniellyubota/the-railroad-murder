using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    [SerializeField]
    public bool canOpen;
    [SerializeField]
    private GameObject openDoor;
    [SerializeField]
    private GameObject closedDoor;
    [SerializeField]
    private AudioSource doorCloseSound;
    [SerializeField]
    private AudioSource doorOpenSound;

    public bool canTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTrigger)
        {
            if (collision.gameObject.tag == "ClickRange")
            {
                if (canOpen)
                {
                    openDoor.SetActive(true);
                    closedDoor.SetActive(false);
                    doorOpenSound.Play();
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canTrigger)
        {
            if (collision.gameObject.tag == "ClickRange")
            {
                if (canOpen)
                {
                    openDoor.SetActive(false);
                    closedDoor.SetActive(true);
                    doorCloseSound.Play();
                }
            }
        }
    }

}
