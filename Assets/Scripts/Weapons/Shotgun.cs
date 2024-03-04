using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float spread = 2;

    public Shotgun(float damage, float delay, GameObject projectile, float spread) : base(damage, delay, projectile)
    {
        this.spread = spread;
    }

    public override void fireAtEnemy(Vector2 enemyPos, Transform playerPos, float uniDelay)
    {
        if (uniDelay % delay == 0)
        {
            GameObject itemToFire1 = GameObject.Instantiate(projectile, playerPos);
            GameObject itemToFire2 = GameObject.Instantiate(projectile, playerPos);
            GameObject itemToFire3 = GameObject.Instantiate(projectile, playerPos);
            Rigidbody2D itemRB1 = itemToFire1.GetComponent<Rigidbody2D>();
            Rigidbody2D itemRB2 = itemToFire2.GetComponent<Rigidbody2D>();
            Rigidbody2D itemRB3 = itemToFire3.GetComponent<Rigidbody2D>();
            itemRB1.AddForce((enemyPos - (Vector2)playerPos.position) * 250);
            itemRB2.AddForce((enemyPos - (Vector2)playerPos.position) * 250);
            itemRB3.AddForce((enemyPos - (Vector2)playerPos.position) * 250);
            Debug.Log("firing");
        }
    }
}
