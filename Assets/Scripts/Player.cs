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

    void Start()
    {
        playerWeapons = new List<Weapon>();
        enemyFinder.recompileList();
        Debug.Log(enemyFinder.getClosestEnemy(transform));
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, vertical, 0f);

        transform.position += movement * speed * Time.deltaTime;
    }

    void addWeapon(float damage, float delay, GameObject projectile)
    {
        playerWeapons.Add(new Weapon(damage, delay, projectile));
    }
}
