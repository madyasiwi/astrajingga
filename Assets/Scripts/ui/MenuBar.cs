using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Madyasiwi.Astrajingga.UI {

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
