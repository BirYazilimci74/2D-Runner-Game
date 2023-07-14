using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles; // Oluşturulacak engel prefab'ları
    
    public float spawnInterval; // Engel oluşturma aralığı
    public float obstacleSpeed; // Engel hareket hızı
    
    private float intervalDecreaseAmount = 0.1f; // Her spawn işleminden sonra azaltılacak aralık miktarı
    private float spawnTimer = 0f;
    private int i = 0;
    
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0f;
            
            // Spawn işleminden sonra spawnInterval'i azalt
            if (i%5 == 0)
            {
                spawnInterval -= intervalDecreaseAmount;
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

        // Engel oluşturma kodu buraya gelecek
        // Örneğin:
        GameObject newObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
        Rigidbody2D obstacleRb = newObstacle.GetComponent<Rigidbody2D>();
        obstacleRb.velocity = new Vector2(-obstacleSpeed, 0f);
    }

}
