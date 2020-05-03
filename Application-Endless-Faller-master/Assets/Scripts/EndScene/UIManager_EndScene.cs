using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager_EndScene : MonoBehaviour
{
    public Text textMessage;
    public Text textHighscore;
    void Awake()
    {
        
        
    }
    private void Start()
    {
        if (ScoreManager.currentScore <= ScoreManager.highScore)
        {
            textMessage.text = $"You have passed {ScoreManager.currentScore} platforms. Impressive, but i know you can do better.";
            textHighscore.text = $"Your Highscore: {ScoreManager.highScore}";
        }
        else
        {
            ScoreManager.Save();
            textMessage.text = $"Well done! You passed {ScoreManager.currentScore} platforms and achived a new Highscore.";
            textHighscore.text = $"Your Highscore: {ScoreManager.currentScore}";
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
