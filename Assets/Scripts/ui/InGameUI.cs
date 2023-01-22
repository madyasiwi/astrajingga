using UnityEngine;


namespace Madyasiwi.Astrajingga.UI {

    public class InGameUI : MonoBehaviour {

        [SerializeField] MenuBar menuBar;
        [SerializeField] MainMenu mainMenu;

        [SerializeField] bool mainMenuEnabled;


        public MenuBar MenuBar {
            get => menuBar;
        }

        public MainMenu MainMenu {
            get => mainMenu;
        }

        public bool MainMenuEnabled {
            get => mainMenuEnabled;
            set {
                if (value != mainMenuEnabled) {
                    mainMenuEnabled = value;
                    UpdateState();
                }
            }
        }


        public void UpdateState() {
            if (menuBar != null) {
                menuBar.gameObject.SetActive(!mainMenuEnabled);
            }
            if (mainMenu != null) {
                mainMenu.gameObject.SetActive(mainMenuEnabled);
            }
        }
    }
}
