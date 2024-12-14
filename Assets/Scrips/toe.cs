using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toe : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D body;
    void Start()
    {
        ani = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.gameObject.tag== "player")
        {
            ani.SetBool("toe",true);
        }
    }
    private void OnTriggerExit2D(Collider2D o)
    {
       if(o.gameObject.tag== "player")
       {
        ani.SetBool("toe",false);    
       }
    }
}
