using UnityEditor;


namespace madyasiwi.astrajingga.ui.editor {

    [CustomEditor(typeof(MainMenu))]
    public class MainMenuEditor : Editor {

        MainMenu mainMenu;
        SerializedProperty playButton;
        SerializedProperty resumeButton;
        SerializedProperty exitButton;
        SerializedProperty onResume;
        SerializedProperty isInGame;


        void OnEnable() {
            mainMenu = target as MainMenu;
            playButton = serializedObject.FindProperty("playButton");
            resumeButton = serializedObject.FindProperty("resumeButton");
            exitButton = serializedObject.FindProperty("exitButton");
            onResume = serializedObject.FindProperty("onResume");
            isInGame = serializedObject.FindProperty("isInGame");
        }


        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUILayout.PropertyField(playButton);
            EditorGUILayout.PropertyField(resumeButton);
            EditorGUILayout.PropertyField(exitButton);
            EditorGUILayout.PropertyField(onResume);
            EditorGUILayout.PropertyField(isInGame);
            if (serializedObject.ApplyModifiedProperties()) {
                mainMenu.UpdateState();
            }
        }
    }
}
