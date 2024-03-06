using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField]
    private Sprite[] enemySprites;
    private float counter;
    [SerializeField]
    private float delay;
    private SpriteRenderer Sprite;
    private int currentIndex;
    private float damageCD = 0;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        damageCD -= Time.deltaTime;
        if(damageCD < 0)
        {
            Sprite.color = new Color(255, 255, 255);
        }
        else
        {
            Sprite.color = new Color(255, 0, 0);
        }
        counter += Time.deltaTime;
        if (counter > delay)
        {
            if(currentIndex > 2)
            {
                currentIndex = 0;
                Sprite.sprite = enemySprites[currentIndex];
                counter = 0;
            }
            else
            {
                currentIndex += 1;
                Sprite.sprite = enemySprites[currentIndex];
                counter = 0;
            }
        }
    }

    private void dealDamage()
    {
        damageCD = .2f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            dealDamage();
        }
    }
}
