using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingpipe : MonoBehaviour
{
    public float deadZone = -40;
    public float moveSpeed = 6;
    float yMoveSpeed = 3.5f;
    public string currentDir;
    bool i = false;

    void Start()
    {

    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(i == false) {
            if(Random.value < 0.5f) {
            currentDir = "up";
            i = true;
        } else {
            currentDir = "down";
            i = true;
        }
        }

        if(currentDir == "down") {
            if (transform.position.y > -23) {
                transform.position += (Vector3.down * yMoveSpeed) * Time.deltaTime;
            } else {
                currentDir = "up";
            }
        }

        if(currentDir == "up") {
            if (transform.position.y < -15) {
                transform.position += (Vector3.up * yMoveSpeed) * Time.deltaTime;
            } else {
                currentDir = "down";
            }
        }

        if(transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
