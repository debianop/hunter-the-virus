using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentLevel;
    GameObject player;
    PlayerMovement playerMovement;
    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();        
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Checkpoint", 0);
        currentLevel = SceneManager.GetActiveScene().buildIndex;  // Taking the index of the current scene
        if (currentLevel != PlayerPrefs.GetInt("lastLevel"))  // If last level and current level isn't equal
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel")); // Loads last level            
        }
        FindObjectOfType<BannerSc>().DestroyBanner();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(currentLevel);  // Restarting the same level
        Time.timeScale = 1;
        playerMovement.death = false;
    }

    public void nextLevel()
    {
        PlayerPrefs.SetInt("Checkpoint", 0);
        PlayerPrefs.SetInt("lastLevel", currentLevel + 1);  // Setting the PlayerPrefs variable to the next scene
        Debug.Log(PlayerPrefs.GetInt("lastLevel"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loading the next scene           
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
