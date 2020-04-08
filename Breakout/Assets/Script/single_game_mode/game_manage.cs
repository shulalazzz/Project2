using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_manage : MonoBehaviour
{
    public static game_manage instance;
    public bool isPlaying = false;
    public int life_num;
    public Text life_text;
    public GameObject start_panel;
    public GameObject win_panel;
    public bool is_passed = false;
    private void Awake()
    {
        instance = this;
    }

    public void game_over()
    {
        if (life_num == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            isPlaying = false;
            life_num -= 1;
            life_text.text = "Lives:" + life_num;
        }
        
    }

    public void check_win()
    {
        break_brick[] all_break = GameObject.FindObjectsOfType<break_brick>();
        Debug.Log("brick number is"+all_break.Length);
        if (all_break.Length == 1)
        {
            is_passed = true;
            win_panel.SetActive(true);
            isPlaying = false;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Q)) {
            SceneManager.LoadScene ("menu");
        }
        if (Input.GetKeyDown (KeyCode.R)) {
            SceneManager.LoadScene ("single_mode");
        }
    }
}
