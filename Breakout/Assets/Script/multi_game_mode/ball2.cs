﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball2 : MonoBehaviour
{
    public Rigidbody rb_ball2;
    private float radius;
    public float speed;
    public Transform paddle2;
    private bool hacking = false;

    void Start()
    {
        rb_ball2 = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((!multi_game_manage_player1.instance.isPlaying && multi_game_manage_player1.instance.is_passed) || (!multi_game_manage_player2.instance.isPlaying && multi_game_manage_player2.instance.is_passed)) {
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle2.transform.position.x;
            pos.y = paddle2.transform.position.y - radius;
            transform.position = pos;
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (hacking)
            {
                hacking = false;
                Vector3 speed_normalized = new Vector3(-1f, -1f, 0).normalized;
                rb_ball2.velocity = speed_normalized * speed;
            }
            else
            {
                hacking = true;
                Vector3 hack_normalized = new Vector3(-1f, -1f, 0).normalized;
                rb_ball2.velocity = hack_normalized * 60;
            }
        }
        if (hacking)
        {
            Vector3 pos = transform.position;
            pos.x = paddle2.transform.position.x;
            transform.position = pos;
        }

        if (Input.GetMouseButtonDown(0) && !multi_game_manage_player2.instance.isPlaying)
        {
            multi_game_manage_player2.instance.isPlaying = true;
            multi_game_manage_player2.instance.start_panel.SetActive(false);
            Vector3 speed_normalized = new Vector3(-1f, -1f, 0).normalized;
            rb_ball2.velocity = speed_normalized * speed;
        }

        if (!multi_game_manage_player2.instance.isPlaying && !multi_game_manage_player2.instance.is_passed)
        {
            // multi_game_manage_player2.instance.start_panel.SetActive(true);
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle2.transform.position.x;
            pos.y = paddle2.transform.position.y - radius;
            transform.position = pos;
        }
    }
}