using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topper : MonoBehaviour
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
        if (collision.transform.tag == "Ball2") {
            if (multi_game_manage_player2.instance.IsLastBall())
            {
                multi_game_manage_player2.instance.is_magnetic = false;
                multi_game_manage_player2.instance.GameOver();
            }
            else
            {
                Instantiate(GroundParticle, gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
    }
}
