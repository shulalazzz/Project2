using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi_item : MonoBehaviour
{
    public item_type current_type;
    public GameObject ball_prefab1;
    public GameObject ball_prefab2;
    public GameObject ParticleBrick;
    public AudioSource ACspecial;
    public float explosion_radius;
    public Transform paddle;

    public enum item_type
    {
        life_item,
        multiballs_item,
        magnetic_item,
        boom_item,
        extend_item
    }

    private void OnCollisionEnter(Collision collision)
    {
        ACspecial.Play();
        Debug.Log("Item activated " + transform.name);

        if (collision.transform.tag == "Ball1") {
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
            else if(current_type == item_type.boom_item)
            {
                Collider[] destory_obj = Physics.OverlapSphere(transform.position, explosion_radius);
                foreach(Collider obj in destory_obj)
                {
                    if(obj.CompareTag("player1_brick")) {
                        Instantiate(ParticleBrick, gameObject.transform.position, Quaternion.identity);
                        Destroy(obj.gameObject);
                    }
                }
            }
            else if(current_type == item_type.extend_item)
            {
                paddle = GameObject.FindObjectOfType<paddle1_moving>().transform;
                multi_game_manage_player1.instance.is_extend = true;
                paddle.localScale = new Vector3(paddle.transform.localScale.x + 2, paddle.transform.localScale.y, paddle.transform.localScale.z);
            }
        }

        if (collision.transform.tag == "Ball2") {
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
            else if(current_type == item_type.boom_item)
            {
                Collider[] destory_obj = Physics.OverlapSphere(transform.position, explosion_radius);
                foreach(Collider obj in destory_obj)
                {
                    if(obj.CompareTag("player2_brick")) {
                        Instantiate(ParticleBrick, gameObject.transform.position, Quaternion.identity);
                        Destroy(obj.gameObject);
                    }
                }
            }
            else if(current_type == item_type.extend_item)
            {
                paddle = GameObject.FindObjectOfType<paddle2_moving>().transform;
                multi_game_manage_player2.instance.is_extend = true;
                paddle.localScale = new Vector3(paddle.transform.localScale.x + 2, paddle.transform.localScale.y, paddle.transform.localScale.z);
            }
        }

        Instantiate(ParticleBrick, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
