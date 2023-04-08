using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlescreen : MonoBehaviour
{

    public logic logic;
    public GameObject score;
    public GameObject buttons;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        logic.displayHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startgame() {
                    
        Time.timeScale = 1;
        score.SetActive(true);
        pause.SetActive(true);
        Destroy(gameObject);
        Destroy(buttons);
    }

}
