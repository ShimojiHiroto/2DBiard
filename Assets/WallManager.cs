using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private float interval = 2;

    float nextSpawnTime;

    [SerializeField]
    GameObject[] walls;

    [SerializeField]
    GameObject spawner;

    void Update()
    {
        if (nextSpawnTime < Time.timeSinceLevelLoad)
        {
            nextSpawnTime = Time.timeSinceLevelLoad + interval;
            int id = Random.Range(0, walls.Length);
            GameObject obj = (GameObject)Instantiate(walls[id], 
                spawner.transform.position, 
                spawner.transform.rotation);

        }
    }
}
