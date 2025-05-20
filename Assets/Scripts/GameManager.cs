using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    private int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pausedText;
    public bool isGameActive;
    public bool isGamePaused = false;
    public Button restartButton;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
        isGamePaused = !isGamePaused;
          if (isGamePaused == true)
          {
            pausedText.gameObject.SetActive(true);
            Time.timeScale = 0;

          }
          else
          {
            Time.timeScale = 1;
            pausedText.gameObject.SetActive(false); 
          }
       } 
        
    }

    public void StartGame(int difficulty)
    {
        isGameActive= true;
        score = 0;
        lives = 3;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(0);
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
    }
   
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
           yield return new WaitForSeconds(spawnRate);
           int index = Random.Range(0, targets.Count);
           Instantiate(targets[index]);    
           
        }
    }
   
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score" + score;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateLives(int livesToSubtract)
    {
        lives -= livesToSubtract;
        livesText.text = "lives" + lives;
        if(lives < 1)
        {
            GameOver();
        }
    }
    
  
}
