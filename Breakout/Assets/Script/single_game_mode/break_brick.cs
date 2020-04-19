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

    public AudioSource AC;
    private void OnCollisionEnter(Collision collision)
    {
        this.enabled = false;
        AC.Play();
        game_manage.instance.CheckWin();
        Debug.Log("Destroying " + gameObject.name);
        Destroy(gameObject);
    }
}
