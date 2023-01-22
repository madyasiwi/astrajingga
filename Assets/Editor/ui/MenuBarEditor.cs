using UnityEditor;


namespace Madyasiwi.Astrajingga.UI.Editor {

    [CustomEditor(typeof(MenuBar))]
    public class MenuBarEditor : UnityEditor.Editor {

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
