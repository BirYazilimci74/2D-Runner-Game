using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacles;
    
    public float spawnInterval; // Engel oluşturma aralığı
    
    private ObstacleController obstacleController;
    private float intervalDecreaseAmount = 0.1f; // Her spawn işleminden sonra azaltılacak aralık miktarı
    private float speedDecreaseAmount = 0.1f;
    private GameManager gameManager;
    private float spawnTimer = 0f;
    private int i = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        obstacleController = FindObjectOfType<ObstacleController>();
    }

    private void Update()
    {
        if (!gameManager.canPlay)
        {
            return;
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0f;
            
            // Spawn işleminden sonra spawnInterval'i azalt
            if (i%5 == 0)
            {
                spawnInterval -= intervalDecreaseAmount;
                obstacleController.obstacleSpeed += speedDecreaseAmount;
            }
            if (spawnInterval < 2f)
            {
                spawnInterval = 2f;
            }
        }
        i++;
    }

    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.transform.childCount);
        GameObject obstacle = obstacles.transform.GetChild(randomIndex).gameObject;
        Instantiate(obstacle, transform.position, obstacle.transform.rotation);
    }

}
