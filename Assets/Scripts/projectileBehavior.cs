using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    void Update()
    {
        this.transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
