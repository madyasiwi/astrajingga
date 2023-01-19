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


        void Start() {
            remainingTime = artificialDelay;
        }


        void Update() {
            progressBar.coverage = Mathf.Max(artificialDelay - remainingTime, 0.0f) / artificialDelay;
            if (remainingTime > 0) {
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 0) {
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                }
            }
        }
    }
}
