using UnityEditor;

namespace TalosNPC.UnityToolkit.GUIDesigner.Editor
{
    public static class CreateScriptUtils
    {
        [MenuItem("Assets/Create/TalosNPC/BehaviourRunner")]
        public static void CreateCodeBehaviourRunner()
        {
            string templatePath = TalosNPCSettings.instance.ScriptTemplatePath + "/CodeRunnerTemplate.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewBehaviourRunner.cs");
        }

        [MenuItem("Assets/Create/TalosNPC/EditorBehaviourRunner")]
        public static void CreateEditorBehaviourRunner()
        {
            string templatePath = TalosNPCSettings.instance.ScriptTemplatePath + "/EditorRunnerTemplate.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewEditorBehaviourRunner.cs");
        }

        [MenuItem("Assets/Create/TalosNPC/AssetBehaviourRunner")]
        public static void CreateAssetBehaviourRunner()
        {
            string templatePath = TalosNPCSettings.instance.ScriptTemplatePath + "/AssetRunnerTemplate.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewAssetBehaviourRunner.cs");
        }

        [MenuItem("Assets/Create/TalosNPC/UnityAction")]
        public static void CreateUnityAction()
        {
            string templatePath = TalosNPCSettings.instance.ScriptTemplatePath + "/UnityActionTemplate.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewUnityAction.cs");
        }

        [MenuItem("Assets/Create/TalosNPC/UnityPerception")]
        public static void CreateUnityPerception()
        {
            string templatePath = TalosNPCSettings.instance.ScriptTemplatePath + "/UnityPerceptionTemplate.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewUnityPerception.cs");
        }
    }
}
