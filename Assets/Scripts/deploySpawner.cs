using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploySpawner : MonoBehaviour
{
    public GameObject dolarPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
         StartCoroutine(spawnWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(dolarPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator spawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
