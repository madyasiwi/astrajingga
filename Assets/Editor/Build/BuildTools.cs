using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEditor;


namespace madyasiwi.astrajingga.build {

    public static class BuildTools {

        static bool GetGitDescription(out string name, string commit="HEAD") {
            DirectoryInfo projectDir = new DirectoryInfo(Path.GetDirectoryName(Application.dataPath));
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WorkingDirectory = projectDir.FullName,
                FileName = "git",
                Arguments = $"describe --tags {commit}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            if (process.ExitCode == 0) {
                string version = process.StandardOutput.ReadToEnd();
                name = version;
                return true;
            } else {
                UnityEngine.Debug.LogError(process.StandardError.ReadToEnd());
                name = null;
                return false;
            }
        }


        [MenuItem("Build/Update Version")]
        public static void UpdateVersionNumber() {
            if (GetGitDescription(out string version)) {
                PlayerSettings.bundleVersion = version;
                UnityEngine.Debug.Log($"Version set to: {version}");
            } else {
                UnityEngine.Debug.LogError("Failed to determine version for git tags.");
            }
        }


        [MenuItem("Build/Build Player")]
        public static void BuildPlayer() {
            string[] scenes = Array.ConvertAll<EditorBuildSettingsScene, string>(EditorBuildSettings.scenes, (s) => { return s.path; });
            DirectoryInfo buildDir = new DirectoryInfo(Path.Combine(Path.GetDirectoryName(Application.dataPath), "Build", $"{PlayerSettings.productName}.exe"));
            BuildPlayerOptions options = new BuildPlayerOptions {
                targetGroup = BuildTargetGroup.Standalone,
                target = BuildTarget.StandaloneWindows,
                scenes = scenes,
                locationPathName = buildDir.FullName
            };
            BuildPipeline.BuildPlayer(options);
        }
    }
}
