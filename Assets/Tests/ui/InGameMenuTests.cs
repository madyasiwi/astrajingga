using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace madyasiwi.astrajingga.ui.tests {

    public class InGameMenuTests {

        [UnitySetUp]
        public IEnumerator SetUp() {
            SceneManager.LoadScene("InGame", LoadSceneMode.Single);
            yield return null;
        }


        static InGameUI FindInGameUI() {
            Scene scene = SceneManager.GetActiveScene();
            foreach (GameObject go in scene.GetRootGameObjects()) {
                InGameUI ui = go.GetComponentInChildren<InGameUI>();
                if (ui != null) {
                    return ui;
                }
            }
            return null;
        }


        [UnityTest]
        public IEnumerator InGameMenuButtonTest() {
            InGameUI ui = FindInGameUI();
            Assert.IsNotNull(ui);
            Assert.IsNotNull(ui.MenuBar);
            Assert.IsNotNull(ui.MainMenu);
            Assert.IsTrue(ui.MenuBar.gameObject.activeInHierarchy);
            Assert.IsFalse(ui.MainMenu.gameObject.activeInHierarchy);
            ui.MenuBar.MenuButton.onClick?.Invoke();
            yield return null;
            Assert.IsTrue(ui.MainMenu.gameObject.activeInHierarchy);
            Assert.IsFalse(ui.MenuBar.gameObject.activeInHierarchy);
            ui.MainMenu.ResumeButton.onClick?.Invoke();
            yield return null;
            Assert.IsTrue(ui.MenuBar.gameObject.activeInHierarchy);
            Assert.IsFalse(ui.MainMenu.gameObject.activeInHierarchy);
        }
    }
}
