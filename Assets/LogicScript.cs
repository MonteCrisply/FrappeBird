using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public AudioSource scorePop;
    public GameObject gameOverScreen;
    public Text score;
    public int playerScore;

    [ContextMenu("Increase Score")]
    public void addScore(int addValue)
    {
        playerScore += addValue;
        score.text = playerScore.ToString();
        scorePop.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
