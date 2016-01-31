using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public Transform[] enemy;
    public float spawn;
    public Transform[] spawnPoint;

    //public Transform key;
    //public float keySpawn = 1f;
    //public Transform[] keySpawnPoint;

    void Start()
    {

        InvokeRepeating("Spawn", 1f, 10f);
        //Invoke("keySpawnner", keySpawn);

    }

    void Spawn()
    {

        int spawnPointIndex = Random.Range(0, spawnPoint.Length);
        int enemyIndex = Random.Range(0, enemy.Length);
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(enemy[0], spawnPoint[i].position, spawnPoint[i].rotation);
        }
    }

    //public void keySpawnner()
    //{
    //    int keySpawnIndex = Random.Range(0, keySpawnPoint.Length);
    //    Instantiate(key, keySpawnPoint[keySpawnIndex].position, keySpawnPoint[keySpawnIndex].rotation);
    //}
}

