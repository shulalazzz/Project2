using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlaySingle()
    {
        SceneManager.LoadScene("single_mode");
    }
    public void PlayMulti()
    {
        SceneManager.LoadScene("multi_mode");
    }
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
