using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject[] PlayerSprite;


    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject inventoryMenu;

    public Texture2D texture;
    public Texture2D texture2;
    private bool timeScale = false;

    private bool isPaused = false;
    private bool isInventory = false;
    private void Start()
    {
        
        GetComponent<Dialogue>().StartDialogue();

    }
    void Update()
    {
        
        if(pauseMenu.activeInHierarchy || inventoryMenu.activeInHierarchy)
        {
            foreach (GameObject sprite in PlayerSprite)
            {
                sprite.SetActive(false);
            }

        }
        else
        {
            foreach (GameObject sprite in PlayerSprite)
            {
                sprite.SetActive(true);
            }
        }
        if (!Globals.isDialoging)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }

            if (Input.GetKeyDown(KeyCode.I) && !inventoryMenu.activeSelf && !pauseMenu.activeSelf && !isPaused && !isInventory)
            {
                foreach (GameObject sprite in PlayerSprite)
                {
                    sprite.SetActive(false);
                }
                Player.GetComponent<Player>().enabled = false;
                inventoryMenu.SetActive(true);
                isInventory = true;
                Globals.isPaused = true;
                inventoryMenu.GetComponent<AudioSource>().Play();
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryMenu.activeSelf && !pauseMenu.activeSelf && !isPaused && isInventory)
            {
                Player.GetComponent<Player>().enabled = true;
                inventoryMenu.SetActive(false);
                isInventory = false;
                Globals.isPaused = false;
                foreach (GameObject sprite in PlayerSprite)
                {
                    sprite.SetActive(true);
                }
            }
        }

       
    }
    public void Pause()
    {
        if (!pauseMenu.activeSelf && !inventoryMenu.activeSelf && !isPaused && !isInventory)
        {
            foreach (GameObject sprite in PlayerSprite)
            {
                sprite.SetActive(false);
            }
            Player.GetComponent<Player>().enabled = false;
            pauseMenu.SetActive(true);
            isPaused = true;
            Globals.isPaused = true;
            pauseMenu.GetComponent<AudioSource>().Play();
        }
        else if (pauseMenu.activeSelf && !inventoryMenu.activeSelf && isPaused && !isInventory)
        {

            Player.GetComponent<Player>().enabled = true;
            pauseMenu.SetActive(false);
            isPaused = false;
            Globals.isPaused = false;
            foreach (GameObject sprite in PlayerSprite)
            {
                sprite.SetActive(true);
            }
        }
    }
}


public static class Globals
{
    public static int dialogueNum = 0;
    public static bool isDialoging = false;
    public static bool isPaused = false;
    
}
