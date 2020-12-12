using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



[InitializeOnLoad]
public static class SetGame
=======
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class SetGame : MonoBehaviour
{


[InitializeOnLoad]
public static class PlayModeStateChangedExample
>>>>>>> Stashed changes
{
    // register an event handler when the class is initialized

    static SetGame()
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

                if (SceneManager.GetSceneAt(i).buildIndex == 0 )
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
<<<<<<< Updated upstream

=======
}
>>>>>>> Stashed changes
