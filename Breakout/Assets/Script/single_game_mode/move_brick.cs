using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class move_brick : MonoBehaviour
{
    public float speed;
    public float start;
    public float end;
    private Transform son;
    public bool moveToLeft = true;
    private void Start()
    {
        son = this.transform;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (son.position.x <= end && moveToLeft)
        {
            moveToLeft = false;
        }
        else if (son.position.x >= start && !moveToLeft)
            moveToLeft = true;
        son.position += (moveToLeft ? Vector3.left : Vector3.right) * Time.deltaTime * speed;
    }
}