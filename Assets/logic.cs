using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logic : MonoBehaviour
{
    public int score;
    public Text scoreText;
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
    }
}
