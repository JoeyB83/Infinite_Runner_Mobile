using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject coins;
    [SerializeField] Transform spawnerPoint;    
    [SerializeField] float distanceBetween;
    float groundWidth;

    float timeCounter;
    float timeRef = 1.5f;
    
    public Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        groundWidth = ground.transform.localScale.x;
        AudioManager.instance.PlayMusic(1);
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (transform.position.x < spawnerPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + groundWidth + distanceBetween, transform.position.y, transform.position.z);            
            spawner.SpawnGround();
            spawner.SpawnObstacle();
            if (Timer())
            {
                spawner.SpawnEnemies();
            }
            spawner.SpawnCoins();
        }
    }
    
    bool Timer()
    {       

        if (timeCounter > timeRef)
        {
            return true;
        }

        return false;
    }
}
