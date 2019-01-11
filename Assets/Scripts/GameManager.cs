using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text score;
    public Text highScore;
    bool gameOver = false;

    private void Update()
    {
        if (!gameOver) score.text = Time.timeSinceLevelLoad.ToString("f2");
    }

    public void GameOver(bool hasWon)
    {
        gameOver = true;
        if (hasWon) highScore.text = score.text;
        else highScore.text = "0";
        gameOverUI.SetActive(true);
        Debug.Log("Game over man!");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}
