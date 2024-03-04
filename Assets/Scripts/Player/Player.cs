using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float horizontal;
    private float vertical;

    //Leveling vars
    public float exp;
    public float level;
    public float expNeeded;
    [SerializeField]
    private float[] expValues;

    //Movement vector
    private Vector3 movement;

    //List that holds weapons
    private List<Weapon> playerWeapons;
    [SerializeField]
    private EnemyFinder enemyFinder;
    [SerializeField]
    private GameObject projectilePrefab;
    private float fireCounter; //ups every second, checks if modulus is fire rate
    private float lastFired = 1000;

    void Start() {
        playerWeapons = new List<Weapon>();
        playerWeapons.Add(new Weapon(2, 2, projectilePrefab));
        playerWeapons.Add(new Shotgun(2, 3, projectilePrefab, 2));
        playerWeapons.Add(new SMG(1, 1, projectilePrefab));
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, vertical, 0f);

        transform.position += movement * speed * Time.deltaTime;

        fireCounter += Time.deltaTime;
 
        if(Mathf.RoundToInt(fireCounter) != lastFired)
        {
            foreach (Weapon w in playerWeapons)
            {
                if (enemyFinder.getClosestEnemy(transform) != null)
                {
                    w.fireAtEnemy(enemyFinder.getClosestEnemy(transform).position, transform, Mathf.RoundToInt(fireCounter));
                    lastFired = Mathf.RoundToInt(fireCounter);
                    Debug.Log("trying to fire");
                }
            }
        }

    }

    void addWeapon(float damage, float delay, GameObject projectile)
    {
        playerWeapons.Add(new Weapon(damage, delay, projectile));
    }
}
