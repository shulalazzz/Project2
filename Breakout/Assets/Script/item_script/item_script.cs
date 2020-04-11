using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_script : MonoBehaviour
{
    public item_type current_type;
    public GameObject ball_prefab;
   public enum item_type
    {
        life_item, multiballs_item
        
    }
    private void OnCollisionEnter(Collision collision)
    {
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
        Debug.Log("destorying " + transform.name);
        Destroy(gameObject);
    }
}
