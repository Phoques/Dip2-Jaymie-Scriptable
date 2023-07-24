using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerCurrentHealth = 100f;
    public float maxHealth = 100f;

    public UiSlider uiSliderClass;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnhealthChange();
        }
    }



    public void OnhealthChange()
    {
        //Add or remove health value;
        playerCurrentHealth += Random.Range(-25f, 25f);

        //This clamps the players max health so the slider doesnt go beyond its max.
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0 , maxHealth);
        //uiSliderClass.UpdateHealthDisplay();
    }

}
