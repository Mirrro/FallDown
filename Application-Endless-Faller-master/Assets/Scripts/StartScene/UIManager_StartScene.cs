using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager_StartScene : MonoBehaviour
{
    public Text textHighscore;
    // Start is called before the first frame update
    private void Start()
    {
        ScoreManager.Load();
        textHighscore.text = $"Your Highscore: {ScoreManager.highScore.ToString()}";
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
