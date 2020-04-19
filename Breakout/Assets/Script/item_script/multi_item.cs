using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi_item : MonoBehaviour
{
    public item_type current_type;
    public GameObject ball_prefab1;
    public GameObject ball_prefab2;
    public AudioSource ACspecial;

    public enum item_type
    {
        life_item, multiballs_item, magnetic_item
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Item activated "+ transform.name);

        if (collision.transform.tag == "Ball1") {
          ACspecial.Play();
            if(current_type == item_type.life_item)
            {
                multi_game_manage_player1.instance.ChangeLife(1);
            }
            else if(current_type == item_type.multiballs_item)
            {
                for(int i = 0; i < 2; i++)
                {
                    GameObject ball1 = Instantiate(ball_prefab1);
                    ball1.transform.position = transform.position;
                    ball1.GetComponent<ball1>().StartMove();
                }
            }
            else if(current_type == item_type.magnetic_item)
            {
                multi_game_manage_player1.instance.is_magnetic = true;
            }
        }

        if (collision.transform.tag == "Ball2") {
          ACspecial.Play();
            if(current_type == item_type.life_item)
            {
                multi_game_manage_player2.instance.ChangeLife(1);
            }
            else if(current_type == item_type.multiballs_item)
            {
                for(int i = 0; i < 2; i++)
                {
                    GameObject ball2 = Instantiate(ball_prefab2);
                    ball2.transform.position = transform.position;
                    ball2.GetComponent<ball2>().StartMove();
                }
            }
            else if(current_type == item_type.magnetic_item)
            {
                multi_game_manage_player2.instance.is_magnetic = true;
            }
        }

        Destroy(gameObject);
    }
}
