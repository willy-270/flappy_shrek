using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipspawn : MonoBehaviour
{
    int i = 0;
    public GameObject pipe;
    public pipe pipeS;
    public movingpipe movingPipeS;
    public GameObject movingPipe;
    public float spawnRate = 0.5f;
    private float timer = 0;
    public float heightOffset = 9;
    // Start is called before the first frame update
    void Start()
    {
        pipeS.moveSpeed = 6f;
        movingPipeS.moveSpeed = 6;

        spawnpipe();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        i = Random.Range(1, 6);

        if(timer < spawnRate) {
            timer = timer + Time.deltaTime;
        } 
        else 
        {
            if(i == 5) {
                spawnMovingPipe();
                i = 0;
                pipeS.moveSpeed += 0.1f;
                movingPipeS.moveSpeed += 0.1f;
                timer = 0;
                Debug.Log("spawned moving");
            }
            else
            {
                spawnpipe();
                i += 1;
                pipeS.moveSpeed += 0.1f;
                movingPipeS.moveSpeed += 0.1f;
                timer = 0;
                Debug.Log("spawned normal");
            }

        }
    }
    void spawnpipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
    void spawnMovingPipe() {
        float lowestPoint2 = transform.position.y - heightOffset;
        float highestPoint2 = transform.position.y + heightOffset;

        Instantiate(movingPipe, new Vector3(transform.position.x, Random.Range(lowestPoint2, highestPoint2), 0), transform.rotation);
    }
}
