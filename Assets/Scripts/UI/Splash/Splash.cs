using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


namespace madyasiwi.astrajingga.ui {

    /// <summary>
    /// Splash screen
    /// </summary>
    public class Splash : MonoBehaviour {

        public float artificialDelay = 1.0f; // For development
        private float remainingTime;
        private ProgressBar progressBar;


        public bool IsLoading {
            get => remainingTime > 0;
        }


        void Awake() {
            progressBar = GetComponentInChildren<ProgressBar>();
        }


        void OnEnable() {
            progressBar.fraction = 0.0f;
        }


        void Start() {
            remainingTime = artificialDelay;
        }


        void Update() {
            if (remainingTime > 0) {
                remainingTime = Mathf.Max(0.0f, remainingTime - Time.deltaTime);
                progressBar.fraction = Mathf.Max(artificialDelay - remainingTime, 0.0f) / artificialDelay;
                if (remainingTime <= 0) {
                    Debug.Log(progressBar.fraction);
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                }
            }
        }


        void OnDisable() {
            progressBar.fraction = 1.0f;
        }
    }
}
