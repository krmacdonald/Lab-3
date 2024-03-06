using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public float damage;
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

    public void OnCollisionEnter2D(Collision2D other, float hitCD)
    {
        if (other.gameObject.tag == "Projectile")
        {
            projectileBehavior bullet = other.gameObject.GetComponent<projectileBehavior>();
            this.health -= bullet.damage;
            enemyObject.GetComponent<AudioSource>().pitch = Random.Range(1.0f, 2.0f);
            enemyObject.GetComponent<AudioSource>().Play();
            GameObject.Destroy(other.gameObject);
        }
    }
}
