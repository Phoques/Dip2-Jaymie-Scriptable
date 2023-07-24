using UnityEngine;
using UnityEngine.UI;

public class UiSlider : MonoBehaviour
{
    public Player playerClass;
    public Slider healthBar;



    private void Start()
    {
        playerClass = FindObjectOfType<Player>();
    }

    public void UpdateHealthDisplay()
    {//Mathf.Clamp01 clamps a value between 0 and 1, in the case of a slider there is only 0 & 1.
        //We then divide by max health to get the value, e.g 100 / 100 is 1.
        healthBar.value = Mathf.Clamp01(playerClass.playerCurrentHealth/playerClass.maxHealth);
    }


}
