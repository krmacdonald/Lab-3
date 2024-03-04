using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    private float destroyTimer = 2;
    private float destroyCounter = 0;
    public float damage;

    void Update()
    {
        destroyCounter += Time.deltaTime;
        if(destroyCounter > destroyTimer)
        {
            Destroy(this.gameObject);
        }
    }
}
