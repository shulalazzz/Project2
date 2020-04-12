using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_moving : MonoBehaviour
{
    public float speed;
    public float x_min;
    public float x_max;
    
    void Update()
    {
        if (game_manage.instance.is_passed) {
            return;
        }
        float x_direction = Input.GetAxisRaw("Horizontal");
        if(x_direction != 0)
        {
            Vector3 pos = transform.position;
            pos.x += x_direction * speed * Time.deltaTime;
            pos.x=Mathf.Clamp(pos.x, x_min, x_max);
            transform.position = pos;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (game_manage.instance.is_magnetic)
        {
            game_manage.instance.is_magnetic = false;
            collision.gameObject.GetComponent<ball>().apply_magnetic = true;

        }
    }
}
