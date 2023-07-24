using UnityEngine;

public class Player1 : MonoBehaviour
{
    public PlayerData playerDataSO;

    public UiSlider uiSliderClass1;


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
        playerDataSO.currentHealth += Random.Range(-25f, 25f);

        //This clamps the players max health so the slider doesnt go beyond its max.
        playerDataSO.currentHealth = Mathf.Clamp(playerDataSO.currentHealth, 0 , playerDataSO.maxHealth);
        
        uiSliderClass1.UpdateHealthDisplay();
    }

}
