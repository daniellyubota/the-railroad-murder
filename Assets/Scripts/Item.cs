using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private bool isTouching = false;
    public GameObject dialogueObject;
    private Dialogue[] dialogueScript;
    public bool canTrigger = true;
    private Texture2D cursorTexture;
    private Texture2D cursorTexture2;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private GameObject GameManager;

    public void Start()
    {
        dialogueScript = dialogueObject.GetComponents<Dialogue>();
        GameManager = GameObject.Find("GameManager");
        cursorTexture = GameManager.GetComponent<GameManager>().texture;
        cursorTexture2 = GameManager.GetComponent<GameManager>().texture2;

    }
    private void OnMouseEnter()
    {
        if (!Globals.isDialoging && isTouching)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorTexture2, hotSpot, cursorMode);
    }
    private void OnMouseDown()
    {
        dialogueScript = dialogueObject.GetComponents<Dialogue>();
        if (isTouching)
        {
            if (dialogueScript != null)
            {
                foreach (Dialogue script in dialogueScript)
                {
                    if (script.enabled && Globals.isDialoging == false && Globals.isPaused == false)
                    {
                        if (transform.parent.tag == "NPC")
                        {
                            if (GameObject.Find("Player").transform.position.x < GetComponentInParent<Transform>().position.x)
                            {
                                GetComponentInParent<SpriteRenderer>().flipX = true;
                            }
                            else
                            {
                                GetComponentInParent<SpriteRenderer>().flipX = false;
                            }
                        }
                        script.StartDialogue();
                    }
                }
            }
        }
        if (!isTouching)
        {
            
        }

    }
    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "ClickRange")
        {
            isTouching = true;
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "ClickRange")
        {
            isTouching = false;
        }
    }

}
