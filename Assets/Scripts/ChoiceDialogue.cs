using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceDialogue : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]
    private GameObject[] suspects;
    
    void OnEnable()
    {
        Globals.isDialoging = true;
        Player = GameObject.Find("Player");
        Player.GetComponent<Player>().enabled = false;

    }
    public void No()
    {
        Globals.isDialoging = false;
        
        
        Player.GetComponent<Player>().enabled = true;
        foreach (GameObject suspect in suspects)
        {
            suspect.transform.parent.gameObject.SetActive(false);
        }
        gameObject.transform.parent.gameObject.SetActive(false);

    }
    public void Yes()
    {
        
        Player.GetComponent<Player>().enabled = true;
        if (suspects[0].transform.parent.gameObject.activeSelf)
        {
            Player.GetComponent<Player>().enabled = true;
            
            suspects[0].GetComponent<Dialogue>().StartDialogue();
            gameObject.transform.parent.gameObject.SetActive(false);

        }
        else if (suspects[1].transform.parent.gameObject.activeSelf)
        {
            Player.GetComponent<Player>().enabled = true;
            
            suspects[1].GetComponent<Dialogue>().StartDialogue();
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if (suspects[2].transform.parent.gameObject.activeSelf)
        {
            Player.GetComponent<Player>().enabled = true;
            
            suspects[2].GetComponent<Dialogue>().StartDialogue();
            gameObject.transform.parent.gameObject.SetActive(false);
        }

    }

}
