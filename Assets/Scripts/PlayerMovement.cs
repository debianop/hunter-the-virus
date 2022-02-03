using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	int hp = 10;
	public bool canMove;
	public LayerMask enemyLayers;
	public float runSpeed = 40f;
	public Transform attackPoint;
	float attackRange;
	public float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public bool death;
	public GameObject deathPanel;
	GameObject hpBar,checkP;
	HealthBar healthBar;
	CheckPoint checkPoint;
	public Sprite safeSprite;
	float hitCd;
    private void Start()
    {
		checkP = GameObject.Find("CheckPoint");
		checkPoint = checkP.GetComponent<CheckPoint>();
		hpBar = GameObject.Find("HealthBar");
		healthBar = hpBar.GetComponent<HealthBar>();
		death = false;
		deathPanel.gameObject.SetActive(false);
		if (PlayerPrefs.GetInt("Checkpoint") == 1)
		{
			transform.position = checkPoint.transform.position;
		}
	}
    void Update () {
        if (transform.position.y<-7.5f)
        {
			death = true;
        }
        if (hp == 0)
        {
			death = true;
        }
        if (death)
        {
			deathPanel.gameObject.SetActive(true);
        }
        if (canMove && !death)
        {
			horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (CrossPlatformInputManager.GetButtonDown("Jump"))
			{
				jump = true;
				animator.SetBool("IsJumping", true);
				FindObjectOfType<AudioManager>().Play("PlayerJump");
			}


			if (CrossPlatformInputManager.GetButtonDown("Crouch"))
			{
				crouch = true;
			}
			else if (CrossPlatformInputManager.GetButtonDown("Crouch"))
			{
				crouch = false;
			}

            if (CrossPlatformInputManager.GetButtonDown("Combat"))
            {               
				animator.SetBool("Attack", true);
				attackRange = 2f;
				Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

				//Damage them
				foreach (Collider2D enemy in hitEnemies)
				{
					Rigidbody2D rigidbody = enemy.GetComponent<Rigidbody2D>();
					SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
					if (rigidbody != null)
					{
						sr.sprite = safeSprite;
						FindObjectOfType<AudioManager>().Play("PlayerAttack");
						rigidbody.AddForce(new Vector3(50, Random.Range(3, 8), 0), ForceMode2D.Impulse);
					}
				}				
			}
            else
            {
				animator.SetBool("Attack", false);
			}
		}
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
    void OnCollisionEnter2D(Collision2D colEnter)
    {
		if (colEnter.gameObject.tag == "euro")
		{
			FindObjectOfType<AudioManager>().Play("Hurt");
			hp += -1;
			healthBar.SetHealth(hp);
			Destroy(colEnter.gameObject);
		}
	}
}

