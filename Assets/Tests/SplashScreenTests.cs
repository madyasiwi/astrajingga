using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace madyasiwi.astrajingga.ui.tests {

    public class SplashScreenTests {

        [UnityTest]
        public IEnumerator SplashScreenTestsWithEnumeratorPasses() {
            SceneManager.LoadScene("Splash", LoadSceneMode.Single);
            yield return null;
            Scene scene = SceneManager.GetActiveScene();
            Assert.AreEqual("Splash", scene.name);

            Splash splash = null;
            foreach (GameObject go in scene.GetRootGameObjects()) {
                splash = go.GetComponent<Splash>();
                if (splash != null) {
                    break;
                }
            }
            Assert.IsNotNull(splash);
            if (splash != null) {
                DateTime start = DateTime.Now;
                while (splash.IsLoading) {
                    yield return null;
                }
                DateTime end = DateTime.Now;
                double duration = (end - start).TotalSeconds;
                Assert.IsTrue(duration > 0.9d && duration < 1.1d);

                yield return new WaitForSeconds(1.0f);

                scene = SceneManager.GetActiveScene();
                Assert.AreEqual("MainMenu", scene.name);
            }
        }
    }
}
