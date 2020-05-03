using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager_Game : MonoBehaviour
{
    public Text scoreText;
    public GameObject optionPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {ScoreManager.currentScore.ToString()}";
        if(Input.GetKey(KeyCode.Escape))
        {
            optionPanel.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1;
    }
    

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }


}
