using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace madyasiwi.astrajingga.ui {

    public class MenuBar : MonoBehaviour {

        [SerializeField] Button menuButton;
        [SerializeField] UnityEvent onShowMenu;


        public Button MenuButton {
            get => menuButton;
        }


        public void ShowMenu() {
            onShowMenu?.Invoke();
        }
    }
}
