using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float obstacleSpeed; // Engel hareket hızı

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!gameManager.canPlay)
        {
            return;
        }
        Move();
        Destroy();
        if (obstacleSpeed > 15)
        {
            obstacleSpeed = 15;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
    }

    private void Destroy()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
