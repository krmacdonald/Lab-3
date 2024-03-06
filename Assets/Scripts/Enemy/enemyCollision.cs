using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    public Enemy myEnemy;
    private float hitCD = .5f;
    void Update()
    {
        hitCD -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hitCD < 0)
            {
                Player playerScript = other.gameObject.GetComponent<Player>();
                playerScript.health -= myEnemy.damage;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        myEnemy.OnCollisionEnter2D(other, hitCD);
        hitCD = .5f;
    }
}
