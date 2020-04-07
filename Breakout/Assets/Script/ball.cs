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
    private bool hacking = false;
    void Start()
    {
        rb_ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_manage.instance.isPlaying && game_manage.instance.is_passed) {
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle.transform.position.x;
            pos.y = paddle.transform.position.y + radius;
            transform.position = pos;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (hacking)
            {
                hacking = false;
                Vector3 speed_normalized = new Vector3(1f, 1f, 0).normalized;
                rb_ball.velocity = speed_normalized * speed;
            }
            else
            {
                hacking = true;
                Vector3 hack_normalized = new Vector3(1f, 1f, 0).normalized;
                rb_ball.velocity = hack_normalized * 60;
            }
        }
        if (hacking)
        {
            Vector3 pos = transform.position;
            pos.x = paddle.transform.position.x;
            transform.position = pos;
        }
        if (Input.GetMouseButtonDown(0)&&!game_manage.instance.isPlaying)
        {
            game_manage.instance.isPlaying = true;
            game_manage.instance.start_panel.SetActive(false);
            Vector3 speed_normalized =  new Vector3(1f, 1f, 0).normalized;
            Debug.Log("release ball1");
            rb_ball.velocity = speed_normalized * speed;
        }
        if (game_manage.instance.isPlaying == false && !game_manage.instance.is_passed)
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
