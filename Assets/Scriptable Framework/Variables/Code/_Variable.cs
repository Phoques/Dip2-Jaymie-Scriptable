using Unity.VisualScripting;
using UnityEngine;

//To access any script from this family outside of a class that is part of the namespace, will require you to use this namespace / family.
namespace Variable
{

    //The Abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
    public abstract class _Variable : ScriptableObject
    {
        //our base class has 3 behaviours in it that we can ovveride later.

        public abstract void SaveToInitialValue();

        public abstract void ToggleRuntimePersistance();

        public abstract void ToggleRuntimeMode();

    }
    // Generic Variable <T> means TYPE.
    public class GenericVariable<T> : _Variable, ISerializationCallbackReceiver
    {
        //Comma seperated list of identifiers is an enum.
        //A word with a number (enum index)
        public enum RuntimeMode
        { //You can add an index value if you want like below, but it isn't reccommended.
            ReadOnly = 0,
            ReadWrite = 1
        }

        public enum PersistenceMode
        {
            None,
            Persist
        }

        [SerializeField] private T _initialValue;
        [SerializeField] private T _runtimeValue;
        [SerializeField] private RuntimeMode _runtimeMode;
        [SerializeField] private PersistenceMode _persistenceMode;

        //Lambda, persistance, will be true, if, persistenceMode is == to PersistenceMode.Persist; and if not then its false;
        //The private bool _persistence is true, when _persistenceMode's vale, is equal to PersistenceMode.Persist.
        private bool _persistence => _persistenceMode == PersistenceMode.Persist;


        public T Value
        {
            //if _persistence is true, return _initialValue, else return _runtimeValue;
            get => (_persistence) ? _initialValue : _runtimeValue;

            //This is the long written equiv.
            /*get
            {
                if (_persistence)
                {
                    return _initialValue;
                }
                else
                {
                    return _runtimeValue;
                }
            }*/

            set
            {
                //When setting our values we have two situations controlled by runtimeMode
                switch (_runtimeMode)
                {
                    case RuntimeMode.ReadOnly:
                        Debug.LogWarning($"Attempted to set read only variable", this);
                        break;

                    case RuntimeMode.ReadWrite:
                        if (_persistence)
                        {
                            _initialValue = value;
                        }
                        else
                        {
                            _runtimeValue = value;
                        }
                        break;

                    default:
                        Debug.LogError($"Runtime mode switch defaulted", this);
                        break;
                }
            }
        }

        //Implicit or explicit keywords to define an implicit or explicit conversion.
        //This is going to calculate and convert the generic type into a variable.
        //operator is like +, = , *, / 
        //
        public static implicit operator T(GenericVariable<T> variable)
        {
            return variable.Value;
        }

        public void OnAfterDeserialize()
        {
            //If the data is not persistant, retur the runtime value back to the initial value;
            //As the runtime value is the value that changes during run time
            //And a common problem of scriptable objects is that it doesnt reset its value when in the editor when you restart
            //We are putting the functionality in that if the data is no persistant then we load to a new scene or get out of playmode.
            //Then we set the runtime value back to the initial value.

            //NOTE: if the data is persistant then this does not happen.

            if (!_persistence)
            {
                _runtimeValue = _initialValue;
            }
        }

        public void OnBeforeSerialize()
        {
            // We are not using this, which is called before the object the interface is attached to is serialized.
            //This is empty as we are not using it, but it has to exist because we have the onAfterDeserialize
        }

        public override void SaveToInitialValue()
        {
            _initialValue = _runtimeValue;
        }

        public override void ToggleRuntimeMode()
        {
            _runtimeMode = (_runtimeMode == 0) ? (RuntimeMode) 1 : 0;

            //Here is the long version
            //If _runtimeMode (which is the enum variable) is == 0 index, (Which it is normally)
            //RuntimeMode (enum) is 1, which is the Read.Write. (ReadWrite is index 1 in the enum)
            /*if (_runtimeMode == 0)
            {
                _runtimeMode = RuntimeMode.ReadWrite;
            }
            else
            {
                _runtimeMode = RuntimeMode.ReadOnly;
            }*/
        }

        public override void ToggleRuntimePersistance()
        {
            //This reference to the enum, is equal to: if _persistenceMode is equal to 0, then _persistenceMode (the enum) is index 1, which is persistent.
            // else, if _persisenceMode is not equal to 0, then it is 0. Basically, swap them.
            _persistenceMode = (_persistenceMode == 0) ? (PersistenceMode) 1 : 0;
        }
    }


}




