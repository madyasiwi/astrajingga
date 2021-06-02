using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace madyasiwi.astrajingga.ui {

    [CustomEditor(typeof(MainMenu))]
    public class MainMenuEditor : Editor {

        MainMenu mainMenu;
        SerializedProperty playButton;
        SerializedProperty resumeButton;
        SerializedProperty exitButton;
        SerializedProperty onResume;


        void OnEnable() {
            mainMenu = target as MainMenu;
            playButton = serializedObject.FindProperty("playButton");
            resumeButton = serializedObject.FindProperty("resumeButton");
            exitButton = serializedObject.FindProperty("exitButton");
            onResume = serializedObject.FindProperty("onResume");
        }


        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUILayout.PropertyField(playButton);
            EditorGUILayout.PropertyField(resumeButton);
            EditorGUILayout.PropertyField(exitButton);
            EditorGUILayout.PropertyField(onResume);
            mainMenu.IsInGame = EditorGUILayout.Toggle("Is in-game", mainMenu.IsInGame);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
