using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    public bool Confirm = true;
    public void LoadLevel()
    {
        if (Confirm)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}