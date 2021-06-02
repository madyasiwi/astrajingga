using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace madyasiwi.astrajingga.ui {

    [CustomEditor(typeof(MenuBar))]
    public class MenuBarEditor : Editor {

        SerializedProperty menuButton;
        SerializedProperty onShowMenu;


        void OnEnable() {
            menuButton = serializedObject.FindProperty("menuButton");
            onShowMenu = serializedObject.FindProperty("onShowMenu");
        }


        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUILayout.PropertyField(menuButton);
            EditorGUILayout.PropertyField(onShowMenu);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
