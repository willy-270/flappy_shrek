using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lbhighscore : MonoBehaviour
{
    public TextMeshProUGUI highscorelb;
    public TextMeshProUGUI highscorelb2;
    public TMP_InputField input;

    void Start()
    {
        highscorelb.text = "Your High-Score: ";
        highscorelb2.text = PlayerPrefs.GetFloat("highScore").ToString();

        input.text = PlayerPrefs.GetString("username");
    }
}