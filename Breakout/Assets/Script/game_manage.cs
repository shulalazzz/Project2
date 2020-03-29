using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manage : MonoBehaviour
{
    public static game_manage instance;
    public bool isPlaying = false;
     void Awake()
    {
        instance = this;
    }
    public void Reset_ball()
    {
        isPlaying = false;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
