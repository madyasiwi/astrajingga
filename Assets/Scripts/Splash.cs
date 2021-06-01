using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace madyasiwi.astrajingga.splash {

    /// <summary>
    /// Splash screen
    /// </summary>
    public class Splash : MonoBehaviour {

        float remainingTime;
        bool mainMenuShown;

        public bool isLoading {
            get => remainingTime > 0;
        }


        void Start() {
            remainingTime = 5.0f;
        }


        void Update() {
            if (remainingTime > 0) {
                remainingTime -= Time.deltaTime;
            } else {
                if (!mainMenuShown) {
                    mainMenuShown = true;
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                }
            }
        }
    }
}
