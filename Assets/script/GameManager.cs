using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public Player player;
    public GameObject RestartButton;
    public GameObject ContinueButton;
    [SerializeField] Sprite btnrestartIdle;
    [SerializeField] Sprite btnrestartHover;
    

    public bool gameIsPause;

    //public Text gameOverCountdown;
    

    public Text playerScore;
    public Text scoreDead;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        gameIsPause = false;
        score = 0; 
        RestartButton.SetActive(false);
        ContinueButton.SetActive(false);
        
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            RestartButton.SetActive(true);
            ContinueButton.SetActive(true);
        }

        

        playerScore.text = $"Score: {(score).ToString("0")}";

        if (player.scouceUp)
        {
            score++;
            playerScore.text = $"Score: {(score).ToString("0")}";
            player.scouceUp = false;
        }
        

        
    }
    public void btnRestartIdle()
    {
        RestartButton.GetComponent<Image>().sprite = btnrestartIdle;
    }
    public void btnRestartHover()
    {
        RestartButton.GetComponent<Image>().sprite = btnrestartHover;
    }
    
    public void btnContinueIdle()
    {
        ContinueButton.GetComponent<Image>().color = Color.white;
    }
    public void btnContinueHover()
    {
        ContinueButton.GetComponent<Image>().color = Color.red;
    }
    public void btnPlayIdle()
    {
        startButton.GetComponent<Image>().color = Color.white;
    }
    public void btnPlayHover()
    {
        startButton.GetComponent<Image>().color = Color.red;
    }
    
    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        scoreDead.text = $"Your score: {(score).ToString("0")}";
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        gameIsPause = !gameIsPause;
        if(gameIsPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
