using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Scriptable Test / Player Stats")]
public class TestPlayerStats : ScriptableObject
{

    public int maxHealth = 100;
    public int healingPotions;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        healingPotions = 0;
    }

    //Properties
    //A property should always include 'value' somewhere in the setter. In this case, MaxHealth is the property, we 'get' the maxHealth value.
    // We then 'set' the maxHealth to equal a clamp of the 'value' Which is MaxHealth, which is maxHealth.
    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = Mathf.Clamp(value, 0, 100); }
    } 

    //Same with this property;
    //We have the property CurrentHealth, which we are 'getting' _currentHealth as its value.
    //and 'setting' a clamp of the 'value' which is 
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set 
        {
            _currentHealth = Mathf.Clamp(value, 0, maxHealth);
        }
    }

}
