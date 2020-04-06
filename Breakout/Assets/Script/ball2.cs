using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball2 : MonoBehaviour
{
    private Rigidbody rb_ball;
    private float radius;
    public float speed;
    public Transform paddle;
    void Start()
    {
        rb_ball = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !game_manage.instance.isPlaying)
        {
            Vector3 speed_normalized = new Vector3(-1f, -1f, 0).normalized;
            rb_ball.velocity = speed_normalized * speed;
        }
        if (game_manage.instance.isPlaying == false && !game_manage.instance.is_passed)
        {
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle.transform.position.x;
            pos.y = paddle.transform.position.y - radius;
            transform.position = pos;
        }
    }
}
