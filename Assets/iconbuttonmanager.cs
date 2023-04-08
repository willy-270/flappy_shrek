using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class iconbuttonmanager : MonoBehaviour
{
    public UnityEngine.UI.Button shrekbtn;
    public UnityEngine.UI.Button donkeybtn;
    public UnityEngine.UI.Button pussbtn;

    void Start()
    {
        if(PlayerPrefs.GetString("currentIcon") == "shrek") {
            shrekbtn.Select();
        }
        if(PlayerPrefs.GetString("currentIcon") == "donkey") {
            donkeybtn.Select();
        }
        if(PlayerPrefs.GetString("currentIcon") == "puss") {
            pussbtn.Select();
        }
    }
}
