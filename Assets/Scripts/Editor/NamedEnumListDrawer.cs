using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LyeJam.Editor
{
    [CustomPropertyDrawer(typeof(EnumNamedListAttribute))]
    public class NamedEnumListDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumNamedListAttribute enumNames = attribute as EnumNamedListAttribute;
            int index = System.Convert.ToInt32(property.propertyPath.Substring(property.propertyPath.IndexOf("[")).Replace("[", "").Replace("]", ""));
            if (index < enumNames.Names.Length)
            {
                label.text = enumNames.Names[index];
            }
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}
