using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi_move_brick : MonoBehaviour
{
    public float speed;
    public float start;
    public float end;
    private Transform brick;
    public bool moveToLeft = true;

    private void Start()
    {
        brick = this.transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (brick.position.x <= end && moveToLeft)
        {
            moveToLeft = false;
        }
        else if (brick.position.x >= start && !moveToLeft)
            moveToLeft = true;
        brick.position += (moveToLeft ? Vector3.left : Vector3.right) * Time.deltaTime * speed;
    }
}
