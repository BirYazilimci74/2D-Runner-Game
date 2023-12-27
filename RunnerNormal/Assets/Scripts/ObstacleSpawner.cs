using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacles;
    
    private const float speedDecreaseAmount = 0.2f;
    
    public int obsCounter = 0;
    public float spawnInterval; // Engel oluşturma aralığı
    private void Start()
    {;
        StartCoroutine(IESpawnObstacle());
    }

    private IEnumerator IESpawnObstacle()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
            if (!GameManager.Instance.canPlay)
            {
                break;
            }
        }
    }

    private void Update()
    {
        if (!GameManager.Instance.canPlay)
        {
            return;
        }
    }

    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.transform.childCount);
        GameObject obstacle = obstacles.transform.GetChild(randomIndex).gameObject;
        Instantiate(obstacle, transform.position, obstacle.transform.rotation);
        obsCounter++;
    }
    
}
