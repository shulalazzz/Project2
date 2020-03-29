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
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
