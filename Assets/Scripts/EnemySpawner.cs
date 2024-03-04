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
        int spawnSide = Random.Range(0, 4);
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        Vector3 toSpawn;

        switch (spawnSide)
        {
            case 0: //Top
                toSpawn = new Vector3(Random.Range(playerX - 10, playerX + 10), playerY + 10, 0f);
                break;
            case 1: //Left
                toSpawn = new Vector3(playerX - 10, Random.Range(playerY - 10, playerY + 10), 0f);
                break;
            case 2: //Bottom
                toSpawn = new Vector3(Random.Range(playerX - 10, playerX + 10), playerY - 10, 0f);
                break;
            case 3: //Right
                toSpawn = new Vector3(playerX + 10, Random.Range(playerY - 10, playerY + 10), 0f);
                break;
            default:
                toSpawn = new Vector3(0, playerX + 10f, 0);
                break;
        }

        GameObject newEnemy = GameObject.Instantiate(enemyPrefab, toSpawn, Quaternion.Euler(0, 0, 0), enemyFinderObject.transform);
        Enemy createdEnemy = enemyFinder.addEnemy(new Enemy(damage, speed, newEnemy, health));
        newEnemy.GetComponent<enemyCollision>().myEnemy = createdEnemy;
    }
}
