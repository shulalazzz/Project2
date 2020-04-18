using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle2_moving : MonoBehaviour
{
    public float speed;
    public float x_min;
    public float x_max;

    void Update()
    {
        if (multi_game_manage_player2.instance.is_passed || multi_game_manage_player1.instance.is_passed || multi_game_manage_player2.instance.lose) {
            return;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, x_min, x_max);
            transform.position = pos;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, x_min, x_max);
            transform.position = pos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball2")
        {
            if (multi_game_manage_player2.instance.is_magnetic)
            {
                multi_game_manage_player2.instance.is_magnetic = false;
                collision.gameObject.GetComponent<ball2>().apply_magnetic = true;
            }
        }
    }
}
