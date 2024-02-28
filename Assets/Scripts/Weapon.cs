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

    public void fireAtEnemy(Vector3 enemyPos, Transform playerPos)
    {
        //2d look at used from https://discussions.unity.com/t/how-do-i-rotate-a-2d-object-to-face-another-object/187072
        itemToFire = GameObject.Instantiate(projectile, playerPos);
        Vector3 targ = enemyPos;
        targ.x -= itemToFire.transform.position.x;
        targ.y -= itemToFire.transform.position.y;
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        itemToFire.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}