using UnityEditor;

namespace Synith
{
    public static class CreateScriptTemplates
    {
        [MenuItem("Assets/Create/Code/MonoBehaviour", priority = 40)]
        public static void CreateMonoBehaviourMenuItem()
        {
            string templatePath = "Assets/Editor/ScriptTemplates/MonoBehaviour.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScript.cs");
        }


        [MenuItem("Assets/Create/Code/Class", priority = 41)]
        public static void CreateClassMenuItem()
        {
            string templatePath = "Assets/Editor/ScriptTemplates/Class.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewClass.cs");
        }


        [MenuItem("Assets/Create/Code/Enum", priority = 42)]
        public static void CreateEnumMenuItem()
        {
            string templatePath = "Assets/Editor/ScriptTemplates/Enum.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewEnum.cs");
        }


        [MenuItem("Assets/Create/Code/Struct", priority = 43)]
        public static void CreateStructMenuItem()
        {
            string templatePath = "Assets/Editor/ScriptTemplates/Struct.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewStruct.cs");
        }


        [MenuItem("Assets/Create/Code/ScriptableObject", priority = 44)]
        public static void CreateScriptableObjectMenuItem()
        {
            string templatePath = "Assets/Editor/ScriptTemplates/ScriptableObject.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScriptableObject.cs");
        }

        [MenuItem("Assets/Create/Code/Singleton", priority = 45)]
        public static void CreateSingletonMenuItem()
        {
            string templatePath = "Assets/Editor/ScriptTemplates/Singleton.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewSingleton.cs");
        }
    }
}
