using UnityEngine;
using UnityEditor; //This is required for editor scripting

//This Scripts is allowing us to control how the inspector is displying our scruptable object.

namespace Variable
{
    [CustomEditor(typeof(BaseVariable), true)]  // (typeof(BaseVariable??)
    [CanEditMultipleObjects] // This allows us to modify multiple properties
    public class VariableEditor : Editor
    {
        private SerializedProperty _initialValue;
        private SerializedProperty _runtimeValue;
        private SerializedProperty _runtimeMode;
        private SerializedProperty _persistenceMode;

        private void OnEnable()
        {
            // When the scriptable object is made, we get a reference and setting the reference to our current field
            _initialValue = serializedObject.FindProperty("_initialValue");
            _runtimeValue = serializedObject.FindProperty("_runtimeValue");
            _runtimeMode = serializedObject.FindProperty("_runtimeMode");
            _persistenceMode = serializedObject.FindProperty("_persistenceMode");
        }

        //OnInspectorGUI is a virtual function (In the unity engine) hence, we need to override.
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            //When it changes on runtime in code, show us that change.
            //It shows us the changes in the inspector.
            serializedObject.Update();

            EditorGUILayout.PropertyField(_initialValue);
            //This displays information, but it cannot be interacted with.
            EditorGUI.BeginDisabledGroup(true);//Anything inside these two groups, can be seen but not interacted with.
            EditorGUILayout.PropertyField(_runtimeValue);
            EditorGUI.EndDisabledGroup();// <--

            EditorGUILayout.PropertyField(_runtimeMode);
            EditorGUILayout.PropertyField(_persistenceMode);


            EditorGUI.BeginDisabledGroup(_persistenceMode.boolValue == true);
            if (GUILayout.Button("Save to Initial Value"))
            {
                (target as BaseVariable).SaveToInitialValue();
            }

            EditorGUI.EndDisabledGroup();
            if (target) // target is the object being inspected.
            {
                serializedObject.ApplyModifiedProperties();
            }


        }


    }


}

