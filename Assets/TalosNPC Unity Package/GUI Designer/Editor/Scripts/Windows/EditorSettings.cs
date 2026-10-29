using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalosNPC.UnityToolkit.GUIDesigner.Editor
{
    [InitializeOnLoad]
    public static class EditorSettings
    {
        static EditorSettings()
        {
            EditorApplication.playModeStateChanged += RefreshBehaviourEditorWindow;
            EditorSceneManager.sceneOpened += ClearBehaviourWindow;
            TalosNPCSettings.instance.ReloadAssemblies();
        }

        private static void ClearBehaviourWindow(Scene scene, OpenSceneMode mode)
        {
            if (BehaviourSystemEditorWindow.instance != null)
                BehaviourSystemEditorWindow.instance.OnChangeOpenScene();
        }

        static void RefreshBehaviourEditorWindow(PlayModeStateChange playModeStateChange)
        {
            if (BehaviourSystemEditorWindow.instance != null)
                BehaviourSystemEditorWindow.instance.OnChangePlayModeState(playModeStateChange);
        }


    }
}
