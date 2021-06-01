using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace madyasiwi.astrajingga.mainmenu.tests {

    public class MainMenuTests {

        [UnityTest]
        public IEnumerator MainMenuTest() {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            yield return null;
            Scene scene = SceneManager.GetActiveScene();
            MainMenu mainMenu = null;
            foreach (GameObject go in scene.GetRootGameObjects()) {
                mainMenu = go.GetComponentInChildren<MainMenu>();
                if (mainMenu != null) {
                    break;
                }
            }
            Assert.IsNotNull(mainMenu);
            if (mainMenu != null) {
                Assert.IsNotNull(mainMenu.PlayButton);
                mainMenu.PlayButton.onClick?.Invoke();
                yield return null;
                scene = SceneManager.GetActiveScene();
                Assert.AreEqual("InGame", scene.name);
            }
        }
    }
}
