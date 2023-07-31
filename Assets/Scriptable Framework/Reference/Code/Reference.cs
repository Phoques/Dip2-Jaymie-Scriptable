using System;
using UnityEngine;
using Variable;

namespace Reference
{

    // Value 1, Value 2 of GenericTypes;
    public class Reference<T1, T2>
    {
        private bool _useConstant = true;

        //A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field.
        //Properties can be used as if they're public data members, but they're special methods called accessors.
        public bool UseConstant // I understand this allows a public accessor, to get and set private accessor
        {
            get { return _useConstant; }
            set { _useConstant = value; }
        }

        private T1 _constantValue;
        private T2 _constantValue2;

        //Missed a reference here, check when class is up next.

        //This is a constructor allows you to setup the class
        public Reference(T1 value)
        {
            _useConstant = true;
            _constantValue = value;

        }


    }


}
