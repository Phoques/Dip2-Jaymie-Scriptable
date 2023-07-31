using UnityEngine;
using UnityEditor;



namespace Variable
{
    [CustomEditor(typeof(BaseVariable), true)]
    [CanEditMultipleObjects]
    public class VariableEditor : Editor
    {
        private SerializedProperty _initialValue;
        private SerializedProperty _runtimeValue;
        private SerializedProperty _runtimeMode;
        private SerializedProperty _presistenceMode;



        private void OnEnable()
        {
            //when script is made active, reference acquired
            //set reference to current fields
            _initialValue = serializedObject.FindProperty("_initialValue");
            _runtimeValue = serializedObject.FindProperty("_runtimeValue");
            _runtimeMode = serializedObject.FindProperty("_runtimeMode");
            _presistenceMode = serializedObject.FindProperty("_presistenceMode");
        }
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            EditorGUILayout.PropertyField(_initialValue);



            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(_runtimeValue);
            EditorGUI.EndDisabledGroup();




        }
    }
}
