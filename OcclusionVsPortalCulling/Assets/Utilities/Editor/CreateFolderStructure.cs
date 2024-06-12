using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace Awe.Utilities
{
    public class CreateFolderStructure : EditorWindow
    {
        private static string projectName = "ProjectName";

        [MenuItem("Awe/Create Default Folders")]
        private static void SetUpFolders()
        {
            GetWindow(typeof(CreateFolderStructure));
        }
        private static void CreateAllFolders()
        {
            List<string> rootFolders = new()
            {
                "Art",
                "Audio",
                "Code",
                "Docs",
                "Level",
                "UI",
                "Video"
            };
            foreach (string folder in rootFolders)
            {
                if (!Directory.Exists("Assets/" + folder))
                {
                    Directory.CreateDirectory("Assets/" + projectName + "/" + folder);
                }
            }
            List<string> artFolders = new()
            {
                "Materials",
                "Models",
                "Textures"
            };
            foreach (string subfolder in artFolders)
            {
                if (!Directory.Exists("Assets/" + projectName + "/Art/" + subfolder))
                {
                    Directory.CreateDirectory("Assets/" + projectName + "/Art/" + subfolder);
                }
            }

            List<string> audioFolders = new()
            {
                "Music",
                "Sounds",
            };
            foreach (string subfolder in audioFolders)
            {
                if (!Directory.Exists("Assets/" + projectName + "/Audio/" + subfolder))
                {
                    Directory.CreateDirectory("Assets/" + projectName + "/Audio/" + subfolder);
                }
            }

            List<string> codeFolders = new()
            {
                "ScriptableObjects",
                "Scripts",
                "Shaders",
            };
            foreach (string subfolder in codeFolders)
            {
                if (!Directory.Exists("Assets/" + projectName + "/Code/" + subfolder))
                {
                    Directory.CreateDirectory("Assets/" + projectName + "/Code/" + subfolder);
                }
            }

            List<string> levelFolders = new()
            {
                "Prefabs",
                "Scenes"
            };
            foreach (string subfolder in levelFolders)
            {
                if (!Directory.Exists("Assets/" + projectName + "/Level/" + subfolder))
                {
                    Directory.CreateDirectory("Assets/" + projectName + "/Level/" + subfolder);
                }
            }

            AssetDatabase.Refresh();
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Insert the Project name used as the root folder");
            projectName = EditorGUILayout.TextField("Project Name: ", projectName);
            this.Repaint();
            GUILayout.Space(30);
            if (GUILayout.Button("Generate!"))
            {
                CreateAllFolders();
                this.Close();
            }
        }
    }
}