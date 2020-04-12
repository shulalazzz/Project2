using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    private Rigidbody rb_ball;
    private float radius;
    public float speed;
    public bool apply_magnetic;
    public Transform paddle;
    private bool hacking = false;
    void Awake()
    {
        rb_ball = GetComponent<Rigidbody>();
        paddle = GameObject.FindObjectOfType<paddle_moving>().transform;
        apply_magnetic = false;
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
        if ((Input.GetMouseButtonDown(0)&&!game_manage.instance.isPlaying) || (Input.GetMouseButtonDown(0) && apply_magnetic))
        {
            game_manage.instance.isPlaying = true;
            game_manage.instance.start_panel.SetActive(false);
            apply_magnetic = false;
            StartMove();
        }
        //not start, ball follow paddle
        if (game_manage.instance.isPlaying == false && !game_manage.instance.is_passed)
        {
            game_manage.instance.start_panel.SetActive(true);
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle.transform.position.x;
            pos.y = paddle.transform.position.y + radius;
            transform.position = pos;
        }
        if (apply_magnetic)
        {
            radius = gameObject.GetComponent<SphereCollider>().radius;
            Vector3 pos = transform.position;
            pos.x = paddle.transform.position.x;
            pos.y = paddle.transform.position.y + radius;
            transform.position = pos;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (game_manage.instance.isPlaying)
        {
            Vector3 sp = rb_ball.velocity.normalized;
            float angle = Mathf.Asin(sp.y / 1) * Mathf.Rad2Deg;
            if((0 <= angle && angle <=10) || (-10 <= angle && angle <= 0) || (80 <= angle && angle <= 90) || (-90 <= angle && angle <= -80))
            {
                Vector3 speed_normalized = new Vector3(1f, 1f, 0).normalized;
                rb_ball.velocity = speed_normalized * speed;
                Debug.Log("angle changed");
            }
        }
    }
    int RandomAngle()
    {
        int angle = Random.Range(10, 170);
        return angle;
    }
    public void StartMove()
    {
        int angle = RandomAngle();
        Vector3 speed_normalized = new Vector3(1f, Mathf.Tan(angle * Mathf.Deg2Rad), 0).normalized;
        Debug.Log("release ball1");
        rb_ball.velocity = speed_normalized * speed;
    }
}
