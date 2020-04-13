using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (game_manage.instance.IsLastBall())
        {
            game_manage.instance.is_magnetic = false;
            game_manage.instance.GameOver();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
