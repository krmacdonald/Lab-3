using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private RectTransform greenHealth;
    [SerializeField]
    private Player playerScript;
    
    void Update()
    {
        greenHealth.sizeDelta = new Vector2(playerScript.health, 22.6f);
    }
}
