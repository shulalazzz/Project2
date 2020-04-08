using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_brick : MonoBehaviour
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
        this.enabled = false;
        game_manage.instance.check_win();
        //Debug.Log(this.name);
        Destroy(gameObject);
    }
}
