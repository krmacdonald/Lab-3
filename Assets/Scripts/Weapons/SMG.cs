using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Weapon
{
    public SMG(float damage, float delay, GameObject projectile): base(damage, delay, projectile)
    {

    }

    public override void fireAtEnemy(Vector2 enemyPos, Transform playerPos, float uniDelay)
    {
        if (uniDelay % delay == 0)
        {
            GameObject itemToFire1 = GameObject.Instantiate(projectile, playerPos);
            Rigidbody2D itemRB1 = itemToFire1.GetComponent<Rigidbody2D>();
            itemToFire1.GetComponent<projectileBehavior>().damage = this.damage;
            itemRB1.AddForce((enemyPos - (Vector2)playerPos.position) * 250);
        }
    }
}
