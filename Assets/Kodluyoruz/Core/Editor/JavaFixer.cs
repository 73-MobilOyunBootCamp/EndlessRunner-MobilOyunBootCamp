using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[InitializeOnLoad]
public static class JavaFixer 
{
    static JavaFixer()
    {
        string newJDKPath = string.Empty;

        if(SystemInfo.operatingSystem.Contains("Windows"))
            newJDKPath = EditorApplication.applicationPath.Replace("Unity.exe", "Data/PlaybackEngines/AndroidPlayer/OpenJDK");
        else if(SystemInfo.operatingSystem.Contains("Mac"))
            newJDKPath = EditorApplication.applicationPath.Replace("Unity.app", "PlaybackEngines/AndroidPlayer/OpenJDK");

        if (string.IsNullOrEmpty(newJDKPath))
            return;

        if (Environment.GetEnvironmentVariable("JAVA_HOME") != newJDKPath)
        {
            Environment.SetEnvironmentVariable("JAVA_HOME", newJDKPath);
        }
    }
}
