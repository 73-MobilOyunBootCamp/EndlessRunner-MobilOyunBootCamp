using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityToolbarExtender.Examples
{
	static class ToolbarStyles
	{
		public static readonly GUIStyle commandButtonStyle;

		static ToolbarStyles()
		{
			commandButtonStyle = new GUIStyle("Command")
			{
				fontSize = 16,
				alignment = TextAnchor.MiddleCenter,
				imagePosition = ImagePosition.ImageLeft,
				fontStyle = FontStyle.Bold
			};
		}
	}

	[InitializeOnLoad]
	public class SceneSwitchLeftButton {
		static SceneSwitchLeftButton() {
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}

        static List<SceneAsset> scenes = new List<SceneAsset>();

        static void OnToolbarGUI() {
			//You can edit here and use other projects
            GUILayout.BeginHorizontal();

            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++) {

				var scene = EditorBuildSettings.scenes[i].path;
				if (scene.Contains("Level"))
					continue;

                if (GUILayout.Button(new GUIContent(i.ToString()), ToolbarStyles.commandButtonStyle)) {
                    SceneHelper.OpenScene(EditorBuildSettings.scenes[i].path);
                }
            }

            GUILayout.EndHorizontal();
			//--------------------------------------------
        }

    }

	static class SceneHelper
	{
		static string sceneToOpen;

		public static void OpenScene(string scene)
		{
			if(EditorApplication.isPlaying)
			{
                return;
			}
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
				EditorSceneManager.OpenScene(scene);
		}
	}
}