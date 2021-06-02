using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace madyasiwi.astrajingga.ui.tests {

    public class MainMenuTests {

        [UnitySetUp]
        public IEnumerator SetUp() {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            yield return null;
        }


        static MainMenu FindMainMenu() {
            Scene scene = SceneManager.GetActiveScene();
            foreach (GameObject go in scene.GetRootGameObjects()) {
                MainMenu mainMenu = go.GetComponentInChildren<MainMenu>();
                if (mainMenu != null) {
                    return mainMenu;
                }
            }
            return null;
        }


        [UnityTest]
        public IEnumerator PlayButtonTest() {
            MainMenu mainMenu = FindMainMenu();
            Assert.IsNotNull(mainMenu);
            if (mainMenu != null) {
                Assert.IsNotNull(mainMenu.PlayButton);
                mainMenu.PlayButton.onClick?.Invoke();
                yield return null;
                Scene scene = SceneManager.GetActiveScene();
                Assert.AreEqual("InGame", scene.name);
            }
        }

        [UnityTest]
        public IEnumerator ExitButtonTest() {
            MainMenu mainMenu = FindMainMenu();
            Assert.IsNotNull(mainMenu);
            if (mainMenu != null) {
                Assert.IsNotNull(mainMenu.ExitButton);
                int v0 = mainMenu.ExitFunctionCalls;
                mainMenu.PreventStopPlaying = true;
                mainMenu.ExitButton.onClick?.Invoke();
                yield return null;
                Assert.IsTrue(mainMenu.ExitFunctionCalls > v0);
            }
        }
    }
}
