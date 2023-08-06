
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public TestPlayerStats playerStats;


    private void Start()
    {
        playerStats.healingPotions = 0;

    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.R))
        {
            UsePotion();
        }
    }



    private void Move()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY, 0f).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;


    }

    private void UsePotion()
    {
        if (playerStats.CurrentHealth > 0 && playerStats.CurrentHealth < 100 && playerStats.healingPotions > 0)
        {
            playerStats.healingPotions -= 1;
            playerStats.CurrentHealth += 11;

            Debug.Log("Used Potion");
        }
        else return;
    }

}
