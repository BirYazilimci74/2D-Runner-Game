using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private ObstacleSpawner obstacleSpawner;
    public float obstacleSpeed; // Engel hareket hızı
    private float speedDecreaseAmount = 0.2f;

    private void Awake()
    {
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
    }

    void Update()
    {
        if (!GameManager.Instance.canPlay)
        {
            return;
        }
        Move();
        Destroy();
        IncreaseSpeed();
    }

    private void IncreaseSpeed()
    {
        if (obstacleSpeed > 15)
        {
            obstacleSpeed = 15;
        }
        if (obstacleSpawner.obsCounter%2 == 0)
        {
            obstacleSpeed += speedDecreaseAmount;
            Debug.Log(obstacleSpeed);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime,Space.Self);
    }

    private void Destroy()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
