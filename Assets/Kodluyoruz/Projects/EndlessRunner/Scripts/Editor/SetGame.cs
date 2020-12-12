using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SetGame : MonoBehaviour
{
    //This is test comment for git tik.

    [InitializeOnLoad]

    public static class PlayModeStateChangedExample
    {
        // register an event handler when the class is initialized

        static PlayModeStateChangedExample()

        {
            EditorApplication.playModeStateChanged += LogPlayModeState;

        }

        private static void LogPlayModeState(PlayModeStateChange state)
        {
            bool hasInit = false;


            if (PlayModeStateChange.EnteredPlayMode == state)
            {
                int sceneCount = SceneManager.sceneCount;

                for (int i = 0; i < sceneCount; i++)
                {

                    if (SceneManager.GetSceneAt(i).buildIndex == 0)
                    {
                        hasInit = true;

                    }
                }
                if (!hasInit)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
