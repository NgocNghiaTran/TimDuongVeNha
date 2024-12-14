using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletTransform;
    public float cooldownFire = 0;
    bool canFire;
    float Timer = 0;
    SpriteRenderer sprite;
    void Start ()
    {
        sprite = bulletTransform.GetComponent<SpriteRenderer>();
    }
    IEnumerator InstantiateBullet()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 prefabPos = bulletTransform.transform.position + Change() - new Vector3(0, 0.9f, 0);
        Instantiate(bullet, prefabPos, Quaternion.identity);
    }
    void Update()
    {
        Timer += Time.deltaTime;
        canFire = Timer > cooldownFire ? true : false;
        if (canFire && Input.GetKeyDown(KeyCode.H))
        {
            Timer = 0;
            StartCoroutine(InstantiateBullet());
        }
    }
    Vector3 Change()
    {
        if(!sprite.flipX)
         return new Vector3(1f,0f,0f);
        else
         return new Vector3(-1f,0f,0f);
    }

}
