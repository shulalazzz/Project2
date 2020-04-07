using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi_break_brick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.enabled = false;
        multi_game_manage_player1.instance.check_win();
        multi_game_manage_player2.instance.check_win();
        Destroy(gameObject);
    }
}
