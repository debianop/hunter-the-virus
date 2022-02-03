using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpDiaTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform player;
    public GameObject text;
    public Animator anim;
    public GameObject tpPanel;

    private void Start()
    {
        tpPanel.gameObject.SetActive(false);          
    }
    private void Update()
    {
        if (player.transform.position.x - transform.position.x <= 2  && player.transform.position.x-transform.position.x>=-2)
        {
            text.gameObject.SetActive(true);            
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }

    IEnumerator newScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void interact() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        tpPanel.gameObject.SetActive(true);
        anim.SetBool("play", true);
        StartCoroutine(newScene());       
    }
}
