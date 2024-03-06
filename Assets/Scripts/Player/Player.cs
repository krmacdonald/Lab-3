using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float health = 100;
    private float horizontal;
    private float vertical;

    //Leveling vars, not used
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
    private string equipped = "pistol";

    //Handles the UI switching
    [SerializeField]
    private Sprite[] hudSprites;
    [SerializeField]
    private Image uiPart;

    void Start() {
        playerWeapons = new List<Weapon>();
        playerWeapons.Add(new Weapon(4, 2, projectilePrefab));
        playerWeapons.Add(new Shotgun(8, 3, projectilePrefab, 2));
        playerWeapons.Add(new SMG(2, 1, projectilePrefab));
    }

    void Update()
    {
        if(health < 0)
        {
            SceneManager.LoadScene("Title");
        }

        //calculates the movement based on input and changes the transform
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement * speed * Time.deltaTime;

        //keeps track of the delay between weapons firing
        fireCounter += Time.deltaTime;

        //lets the player change their current weapon
        if (Input.GetKeyDown("1"))
        {
            equipped = "pistol";
            uiPart.sprite = hudSprites[0];
        }else if (Input.GetKeyDown("2"))
        {
            equipped = "shotgun";
            uiPart.sprite = hudSprites[1];
        }
        else if (Input.GetKeyDown("3"))
        {
            equipped = "smg";
            uiPart.sprite = hudSprites[2];
        }

        //fires the weapon if a new clock tick is present
        if(Mathf.RoundToInt(fireCounter) != lastFired)
        {
                if (enemyFinder.getClosestEnemy(transform) != null)
                {
                    if (equipped == "pistol")
                    {
                        playerWeapons[2].fireAtEnemy(enemyFinder.getClosestEnemy(transform).position, transform, Mathf.RoundToInt(fireCounter));
                    }else if(equipped == "shotgun")
                    {
                        playerWeapons[0].fireAtEnemy(enemyFinder.getClosestEnemy(transform).position, transform, Mathf.RoundToInt(fireCounter));
                    }
                    else if(equipped == "smg")
                    {
                        playerWeapons[1].fireAtEnemy(enemyFinder.getClosestEnemy(transform).position, transform, Mathf.RoundToInt(fireCounter));
                    }
                    lastFired = Mathf.RoundToInt(fireCounter);
            }
        }

        //keeps the player in bounds since the player is a trigger
        if(transform.position.y > 12.7f)
        {
            transform.position -= new Vector3(0, .1f, 0);
        }
        else if(transform.position.y < -21.4)
        {
            transform.position += new Vector3(0, .1f, 0);
        }
        if(transform.position.x > 26.3)
        {
            transform.position -= new Vector3(.1f, 0, 0);
        }
        else if(transform.position.x < -19.3)
        {
            transform.position += new Vector3(.1f, 0, 0);
        }

    }


    void addWeapon(float damage, float delay, GameObject projectile)
    {
        playerWeapons.Add(new Weapon(damage, delay, projectile));
    }
}
