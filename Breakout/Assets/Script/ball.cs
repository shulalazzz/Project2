using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    private Rigidbody rb_ball;
    private float radius;
    public float speed;
    public Transform paddle;
    void Start()
    {
        rb_ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!game_manage.instance.isPlaying)
        {
            game_manage.instance.isPlaying = true;
            game_manage.instance.start_panel.SetActive(false);
            Vector3 speed_normalized =  new Vector3(1f, 1f, 0).normalized;
            rb_ball.velocity = speed_normalized * speed;
        }
        if (game_manage.instance.isPlaying == false)
        {
            game_manage.instance.start_panel.SetActive(true);
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle.transform.position.x;
            pos.y = paddle.transform.position.y + radius;
            transform.position = pos;
        }
    }
}
