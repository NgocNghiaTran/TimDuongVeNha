using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mau : MonoBehaviour
{
    public Sprite[] Heartsprite;
    public VaCham player;
    public Image Heart;

    void Start()
    {     
        player = GameObject.FindGameObjectWithTag("player").GetComponent<VaCham>();
    }
        
    void Update()
    {
        Heart.sprite = Heartsprite[player.heath];      
    }
}