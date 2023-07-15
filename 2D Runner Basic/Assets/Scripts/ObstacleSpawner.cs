using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles; // Oluşturulacak engel prefab'ları
    
    public float spawnInterval; // Engel oluşturma aralığı

    private GameManager gameManager;
    private ObstacleController obstacleController;
    private float intervalDecreaseAmount = 0.1f; // Her spawn işleminden sonra azaltılacak aralık miktarı
    private float speedDecreaseAmount = 0.1f;
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
        int randomIndex = Random.Range(0, obstacles.Length);
        GameObject obstacle = obstacles[randomIndex];
        
        GameObject newObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
    }

}
