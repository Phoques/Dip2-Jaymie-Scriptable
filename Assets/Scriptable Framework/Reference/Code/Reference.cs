using System;
using UnityEngine;
using Variable;

namespace Reference
{

    // Value 1, Value 2 of GenericTypes;
    public class Reference<T1, T2>
    {
        [SerializeField] private bool _useConstant = true;

        //A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field.
        //Properties can be used as if they're public data members, but they're special methods called accessors.
       /* public bool UseConstant // I understand this allows a public accessor, to get and set private accessor
        {
            get { return _useConstant; }
            set { _useConstant = value; }
        }*/

        [SerializeField] private T1 _constantValue;
        [SerializeField] private T2 _variable;

        public Reference()
        {

        }


        //This is a constructor allows you to setup the class
        public Reference(T1 value)
        {
            _useConstant = true;
            _constantValue = value;

        }

        public T1 Value
        {
            //If the bool is true, read the constant value, else read the value from the scriptable object.


            //Read   (Shorthand)
            get => _useConstant ? _constantValue : _variable as GenericVariable<T1>;

            //   (LongHand)
            /*get
            {
                if (UseConstant == true)
                {
                    return _constantValue;
                }
                else
                {
                    return _variable as GenericVariable<T1>;
                }
            }*/



            //Write
            set   // (Long hand)
            {
                if (_useConstant)
                {
                    _constantValue = value;
                }
                else
                {
                    //Casting Generic variable, still need to define what the variable is. Can be used for any variable.
                    (_variable as GenericVariable<T1>).Value = value;
                }
            }

            //Short hand (Trying to figure it out)
            //set { if (UseConstant) _constantValue = value; else (_variable as GenericVariable<T1>).Value = value; } // ??? 

        }

         // Something something                                        => (return) reference.Value;
        public static implicit operator T1(Reference<T1, T2> reference) => reference.Value;


    }

    [Serializable] public class Bool : Reference<bool, Variable.Bool> { }
    [Serializable] public class Int : Reference<int, Variable.Int> { }
    [Serializable] public class Float : Reference<float, Variable.Float> { }
    [Serializable] public class String : Reference<string, Variable.String> { }
    [Serializable] public class Char  : Reference<char, Variable.Char> { }

    [Serializable] public class GameObject : Reference<GameObject, Variable.GameObject> { }
    [Serializable] public class Transform : Reference<Transform, Variable.Transform> { }
    [Serializable] public class Vector2 : Reference<Vector2, Variable.Vector2> { }
    [Serializable] public class Vector3 : Reference<Vector3, Variable.Vector3> { }


    
}
