using UnityEngine;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;


namespace madyasiwi.astrajingga.build {

    public class Callbacks : ICallbacks {

        public void RunStarted(ITestAdaptor tests) {}

        public void TestStarted(ITestAdaptor test) {}

        public void TestFinished(ITestResultAdaptor result) {
            Debug.Log($"Test finished.");
        }

        public void RunFinished(ITestResultAdaptor result) {
            Debug.Log("Tests finished.");
        }
    }

    // Continuous integration scripts
    public static class CI {

        /// <summary>
        /// Run tests programmatically.
        /// </summary>
        [MenuItem("Build/Run Tests")]
        public static void RunTests() {
            var testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
            var filter = new Filter();
            filter.testMode = TestMode.PlayMode;
            var settings = new ExecutionSettings(filter);
            Debug.Log("Running tests...");
            var callbacks = new Callbacks();
            testRunnerApi.RegisterCallbacks(callbacks);
            testRunnerApi.Execute(settings);
            // testRunnerApi.UnregisterCallbacks(callbacks);
        }
    }
}