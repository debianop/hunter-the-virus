using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueBoss : MonoBehaviour
{
    public Dialogue dialogue;
    public int hp ;
    GameObject hpBar;
    HealthBar healthBar;
    public Transform target;
    GameObject gmj;

    CapsuleCollider2D col;
    bool once = true;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        gmj = GameObject.Find("Pleague_Boss");
        col = GetComponent<CapsuleCollider2D>();
        hpBar = GameObject.Find("BossHealthBar");
        healthBar = hpBar.GetComponent<HealthBar>();
    }

    private void Update()
    {
        if (target.transform.position.x < distance)
        {
            hpBar.gameObject.SetActive(false);
        }
        else if (hp > 0 && target.transform.position.x > distance)
        {
            hpBar.gameObject.SetActive(true);
        }
        if (hp == 0 && once)
        {
            gmj.gameObject.SetActive(false);
            hpBar.gameObject.SetActive(false);
            col.enabled = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            once = false;
        }
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D colEnter)
    {
        if (colEnter.gameObject.tag == "euro")
        {
            hp += -1;
            healthBar.SetHealth(hp);
            Destroy(colEnter.gameObject);
        }
    }
}
