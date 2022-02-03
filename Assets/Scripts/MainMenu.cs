using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject menuPanel;
    MainMenu mainMenu;

    void Start()
    {
        menuPanel = GameObject.Find("Panel");
        menuPanel.gameObject.SetActive(false);
    }
    public void PlayGame()
    {
        menuPanel.gameObject.SetActive(true);
    }

    public void newGame()
    {
        PlayerPrefs.SetInt("Checkpoint", 0);
        SceneManager.LoadScene(1);
        FindObjectOfType<BannerSc>().DestroyBanner();
    }

    public void back()
    {
        menuPanel.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

