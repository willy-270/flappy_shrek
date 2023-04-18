using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class iconmanager : MonoBehaviour {

    public AdsManager AdsManager;

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

    public string currentIcon;

    void Start() {
        adsToWatchPuss = PlayerPrefs.GetInt("adsToWatchPuss", 2);
        adsToWatchDonkey = PlayerPrefs.GetInt("adsToWatchDonkey", 2);

        top10 = PlayerPrefs.GetInt("top10", 0);

        kingShrekCheck();
    }
    
    public void Update() {
        if (adsToWatchDonkey == 0) {
            Destroy(donkeytxtObj);
        }
        if (adsToWatchPuss == 0) {
            Destroy(pusstxtObj);
        }
    }

    public void iconSelect(int IconID) {
        if(IconID == 1) {
            currentIcon = "shrek";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        } 

        if(IconID == 2 && adsToWatchDonkey == 0) {
            currentIcon = "donkey";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        } 

        if(IconID == 3 && adsToWatchPuss == 0) {
            currentIcon = "puss";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        }

        if(IconID == 4 && top10 == 1) {
            currentIcon = "kingShrek";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        }
    }

    public void adStuffPuss() {
        if (adsToWatchPuss > 0) {
            AdsManager.LoadRewardedAd();
            adsToWatchPuss -= 1;

            PlayerPrefs.SetInt("adsToWatchPuss", adsToWatchPuss);

            pusstxt.text = "Watch\n" + adsToWatchPuss.ToString() + "\nMore Ads To Unlock";
        } else {
            Destroy(pusstxtObj);
        }
    }

    public void adStuffDonkey() {
        if (adsToWatchDonkey > 0) {
            AdsManager.LoadRewardedAd();
            adsToWatchDonkey -= 1;

            PlayerPrefs.SetInt("adsToWatchDonkey", adsToWatchDonkey);

            donkeytxt.text = "Watch\n" + adsToWatchDonkey.ToString() + "\nMore Ads To Unlock";
        } else {
            Destroy(donkeytxtObj);
        }
    }

    public void kingShrekCheck() {
        if (top10 == 1) {
            Destroy(kingtxtObj);
        }
    }
}
