using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace madyasiwi.astrajingga.mainmenu {

    public class MainMenu : MonoBehaviour {

        [SerializeField] Button playButton;

        
        public Button PlayButton {
            get => playButton;
        }


        public void Play() {
            SceneManager.LoadScene("InGame", LoadSceneMode.Single);
        }
    }
}
