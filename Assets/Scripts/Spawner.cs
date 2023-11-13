using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject coins;
    [SerializeField] float numObjects;
    [SerializeField] Transform newGround;
    [SerializeField] Transform newObstacle;
    [SerializeField] Transform newEnemy;
    [SerializeField] Transform newCoins;

    Queue<GameObject> poolGround = new Queue<GameObject>();
    Queue<GameObject> poolObstacle = new Queue<GameObject>();
    Queue<GameObject> poolEnemy = new Queue<GameObject>();
    Queue<GameObject> poolCoins = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numObjects; i++)
        {
            GameObject Grounds = Instantiate(ground);
            poolGround.Enqueue(Grounds);
            Grounds.SetActive(false);
        }

        for (int i = 0; i < numObjects; i++)
        {
            GameObject Obstacles = Instantiate(obstacle);
            poolObstacle.Enqueue(Obstacles);
            Obstacles.SetActive(false);
        }

        for (int i = 0; i < numObjects; i++)
        {
            GameObject Enemies = Instantiate(enemy);
            poolEnemy.Enqueue(Enemies);
            Enemies.SetActive(false);
        }

        for (int i = 0; i < numObjects; i++)
        {
            GameObject Coins = Instantiate(coins);
            poolCoins.Enqueue(Coins);
            Coins.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGround()
    {
        GameObject Grounds = poolGround.Dequeue();
        Grounds.SetActive(true);
        Grounds.transform.position = newGround.position;
        poolGround.Enqueue(Grounds);
    }

    public void SpawnObstacle()
    {
        GameObject Obstacles = poolObstacle.Dequeue();
        Obstacles.SetActive(true);
        Obstacles.transform.position = newObstacle.position;
        poolObstacle.Enqueue(Obstacles);
    }

    public void SpawnEnemies()
    {
        GameObject Enemies = poolEnemy.Dequeue();
        Enemies.SetActive(true);
        Enemies.transform.position = newEnemy.position;
        poolEnemy.Enqueue(Enemies);
    }

    public void SpawnCoins()
    {
        GameObject Coins = poolCoins.Dequeue();
        Coins.SetActive(true);
        Coins.transform.position = newCoins.position;
        poolCoins.Enqueue(Coins);
    }
}
