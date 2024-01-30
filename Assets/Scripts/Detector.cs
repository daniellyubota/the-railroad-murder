using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{
    public GameObject[] cluesUnlocked;
    private bool allActive = true;
    public string[] correctClue;
    public GameObject inventory;
    public GameObject correct;
    public GameObject wrong;
    public Button submitButton;
    void Update()
    {
        CheckIfAllActive();

    }
    private void CheckIfAllActive()
    {
        allActive = true;
        for (int i = 0; i < cluesUnlocked.Length; i++)
        {
            if (!cluesUnlocked[i].activeSelf)
            {
                allActive = false;
                break;
            }
        }

        if (allActive && !Globals.isDialoging)
        {
            gameObject.GetComponent<Dialogue>().StartDialogue();
            submitButton.GetComponent<Button>().onClick.RemoveAllListeners();
            submitButton.GetComponent<Button>().onClick.AddListener(this.gameObject.GetComponent<Detector>().GetCorrectClue);
            gameObject.GetComponent<Detector>().enabled = false;
        }
    }
    public void GetCorrectClue()
    {
        foreach (string clue in correctClue)
        {
            if (clue == inventory.GetComponent<Inventory>().ActiveObject())
            {
                inventory.SetActive(false);
                submitButton.gameObject.SetActive(false);
                correct.GetComponent<Dialogue>().StartDialogue();
                break;
                
            }
            else if (inventory.GetComponent<Inventory>().ActiveObject() != null && clue == correctClue[correctClue.Length-1])
            {
                inventory.SetActive(false);
                wrong.GetComponent<Dialogue>().StartDialogue();
                break;
            }
        }
    }

}