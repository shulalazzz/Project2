using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_brick_player2 : MonoBehaviour
{   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball2") {
            this.enabled = false;
            multi_game_manage_player2.instance.check_win();
            Destroy(gameObject);
        }
    }
}
