using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealPlayer : MonoBehaviour
{
    public TestPlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerStats.healingPotions < 10)
            {
                playerStats.healingPotions++;
                Debug.Log("Picked up healing potion");
            }
            else return;
        }


    }
}
