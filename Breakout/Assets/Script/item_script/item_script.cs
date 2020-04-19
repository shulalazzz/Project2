using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_script : MonoBehaviour
{
    public item_type current_type;
    public GameObject ball_prefab;
    public Transform paddle;
    public float explosion_radius;
    public AudioSource ACspecial;
   public enum item_type
    {
        life_item,
        multiballs_item,
        magnetic_item,
        extend_item,
        boom_item

    }
    private void OnCollisionEnter(Collision collision)
    {
      ACspecial.Play();
        Debug.Log("Item activated "+ transform.name);
        if(current_type == item_type.life_item)
        {
            game_manage.instance.ChangeLife(1);

        }
        else if(current_type == item_type.multiballs_item)
        {
            for(int i = 0; i < 2; i++)
            {
                GameObject ball = Instantiate(ball_prefab);
                ball.transform.position = transform.position;
                ball.GetComponent<ball>().StartMove();
            }
        }
        else if(current_type == item_type.magnetic_item)
        {
            game_manage.instance.is_magnetic = true;
        }
        else if(current_type == item_type.extend_item)
        {
            paddle = GameObject.FindObjectOfType<paddle_moving>().transform;
            game_manage.instance.is_extend = true;
            paddle.localScale = new Vector3(4f, 0.3f, 1f);
        }
        else if (current_type == item_type.boom_item)
        {
            Collider[] destory_obj = Physics.OverlapSphere(transform.position, explosion_radius);
            foreach(Collider obj in destory_obj)
            {
                if(!obj.CompareTag("Player"))
                {
                    Destroy(obj.gameObject);
                }
            }
        }

        Destroy(gameObject);
    }
}
