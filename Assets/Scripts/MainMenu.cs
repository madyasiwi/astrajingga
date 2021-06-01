using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace madyasiwi.astrajingga.mainmenu {

    public class MainMenu : MonoBehaviour {

        [SerializeField] Button playButton;
        [SerializeField] Button exitButton;

        int exitFunctionCalls;

        
        public Button PlayButton {
            get => playButton;
        }

        public Button ExitButton {
            get => exitButton;
        }

        public int ExitFunctionCalls {
            get => exitFunctionCalls;
        }




        public void Play() {
            SceneManager.LoadScene("InGame", LoadSceneMode.Single);
        }


        public void Exit() {
            exitFunctionCalls++;
            Application.Quit();
        }
    }
}
