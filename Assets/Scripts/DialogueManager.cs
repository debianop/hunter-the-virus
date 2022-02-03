using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    GameObject player;
    PlayerMovement playerMovement;

    public Animator animator;

    private Queue<string> sentences;

    void Start()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.canMove = true;
        sentences = new Queue<string>();        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerMovement.canMove = false;
        playerMovement.horizontalMove = 0f;
        playerMovement.animator.SetFloat("Speed", Mathf.Abs(playerMovement.horizontalMove));
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        //sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.035f);
        }
    }

    void EndDialogue()
    {
        playerMovement.canMove = true;
        animator.SetBool("IsOpen", false);
    }
}
