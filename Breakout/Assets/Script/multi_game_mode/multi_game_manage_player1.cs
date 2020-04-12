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
    public GameObject draw_panel;
    public Text life_text;
    public int life_num;
    public int score;
    public bool lose = false;
    public bool is_magnetic = false;
    public int rest_break;

    private void Awake()
    {
        instance = this;
    }

    public bool IsLastBall()
    {
        ball1[] all_ball = GameObject.FindObjectsOfType<ball1>();
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
            // isPlaying = false;
            lose = true;
            multi_game_manage_player2.instance.check_win();
        }
        else
        {
            isPlaying = false;
            life_num -= 1;
            life_text.text = "lives: " + life_num + "		Score: " + score;
        }
    }

    public void ChangeLife(int num)
    {
        life_num += num;
        life_text.text = "lives: " + life_num + "		Score: " + score;
    }

    public void ChangeScore(int num)
    {
        score += num;
        life_text.text = "lives: " + life_num + "		Score: " + score;
    }

    public void check_win()
    {
        break_brick_player1[] all_break = GameObject.FindObjectsOfType<break_brick_player1>();
        rest_break = all_break.Length;
        Debug.Log("player1 brick number is " + all_break.Length);
        if (all_break.Length == 1)
        {
            is_passed = true;
            win_panel.SetActive(true);
            isPlaying = false;
        }
        else if (multi_game_manage_player2.instance.lose && (score > multi_game_manage_player2.instance.score))
        {
            is_passed = true;
            win_panel.SetActive(true);
            isPlaying = false;
        }
        else if (lose && multi_game_manage_player2.instance.lose)
        {
            if (score > multi_game_manage_player2.instance.score)
            {
                is_passed = true;
                win_panel.SetActive(true);
                isPlaying = false;
            }
            else if (score == multi_game_manage_player2.instance.score)
            {
                is_passed = true;
                draw_panel.SetActive(true);
                isPlaying = false;
            }
            else
            {
                multi_game_manage_player2.instance.check_win();
            }
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
