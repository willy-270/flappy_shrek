using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlescreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) ||
            Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}
