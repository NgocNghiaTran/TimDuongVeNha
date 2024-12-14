using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donbay : MonoBehaviour
{
    public float doNay = 13.0f;
    public SpriteRenderer mauSac;
    void Start()
    {
        mauSac = GetComponent<SpriteRenderer>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * doNay, ForceMode2D.Impulse);
            mauSac.color = Color.red;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            mauSac.color = Color.white;
        }
    }
}
