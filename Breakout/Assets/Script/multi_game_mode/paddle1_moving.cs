using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle1_moving : MonoBehaviour
{
    public float speed;
    public float x_min;
    public float x_max;

    void Update()
    {
        if (multi_game_manage_player1.instance.is_passed || multi_game_manage_player2.instance.is_passed) {
            return;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, x_min, x_max);
            transform.position = pos;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, x_min, x_max);
            transform.position = pos;
        }
    }
}
