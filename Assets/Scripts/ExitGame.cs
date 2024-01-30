using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{

    void Start()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
