using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    public Enemy myEnemy;

    void OnCollisionEnter2D(Collision2D other)
    {
        myEnemy.OnCollisionEnter2D(other);
    }
}
