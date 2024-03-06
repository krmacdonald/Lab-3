using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float spread = 2;

    public Shotgun(float damage, float delay, GameObject projectile, float spread) : base(damage, delay, projectile)
    {
        this.spread = spread;
        this.damage = damage;
        this.delay = delay;
        this.projectile = projectile;
    }

    public override void fireAtEnemy(Vector2 enemyPos, Transform playerPos, float uniDelay)
    {
        if (uniDelay % delay == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject itemToFire1 = GameObject.Instantiate(projectile, playerPos);
                itemToFire1.GetComponent<projectileBehavior>().damage = this.damage;
                Rigidbody2D itemRB1 = itemToFire1.GetComponent<Rigidbody2D>();
                itemRB1.AddForce((enemyPos - (Vector2)playerPos.position) * 250);
                Debug.Log("firing");
            }
        }
    }
}
