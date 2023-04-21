using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class iconmanager : MonoBehaviour {

    public TextMeshProUGUI donkeytxt;
    public TextMeshProUGUI pusstxt;
    public TextMeshProUGUI kingtxt;

    public GameObject donkeytxtObj;
    public GameObject pusstxtObj;
    public GameObject kingtxtObj;

    public UnityEngine.UI.Button shrekbtn;

    public int adsToWatchPuss = 2;
    public int adsToWatchDonkey = 2;

    public int top10 = 0;
    public float highScore;

    public string currentIcon;

    void Start() {
        adsToWatchPuss = PlayerPrefs.GetInt("adsToWatchPuss", 2);
        adsToWatchDonkey = PlayerPrefs.GetInt("adsToWatchDonkey", 2);

        top10 = PlayerPrefs.GetInt("top10", 0);

        highScore = PlayerPrefs.GetFloat("highScore");

        kingShrekCheck();
    }
    
    public void Update() {
        if (highScore >= 50) {
            Destroy(donkeytxtObj);
        }
        if (highScore >= 100) {
            Destroy(pusstxtObj);
        }
    }

    public void iconSelect(int IconID) {
        if(IconID == 1) {
            currentIcon = "shrek";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        } 

        if(IconID == 2 && highScore >= 50) {
            currentIcon = "donkey";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        } 

        if(IconID == 3 && highScore >= 100) {
            currentIcon = "puss";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        }

        if(IconID == 4 && top10 == 1) {
            currentIcon = "kingShrek";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        }
    }

    public void kingShrekCheck() {
        if (top10 == 1) {
            Destroy(kingtxtObj);
        }
    }
}
