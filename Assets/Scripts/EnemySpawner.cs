using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float delay;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private EnemyFinder enemyFinder;
    [SerializeField]
    private GameObject enemyFinderObject;
    [SerializeField]
    private float currentSpeed;
    [SerializeField]
    private float currentDamage;
    [SerializeField]
    private float currentHealth;
    private float delayCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayCounter += Time.deltaTime;

        if(delayCounter > delay)
        {
            spawnEnemy(currentDamage, currentSpeed, currentHealth);
            delayCounter = 0f;
        }
    }

    public void spawnEnemy(float damage, float speed, float health)
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        Vector3 toSpawn = new Vector3(Random.Range(playerX - 10, playerX + 10), Random.Range(playerY - 7, playerY + 7), 0f);
        GameObject newEnemy = GameObject.Instantiate(enemyPrefab, toSpawn, Quaternion.Euler(0, 0, 0), enemyFinderObject.transform);
        enemyFinder.addEnemy(new Enemy(damage, speed, newEnemy, health));
    }
}
