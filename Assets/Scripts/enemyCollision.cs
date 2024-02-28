using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    private Enemy myEnemy;



    void OnCollisionEnter(Collision other)
    {
        myEnemy.OnCollisionEnter(other);
    }
}
