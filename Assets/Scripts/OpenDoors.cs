using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject[] doors;
    void Start()
    {
        foreach(GameObject door in doors)
        {
            if(!door.GetComponent<DoorOpenClose>().canOpen)
            {
                door.GetComponent<DoorOpenClose>().canOpen = true;
            }
            else if(door.GetComponent<DoorOpenClose>().canOpen)
            {
                door.GetComponent<DoorOpenClose>().canOpen = false;
            }
        }
        this.gameObject.SetActive(false);
    }
}
