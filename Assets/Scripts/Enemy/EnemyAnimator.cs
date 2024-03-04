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

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
