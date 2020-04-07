using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class multi_game_manage_player1 : MonoBehaviour
{
    public static multi_game_manage_player1 instance;
    public bool isPlaying = false;
    public bool is_passed = false;
    public GameObject start_panel;
    public GameObject win_panel;
    public Text life_text;
    public int life_num;
    public bool lose = false;

    private void Awake()
    {
        instance = this;
    }

    public void game_over()
    {
        if (life_num == 0)
        {
            lose = true;
            multi_game_manage_player2.instance.check_win();
        }
        else
        {
            isPlaying = false;
            life_num -= 1;
            life_text.text = "Bottom player lives: " + life_num;
        }
    }

    public void check_win()
    {
        break_brick_player1[] all_break = GameObject.FindObjectsOfType<break_brick_player1>();
        Debug.Log("player1 brick number is"+all_break.Length);
        if ((all_break.Length == 1) || multi_game_manage_player2.instance.lose)
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
            SceneManager.LoadScene ("multi_mode");
        }
    }
}
