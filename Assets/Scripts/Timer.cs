using UnityEngine;
using Variable;

public class Timer : MonoBehaviour
{
    public Float timerScriptableObject;

    private void Update()
    {
        timerScriptableObject.Value += Time.deltaTime;
    }

}
