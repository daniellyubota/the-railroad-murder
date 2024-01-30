using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigation : MonoBehaviour
{
    public GameObject[] doors;
    public bool InvestigationMode;
    void OnEnable()
    {
        if (InvestigationMode)
        {
            foreach (GameObject door in doors)
            {

                door.transform.parent.GetComponentInParent<DoorOpenClose>().canTrigger = false;
                door.transform.parent.GetComponent<Dialogue>().enabled = true;
                door.SetActive(true);

            }
        }
        else if (!InvestigationMode)
        {
            foreach (GameObject door in doors)
            {
                door.transform.parent.GetComponentInParent<DoorOpenClose>().canTrigger = true;
                door.transform.parent.GetComponent<Dialogue>().enabled = false;
                door.SetActive(false);

            }
        }
        gameObject.SetActive(false);
    }

}
