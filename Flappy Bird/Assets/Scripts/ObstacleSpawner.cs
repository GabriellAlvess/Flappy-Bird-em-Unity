using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minHeight, maxHeight, initSpawn, spaceBetween;
    private GameObject lastObject;
    private List<GameObject> obstacles;

    void Start()
    {
        obstacles = new List<GameObject>();
        lastObject = GetObstacle();
        lastObject.transform.position = new Vector2(initSpawn, Random.Range(minHeight, maxHeight));
    }

    void Update()
    {
        if (lastObject.transform.position.x <= initSpawn - spaceBetween)
        {
            lastObject = GetObstacle();
            lastObject.transform.position = new Vector2(initSpawn, Random.Range(minHeight, maxHeight));
        }
        
        for(int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].transform.position.x <= transform.position.x)
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    GameObject GetObstacle()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (!obstacles[i].activeInHierarchy)
            {
                obstacles[i].SetActive(true);
                return obstacles[i];
            }
        }

        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.parent = transform;
        obstacles.Add(obstacle);
        return obstacle;
    }
}
