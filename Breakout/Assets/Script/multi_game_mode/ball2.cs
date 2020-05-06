﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball2 : MonoBehaviour
{
    private Rigidbody rb_ball2;
    private float radius;
    public float speed;
    public bool apply_magnetic;
    public Transform paddle2;
    private bool hacking = false;

    void Awake()
    {
        rb_ball2 = GetComponent<Rigidbody>();
        paddle2 = GameObject.FindObjectOfType<paddle2_moving>().transform;
        apply_magnetic = false;
    }

    void Update()
    {
        if (multi_game_manage_player2.instance.is_passed || multi_game_manage_player1.instance.is_passed || multi_game_manage_player2.instance.lose) {
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

        if ((Input.GetMouseButtonDown(0) && !multi_game_manage_player2.instance.isPlaying) || (Input.GetMouseButtonDown(0) && apply_magnetic))
        {
            multi_game_manage_player2.instance.isPlaying = true;
            multi_game_manage_player2.instance.start_panel.SetActive(false);
            apply_magnetic = false;
            StartMove();
        }

        if (!multi_game_manage_player2.instance.isPlaying && !multi_game_manage_player2.instance.is_passed)
        {
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle2.transform.position.x;
            pos.y = paddle2.transform.position.y - radius;
            transform.position = pos;
        }

        if (apply_magnetic)
        {
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle2.transform.position.x;
            pos.y = paddle2.transform.position.y - radius;
            transform.position = pos;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (multi_game_manage_player2.instance.isPlaying)
        {
            Vector3 sp = rb_ball2.velocity.normalized;
            float angle = Mathf.Asin(sp.y / 1) * Mathf.Rad2Deg;
            if ((0 <= angle && angle <= 10) || (-10 <= angle && angle <= 0) || (80 <= angle && angle <= 90) || (-90 <= angle && angle <= -80))
            {
                Vector3 speed_normalized = new Vector3(-1f, -1f, 0).normalized;
                rb_ball2.velocity = speed_normalized * speed;
            }
        }
    }

    int RandomAngle()
    {
        int angle = Random.Range(-10, -170);
        return angle;
    }
    
    public void StartMove()
    {
        int angle = RandomAngle();
        Vector3 speed_normalized = new Vector3(-1f, Mathf.Tan(angle * Mathf.Deg2Rad), 0).normalized;
        if (MainMenu.instance.is_test) {
            Debug.Log("release ball2");
        }
        rb_ball2.velocity = speed_normalized * speed;
    }
}
