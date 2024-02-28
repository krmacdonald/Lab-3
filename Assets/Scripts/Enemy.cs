using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private float damage;
    private float speed;
    private float health;
    public GameObject enemyObject;

    public Enemy(float damage, float speed, GameObject enemyObject, float health)
    {
        this.damage = damage;
        this.speed = speed;
        this.enemyObject = enemyObject;
        this.health = health;
    }

    public void moveEnemy(Transform playerPos)
    {
        enemyObject.transform.position = Vector2.MoveTowards(enemyObject.transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public void checkDeath()
    {
        if(this.health < 0)
        {
            EnemyFinder enemyList = enemyObject.transform.parent.GetComponent<EnemyFinder>();
            enemyList.removeEnemy(this);
            Debug.Log("Killed");
            GameObject.Destroy(enemyObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {

        }
    }
}
