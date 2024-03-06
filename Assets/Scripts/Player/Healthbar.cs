using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private RectTransform greenHealth;
    [SerializeField]
    private Player playerScript;
    

    // Update is called once per frame
    void Update()
    {
        greenHealth.sizeDelta = new Vector2(playerScript.health, 100);
    }
}
