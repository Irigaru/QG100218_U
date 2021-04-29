using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPreFab;
    //public GameObject EnemyPreFabCrown;
    public float Generator_Timer = 3.5f;
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawn()
    {
        Instantiate(EnemyPreFab, transform.position = new Vector3(x, -y, z), Quaternion.identity);
        //Instantiate(EnemyPreFabCrown, transform.position = new Vector3(600, -67f, 0), Quaternion.identity);
    }

    public void startspawn()
    {
        InvokeRepeating("spawn", 0f, Generator_Timer);
    }
    public void cancelspawn(bool clean = false)
    {
        CancelInvoke("spawn");
        if (clean) 
        {
            Object[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in allEnemies)
            {
                Destroy(enemy);
            }
        }
    }
}
