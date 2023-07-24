using Unity.VisualScripting;
using UnityEngine;

namespace Variable
{
    public abstract class _Variable : ScriptableObject
    {

    }
    public class GenericVariable<T> : _Variable, ISerializationCallbackReceiver
    {
        public void OnAfterDeserialize()
        {
            throw new System.NotImplementedException();
        }

        public void OnBeforeSerialize()
        {
            throw new System.NotImplementedException();
        }

    }
}

    


