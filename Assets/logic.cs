using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class logic : MonoBehaviour
{
    public GameObject jumpButton;
    public GameObject pauseBtn;
    public int score;
    public static float highScore = 0;
    public TMP_Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;

    [ContextMenu("incrase score")]
    public void addScore() {
        score += 1;
        scoreText.text = score.ToString();
    }
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void gameOver() {
        gameOverScreen.SetActive(true);
        pauseBtn.SetActive(false);
        Destroy(jumpButton);
        if(score > PlayerPrefs.GetFloat("highScore", 0)) {

            highScore = score;

            PlayerPrefs.SetFloat("highScore", highScore);

            scoreText.text = score.ToString() + "<size=30%><i><cspace=-0.1em> new high-score!";
        }
    }

    public void displayHighScore() {
        highScoreText.text = "your high score: " + PlayerPrefs.GetFloat("highScore", 0).ToString();
    }

}
