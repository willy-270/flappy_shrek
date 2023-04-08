using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class statsstuff : MonoBehaviour
{   
    
    public TextMeshProUGUI lifeJumps;
    public TextMeshProUGUI lifeDeaths;
    public TextMeshProUGUI highScore;

    void Start()
    {
        lifeJumps.text = "Life Time Jumps: " + PlayerPrefs.GetInt("lifeTimeJumps").ToString();
        lifeDeaths.text = "Life Time Deaths: " + PlayerPrefs.GetInt("lifeTimeDeaths").ToString();
        highScore.text = "High Score: " + PlayerPrefs.GetFloat("highScore").ToString();
    }
}
