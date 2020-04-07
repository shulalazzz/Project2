using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball1 : MonoBehaviour
{
    public Rigidbody rb_ball1;
    private float radius;
    public float speed;
    public Transform paddle1;
    private bool hacking = false;

    void Start()
    {
        rb_ball1 = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((!multi_game_manage_player1.instance.isPlaying && multi_game_manage_player1.instance.is_passed) || (!multi_game_manage_player2.instance.isPlaying && multi_game_manage_player2.instance.is_passed)) {
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle1.transform.position.x;
            pos.y = paddle1.transform.position.y + radius;
            transform.position = pos;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (hacking)
            {
                hacking = false;
                Vector3 speed_normalized = new Vector3(1f, 1f, 0).normalized;
                rb_ball1.velocity = speed_normalized * speed;
            }
            else
            {
                hacking = true;
                Vector3 hack_normalized = new Vector3(1f, 1f, 0).normalized;
                rb_ball1.velocity = hack_normalized * 60;
            }
        }
        if (hacking)
        {
            Vector3 pos = transform.position;
            pos.x = paddle1.transform.position.x;
            transform.position = pos;
        }

        if (Input.GetMouseButtonDown(0) && !multi_game_manage_player1.instance.isPlaying)
        {
            multi_game_manage_player1.instance.isPlaying = true;
            multi_game_manage_player1.instance.start_panel.SetActive(false);
            Vector3 speed_normalized = new Vector3(1f, 1f, 0).normalized;
            rb_ball1.velocity = speed_normalized * speed;
        }

        if (!multi_game_manage_player1.instance.isPlaying && !multi_game_manage_player1.instance.is_passed)
        {
            // multi_game_manage_player1.instance.start_panel.SetActive(true);
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle1.transform.position.x;
            pos.y = paddle1.transform.position.y + radius;
            transform.position = pos;
        }
    }
}
