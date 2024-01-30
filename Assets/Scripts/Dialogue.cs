using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public TMP_Text dialogueText;
    public List<string> dialogues;
    public float writingSpeed = 0.01f;
    private int index;
    private int charIndex;
    private bool started;
    private bool waitForNext;
    private GameObject Player;

    public GameObject itemCollect;

    public bool hasMoreDialogue;

    public bool deleteObject = true;

    private string currentDialogue;

    private void Awake()
    {

        ToggleWindow(false);
        Player = GameObject.Find("Player");

    }
    private void OnEnable()
    {
        Player = GameObject.Find("Player");
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void StartDialogue()
    {
        Globals.isDialoging = true;
        Player.GetComponent<Player>().enabled = false;
        if (Player.GetComponentInChildren<Animator>())
        {
            Player.GetComponentInChildren<Animator>().SetFloat("HorizontalSpeed", 0);
        }

        if (started)
            return;

        started = true;
        ToggleWindow(true);
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }

    public void EndDialogue()
    {
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        ToggleWindow(false);
        Player.GetComponent<Player>().enabled = true;
        if (!hasMoreDialogue)
        {
            Globals.dialogueNum = 0;
            Globals.isDialoging = false;
        }
        if (itemCollect != null)
        {
            if (itemCollect.activeSelf == false)
            {
                itemCollect.SetActive(true);
                if (deleteObject)
                {
                    itemCollect = null;
                }
            }
            else if (itemCollect.activeSelf == true)
            {
                itemCollect.SetActive(false);
                if (deleteObject)
                {
                    itemCollect = null;
                }
            }
        }
        if (hasMoreDialogue)
        {
            Globals.dialogueNum += 1;
            Dialogue[] dialogueScripts = GetComponents<Dialogue>();
            dialogueScripts[Globals.dialogueNum].enabled = true;
            dialogueScripts[Globals.dialogueNum].StartDialogue();
            dialogueScripts[Globals.dialogueNum - 1].enabled = false;

        }
        
    }

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);
        currentDialogue = dialogues[index];
        if (charIndex < currentDialogue.Length)
        {
            dialogueText.text += currentDialogue[charIndex];
        }
        charIndex++;


        if (charIndex < currentDialogue.Length)
        {
            
            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
        }
        
    }

    private void Update()
    {
        
        if (!started)
            return;
        if (!waitForNext && Input.GetKeyDown(KeyCode.Mouse0) && charIndex != 0)
        {
            charIndex = currentDialogue.Length;
            dialogueText.text = currentDialogue;
        }
        if (waitForNext && Input.GetKeyDown(KeyCode.Mouse0))
        {
            waitForNext = false;
            index++;
            if (index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                EndDialogue();
            }
        }
    }

}
