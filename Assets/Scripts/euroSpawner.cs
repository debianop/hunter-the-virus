using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class euroSpawner : MonoBehaviour
{
    float speed = 13;
    Rigidbody2D rb;
    PlayerMovement target;
    Vector2 moveDirection;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }


    void OnCollisionEnter2D(Collision2D colEnter)
    {
        Destroy(gameObject);
    }

}