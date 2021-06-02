using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace madyasiwi.astrajingga.ui {

    [CustomEditor(typeof(InGameUI))]
    public class InGameUIEditor : Editor {

        InGameUI inGameUI;

        SerializedProperty menuBar;
        SerializedProperty mainMenu;


        void OnEnable() {
            inGameUI = target as InGameUI;
            menuBar = serializedObject.FindProperty("menuBar");
            mainMenu = serializedObject.FindProperty("mainMenu");
        }


        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUILayout.PropertyField(menuBar);
            EditorGUILayout.PropertyField(mainMenu);
            inGameUI.MainMenuEnabled = EditorGUILayout.Toggle("Main menu enabled", inGameUI.MainMenuEnabled);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
