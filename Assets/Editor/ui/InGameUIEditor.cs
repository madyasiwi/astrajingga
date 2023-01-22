using UnityEditor;


namespace Madyasiwi.Astrajingga.UI.Editor {

    [CustomEditor(typeof(InGameUI))]
    public class InGameUIEditor : UnityEditor.Editor {

        InGameUI inGameUI;

        SerializedProperty menuBar;
        SerializedProperty mainMenu;
        SerializedProperty mainMenuEnabled;


        void OnEnable() {
            inGameUI = target as InGameUI;
            menuBar = serializedObject.FindProperty("menuBar");
            mainMenu = serializedObject.FindProperty("mainMenu");
            mainMenuEnabled = serializedObject.FindProperty("mainMenuEnabled");
        }


        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUILayout.PropertyField(menuBar);
            EditorGUILayout.PropertyField(mainMenu);
            EditorGUILayout.PropertyField(mainMenuEnabled);
            if (serializedObject.ApplyModifiedProperties()) {
                inGameUI.UpdateState();
            }
        }
    }
}
