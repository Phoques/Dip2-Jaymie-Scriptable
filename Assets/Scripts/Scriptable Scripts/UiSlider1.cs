using UnityEngine;
using UnityEngine.UI;

public class UiSlider1 : MonoBehaviour
{
    private Player1 playerClass1;
    [SerializeField] private Slider healthBar1;
    public PlayerData playerDataSO;


    public void UpdateHealthDisplay()
    {//Mathf.Clamp01 clamps a value between 0 and 1, in the case of a slider there is only 0 & 1.
        //We then divide by max health to get the value, e.g 100 / 100 is 1.
        healthBar1.value = Mathf.Clamp01(playerDataSO.currentHealth/playerDataSO.maxHealth);
    }


}
