using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace madyasiwi.astrajingga.ui {

    public class MainMenu : MonoBehaviour {

        [SerializeField] Button playButton;
        [SerializeField] Button resumeButton;
        [SerializeField] Button exitButton;

        [SerializeField] UnityEvent onResume;

        [SerializeField] bool isInGame;

        int exitFunctionCalls;


        public Button PlayButton {
            get => playButton;
        }

        public Button ResumeButton {
            get => resumeButton;
        }

        public Button ExitButton {
            get => exitButton;
        }

        public int ExitFunctionCalls {
            get => exitFunctionCalls;
        }

        // Useful for tests
        public bool PreventStopPlaying { get; set; }


        public void UpdateState() {
            if (playButton != null) {
                playButton.gameObject.SetActive(!isInGame);
            }
            if (resumeButton != null) {
                resumeButton.gameObject.SetActive(isInGame);
            }
        }


        public void Play() {
            SceneManager.LoadScene("InGame", LoadSceneMode.Single);
        }


        public void Resume() {
            onResume?.Invoke();
        }


        public void Exit() {
            exitFunctionCalls++;
#if UNITY_EDITOR
            if (!PreventStopPlaying) {
                EditorApplication.isPlaying = false;
            }
#else
            Application.Quit();
#endif
        }
    }
}
