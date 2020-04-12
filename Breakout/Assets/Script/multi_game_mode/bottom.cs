using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottom : MonoBehaviour
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
        if (collision.transform.tag == "Ball1") {
            if (multi_game_manage_player1.instance.IsLastBall())
            {
                multi_game_manage_player1.instance.GameOver();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
