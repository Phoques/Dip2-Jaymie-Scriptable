using UnityEngine;
using UnityEditor;
using UnityEngine.UI; // Added
using System.CodeDom.Compiler;

namespace Reference
{
    //Check Moodle for these references (IMPORTANT)

    #region Primitive Type
    [CustomPropertyDrawer(typeof(Bool))]
    [CustomPropertyDrawer(typeof(Int))]
    [CustomPropertyDrawer(typeof(Float))]
    [CustomPropertyDrawer(typeof(String))]
    [CustomPropertyDrawer(typeof(Char))]
    #endregion

    #region Unity Type
    [CustomPropertyDrawer(typeof(GameObject))]
    [CustomPropertyDrawer(typeof(Transform))]
    [CustomPropertyDrawer(typeof(Vector2))]
    [CustomPropertyDrawer(typeof(Vector3))]
    [CustomPropertyDrawer(typeof(Image))] // added

    #endregion

    public class ReferenceDrawer : PropertyDrawer
    {

        private readonly string[] _popupOptions = { "Type Value", "Scriptable Value" };

        //Check moodle for GUI Style link
        // https://docs.unity3d.com/ScriptReference/EditorStyles.html

        private GUIStyle _popupStyle;

        //Serialized property I understand will show the type?
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if(_popupStyle == null)
            {
                //This gives the 3 vertical dots that allows us to change between the popup strings above ^
                _popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);
            //This is essentially an inspector update
            EditorGUI.BeginChangeCheck();

            SerializedProperty useConstant = property.FindPropertyRelative("_useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("_constantValue");
            SerializedProperty variable = property.FindPropertyRelative("_variable");


            //These control the position of the 3 dots.
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += _popupStyle.margin.top;
            buttonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, _popupOptions, _popupStyle);
            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(position, useConstant.boolValue ? constantValue : variable, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();

            //This always must follow the BeginCheck?? Or... not? I dunno
            EditorGUI.EndChangeCheck();

        }
    }
}

