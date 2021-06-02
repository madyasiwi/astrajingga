using System.IO;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;


namespace madyasiwi.astrajingga.build {


    public static class BuildTools {


        [MenuItem("Build/Update Version")]
        public static void Build() {
            DirectoryInfo projectDir = new DirectoryInfo(Path.GetDirectoryName(Application.dataPath));
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = projectDir.FullName;
            startInfo.FileName = "git";
            startInfo.Arguments = "describe --tags";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            if (process.ExitCode == 0) {
                string version = process.StandardOutput.ReadToEnd();
                PlayerSettings.bundleVersion = version;
                UnityEngine.Debug.Log($"Version set to: {version}");
            } else {
                UnityEngine.Debug.LogError("Failed to determine version for git tags.");
                UnityEngine.Debug.LogError(process.StandardError.ReadToEnd());
            }
        }
    }
}
