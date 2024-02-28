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

    public void fireAtEnemy(Vector2 enemyPos, Transform playerPos, float uniDelay)
    {
        if (uniDelay % delay == 0)
        {
            //2d look at used from https://discussions.unity.com/t/how-do-i-rotate-a-2d-object-to-face-another-object/187072
            itemToFire = GameObject.Instantiate(projectile, playerPos);
            Rigidbody2D itemRB = itemToFire.GetComponent<Rigidbody2D>();
            itemRB.AddForce(enemyPos * 100);
            Debug.Log("firing");
        }
    }
}