using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Canvas gameOverScreen;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameStart()
    {
        gameOverScreen.enabled = false;
    }
    public void GameOver()
    {
        gameOverScreen.enabled = true;
        ScoreManager.SetBestScore();
        finalScoreText.text = "Score: " + ScoreManager.GetScore();
        highScoreText.text = "High Score: " + ScoreManager.GetBestScore();

    }

    public void Reset()
    {
        ScoreManager.ResetScore();
        SceneManager.LoadScene("Exam");
    }
    
}
