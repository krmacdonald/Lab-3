using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] spriteArray;
    [SerializeField]
    private float delayBetween;
    [SerializeField]
    private SpriteRenderer playerSprite;
    private float counter;
    private int currentIndex;
    private string lastDir = "Down";
    private float hitCD = 0;

    void Start()
    {
        playerSprite = this.GetComponent<SpriteRenderer>();
    }

    // 0 - 3 down
    // 4 - 7 left
    // 8 - 11 right
    // 12 - 15 up
    void Update()
    {
        hitCD -= Time.deltaTime;
        counter += Time.deltaTime;
        if(hitCD < 0)
        {
            playerSprite.color = new Color(255, 255, 255);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerSprite.sprite = spriteArray[currentIndex + 8];
            lastDir = "Right";
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerSprite.sprite = spriteArray[currentIndex + 4];
            lastDir = "Left";
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerSprite.sprite = spriteArray[currentIndex + 12];
            lastDir = "Up";
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            playerSprite.sprite = spriteArray[currentIndex];
            lastDir = "Down";
        }
        else
        {
            switch (lastDir)
            {
                case "Down":
                    playerSprite.sprite = spriteArray[0];
                    break;
                case "Up":
                    playerSprite.sprite = spriteArray[12];
                    break;
                case "Left":
                    playerSprite.sprite = spriteArray[4];
                    break;
                case "Right":
                    playerSprite.sprite = spriteArray[8];
                    break;
                default:
                    playerSprite.sprite = spriteArray[0];
                    break;
            }
        }

        if (counter > delayBetween)
        {
            if (currentIndex == 3)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex += 1;
            }
            counter = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerSprite.color = new Color(255, 0, 0);
            hitCD = .2f;

        }
    }
}
