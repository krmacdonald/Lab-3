using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float damage;
    public float delay;
    public GameObject projectile;
    private GameObject itemToFire;
    private Rigidbody2D itemRB;

    public Weapon(float damage, float delay, GameObject projectile)
    {
        this.damage = damage;
        this.delay = delay;
        this.projectile = projectile;
    }

    public virtual void fireAtEnemy(Vector2 enemyPos, Transform playerPos, float uniDelay)
    {
        if (uniDelay % delay == 0)
        {
            itemToFire = GameObject.Instantiate(projectile, playerPos);
            Rigidbody2D itemRB = itemToFire.GetComponent<Rigidbody2D>();
            itemToFire.GetComponent<projectileBehavior>().damage = this.damage;
            itemRB.AddForce((enemyPos - (Vector2)playerPos.position) * 250);
        }
    }
}