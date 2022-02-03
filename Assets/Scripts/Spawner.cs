using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pref1,pref2;

    float nextSpawn = 1f;
    public Transform target;
    int whatToSpawn;
    public Transform spawnPoint;
    GameObject bosshp;
    BossHealthBar bossHealthBar;
    public string boss;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        bosshp = GameObject.Find(boss);
        bossHealthBar = bosshp.GetComponent<BossHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x<distance)
        {
            if (nextSpawn > 1f) //if time has come
            {                
                Instantiate(pref1, new Vector3(target.transform.position.x + 25, target.transform.position.y + Random.Range(0, 5), target.transform.position.z), Quaternion.identity);                               
                nextSpawn = 0;
            }
            nextSpawn += Time.deltaTime;
        }
        else
        {
            if (nextSpawn > 0.8f)
            {
                if (bossHealthBar.hp>0)
                {
                    Instantiate(pref2, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
                    nextSpawn = 0;
                }                
            }
            nextSpawn += Time.deltaTime;
        }
        
    }
}
