using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject[] obstacles; // Oluşturulacak engel prefab'ları
    [SerializeField] private GameObject typeOfObstacle;
    [SerializeField] private GameObject[] _1obstacles;
    
    
    public float spawnInterval; // Engel oluşturma aralığı
    
    private GameManager gameManager;
    private ObstacleController obstacleController;
    private float intervalDecreaseAmount = 0.1f; // Her spawn işleminden sonra azaltılacak aralık miktarı
    private float speedDecreaseAmount = 0.1f;
    private float spawnTimer = 0f;
    private int i = 0;

    private void Start()
    {
        _1obstacles = new GameObject[typeOfObstacle.transform.childCount];
        for (int j = 0; j < typeOfObstacle.transform.childCount; j++)
        {
            _1obstacles[j] = typeOfObstacle.transform.GetChild(j).gameObject;
        }
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
        //GameObject obstacle = obstacles[randomIndex];
        for (int j = 0; j < typeOfObstacle.transform.childCount; j++)
        {
            if (_1obstacles[j].activeSelf)
            {
                int randomIndex = Random.Range(0, _1obstacles[j].transform.childCount);
                GameObject obstacle = _1obstacles[j].transform.GetChild(randomIndex).gameObject;
                Instantiate(obstacle, transform.position, obstacle.transform.rotation);
            }
        }
        
        
    }

}
