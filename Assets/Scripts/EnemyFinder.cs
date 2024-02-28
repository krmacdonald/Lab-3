using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList;

    public Transform getClosestEnemy(Transform playerPos)
    {
        if (enemyList.Count != 0)
        {
            float lowestDistance = Mathf.Infinity;
            Transform closestEnemy = null;
            foreach (GameObject i in enemyList)
            {
                float distance = Vector3.Distance(i.transform.position, playerPos.position);
                if (distance < lowestDistance)
                {
                    lowestDistance = distance;
                    closestEnemy = i.transform;
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
        foreach(Transform enemy in transform)
        {
            if(enemy.tag == "Enemy")
            {
                enemyList.Add(enemy.gameObject);
            }
        }
    }

    public void addEnemy(GameObject newEnemy)
    {
        enemyList.Add(newEnemy);
    }

    public void removeEnemy(GameObject deadEnemy)
    {
        enemyList.Remove(deadEnemy);
    }
}
