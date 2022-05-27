using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Editor.Build
{
    public class BuildVersionProcessor : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        private const string InitialVersion = "0";

        public void OnPreprocessBuild(BuildReport report)
        {
            UpdateVersion(FindCurrentVersion());
        }

        private static string FindCurrentVersion()
        {
            // split to find string of current version
            var currentVersion = PlayerSettings.bundleVersion.Split('.');
            // if the format doesn't match, return the initial version
            return currentVersion.Length < 4 ? InitialVersion : currentVersion[3];
        }

        private static void UpdateVersion(string version)
        {
            // Parse out version number from string split
            if (int.TryParse(version, out var versionNumber))
            {
                versionNumber += 1;
                var date = DateTime.Now.ToString("yyyy.M.d");
                // Create a new string to place in to player settings
                PlayerSettings.bundleVersion = $"{date}.{versionNumber}";
                Debug.Log($"Building Version: {PlayerSettings.bundleVersion}");
            } else
            {
                throw new BuildFailedException("Unable to increment build number!");
            }
        }
    }
}