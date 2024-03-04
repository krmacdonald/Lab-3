using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used by the player to find enemies, also calls the move function for the enemies

public class EnemyFinder : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemyList;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        enemyList = new List<Enemy>();
    }

    void Update()
    {
        if (enemyList.Count != 0)
        {
            foreach (Enemy toMove in enemyList)
            {
                toMove.moveEnemy(player.transform);
                toMove.checkDeath();
            }
        }
    }

    public Transform getClosestEnemy(Transform playerPos)
    {
        if (enemyList.Count != 0)
        {
            float lowestDistance = Mathf.Infinity;
            Transform closestEnemy = null;
            foreach (Enemy i in enemyList)
            {
                float distance = Vector3.Distance(i.enemyObject.transform.position, playerPos.position);
                if (distance < lowestDistance)
                {
                    lowestDistance = distance;
                    closestEnemy = i.enemyObject.transform;
                }
            }
            return closestEnemy;
        }
        else
        {
            return null;
        }

    }

    public void recompileList()
    {
        enemyList.Clear();
    }

    public Enemy addEnemy(Enemy newEnemy)
    {
        enemyList.Add(newEnemy);
        return newEnemy;
    }

    public void removeEnemy(Enemy deadEnemy)
    {
        enemyList.Remove(deadEnemy);
    }
}
