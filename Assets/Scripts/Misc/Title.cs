using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
