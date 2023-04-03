using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipetrigger : MonoBehaviour
{
    public logic logic;
    public shrek shrek;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();
        shrek = GameObject.FindGameObjectWithTag("shrek").GetComponent<shrek>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && triggered == false && shrek.shrekalive == true) {
            logic.addScore();
            triggered = true;
        }
    }
}
