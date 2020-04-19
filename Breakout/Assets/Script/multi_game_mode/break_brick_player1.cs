using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_brick_player1 : MonoBehaviour
{
    public GameObject ParticleBrick;
    void Start()
    {

    }

    void Update()
    {

    }

    public AudioSource AC;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball1") {
            this.enabled = false;
            multi_game_manage_player1.instance.ChangeScore(1);
            multi_game_manage_player1.instance.check_win();
            Instantiate(ParticleBrick, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            AC.Play();
        }
    }
}
