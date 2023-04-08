using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class iconmanager : MonoBehaviour {

    void Start() {
    }
    public string currentIcon;

    public void iconSelect(int IconID) {
        if(IconID == 1) {
            currentIcon = "shrek";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        } if(IconID == 2) {
            currentIcon = "donkey";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        } if(IconID == 3) {
            currentIcon = "puss";
            PlayerPrefs.SetString("currentIcon", currentIcon);
        }
    }
}
