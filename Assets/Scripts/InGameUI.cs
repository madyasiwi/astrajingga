using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace madyasiwi.astrajingga.ui {

    public class InGameUI : MonoBehaviour {

        [SerializeField] MenuBar menuBar;
        [SerializeField] MainMenu mainMenu;

        bool mainMenuEnabled;


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
                    UpdateComponentStates();
                }
            }
        }


        void UpdateComponentStates() {
            if (menuBar != null) {
                menuBar.gameObject.SetActive(!mainMenuEnabled);
            }
            if (mainMenu != null) {
                mainMenu.gameObject.SetActive(mainMenuEnabled);
            }
        }
    }
}
