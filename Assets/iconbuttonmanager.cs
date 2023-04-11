using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class iconbuttonmanager : MonoBehaviour
{
    public UnityEngine.UI.Button shrekbtn;
    public UnityEngine.UI.Button donkeybtn;
    public UnityEngine.UI.Button pussbtn;

    public string currentIcon;

    public void Start() {
        string currentIcon = (PlayerPrefs.GetString("currentIcon", "shrek"));

        if (currentIcon == "shrek") {
            shrekbtn.Select();
        }
        if (currentIcon == "donkey") {
            donkeybtn.Select();
        }
        if (currentIcon == "puss") {
            pussbtn.Select();
        }
    }
}
