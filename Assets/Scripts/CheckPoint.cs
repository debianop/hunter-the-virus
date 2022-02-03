using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D colEnter)
    {
        if (colEnter.gameObject.tag=="Player")
        {
            Debug.Log("WTFABE");
            PlayerPrefs.SetInt("Checkpoint", 1);
        }
    }
}
