using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public bool is_test = false;

    public void PlaySingle()
    {
        SceneManager.LoadScene("level1");
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
    public void Test()
    {
        Debug.Log("test");
        is_test = true;
    }
    public void Original()
    {
        Debug.Log("original");
        is_test = false;
    }

    private void Awake()
    {
        instance = this;
    }
}
