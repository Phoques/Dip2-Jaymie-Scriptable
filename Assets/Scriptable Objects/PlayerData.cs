using UnityEngine;
using UnityEngine.UI;
// The order means its at the top, but making it 1 makes it dissapear (Jaymie to help later??)
[CreateAssetMenu(fileName = "New Player Data", menuName = "Scriptable Example / Player Data", order = 0) ]
public class PlayerData : ScriptableObject
{

    public float currentHealth;
    public float maxHealth;
    

}
