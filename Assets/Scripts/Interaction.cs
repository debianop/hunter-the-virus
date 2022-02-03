using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    GameObject cam;
    LevelManager levelManager;
    public Transform car; 
    public GameObject text;
    // Update is called once per frame
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        levelManager = cam.GetComponent<LevelManager>();
    }
    void Update()
    {
        if (car.transform.position.x - transform.position.x <= 2 && car.transform.position.x - transform.position.x >= -2)
        {
            text.gameObject.SetActive(true);            
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
    public void interact()
    {
        PlayerPrefs.SetInt("Checkpoint", 0);
        levelManager.nextLevel();
    }
}
