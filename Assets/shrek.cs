using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class shrek : MonoBehaviour
{
    bool i = false;
    public Rigidbody2D myRigidbody;
    public float jumpstrength;
    public logic logic;
    public bool shrekalive = true;

    public AudioSource source;
    public AudioClip clip;
    public AudioSource source2;
    public AudioClip clip2;
    public AudioSource source3;
    public AudioClip clip3;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();

        source3.PlayOneShot(clip3);
    }

    // Update is called once per frame
    void Update()
    {
        if(source3.isPlaying == false && shrekalive == true) {
            source3.PlayOneShot(clip3);
        }

        if (Input.GetKeyDown(KeyCode.Space) == true || 
            Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                if(shrekalive) {
                    
                myRigidbody.velocity = Vector2.up * jumpstrength;
                myRigidbody.angularVelocity = 180;
                source.PlayOneShot(clip);
                }

        }
        if(shrekalive == false && i == false) {
            source3.Stop();
            source.PlayOneShot(clip2);
            i = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        logic.gameOver();
        shrekalive = false;
    }    
}

