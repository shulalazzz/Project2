using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public GameObject GroundParticle;
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
            Instantiate(GroundParticle, gameObject.transform.position, Quaternion.identity);
            game_manage.instance.is_magnetic = false;
            game_manage.instance.GameOver();
        }
        else
        {
            Instantiate(GroundParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
