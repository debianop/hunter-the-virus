using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class geridon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(menu());
    }

    IEnumerator menu()
    {
        yield return new WaitForSeconds(15);

        SceneManager.LoadScene("Menu");
    }
}
