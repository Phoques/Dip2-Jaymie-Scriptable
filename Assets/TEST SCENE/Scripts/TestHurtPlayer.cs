using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHurtPlayer : MonoBehaviour
{

    public TestPlayerStats testPlayerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT");

            testPlayerStats.CurrentHealth -= 10;
        }
    }


}
