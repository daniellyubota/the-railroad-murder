using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSquare : MonoBehaviour
{
    [SerializeField]
    private GameObject[] suspects;
    private GameObject Player;
    public bool movePlayer = false;
    public void TurnEverythingOn()
    {
        foreach(GameObject suspect in suspects)
        {
            if (suspect.activeSelf)
            {
                suspect.SetActive(false);
            }
            else if(!suspect.activeSelf)
            {
                suspect.SetActive(true);
            }
        }
    }
    public void TurnSelfOff()
    {
        this.gameObject.SetActive(false);
    }
    public void TalkDialogue()
    {
        GetComponent<Dialogue>().StartDialogue();
    }
    public void MovePlayer()
    {
        if (movePlayer)
        {
            Player = GameObject.Find("Player");
            Player.transform.position = new Vector3(32, Player.transform.position.y, Player.transform.position.z);
        }
        
    }

}
