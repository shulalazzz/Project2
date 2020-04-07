using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topper : MonoBehaviour
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
        if (collision.transform.tag == "Ball2") {
            multi_game_manage_player2.instance.game_over();
        }
    }
}
