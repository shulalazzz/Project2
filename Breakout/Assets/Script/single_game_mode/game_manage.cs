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
    public bool is_magnetic = false;
    public Text life_text;
    public GameObject start_panel;
    public GameObject win_panel;
    public bool is_passed = false;
    public bool is_extend = false;
    private void Awake()
    {
        instance = this;
    }
    public bool IsLastBall()
    {
        ball[] all_ball = GameObject.FindObjectsOfType<ball>();
        if(all_ball.Length == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GameOver()
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
    public void ChangeLife(int num)
    {
        life_num += num;
        life_text.text = "Lives:" + life_num;

    }

    public void CheckWin()
    {
        break_brick[] all_break = GameObject.FindObjectsOfType<break_brick>();
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
