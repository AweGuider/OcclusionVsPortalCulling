using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Awe.Utilities.Editor
{
    /// <summary>
    /// Hierarchy Window Group Header
    /// http://diegogiacomelli.com.br/unitytips-hierarchy-window-group-header
    /// </summary>
    [InitializeOnLoad]
    public class SceneHierarchyDivider
    {
        private static SceneHierarchyDividerSettings settingsPreset;
        private static SceneHierarchyDividerSettings SettingsPreset
        {
            get
            {
                if (settingsPreset == null)
                {
                    string[] guids = AssetDatabase.FindAssets("t:SceneHierarchyDividerSettings");
                    if (guids == null || guids.Length == 0)
                    {
                        SceneHierarchyDividerSettings lsp = (SceneHierarchyDividerSettings)ScriptableObject.CreateInstance(typeof(SceneHierarchyDividerSettings));
                        string basePath = $"Assets/Plugins/Awe/Scene Hierarchy Divider";
                        string path = $"{basePath}/DividerSettings.asset";
                        System.IO.Directory.CreateDirectory("Assets/Plugins/Awe/Scene Hierarchy Divider");
                        AssetDatabase.CreateAsset(lsp, path);
                        settingsPreset = lsp;
                        UnityEngine.Debug.LogWarning($"No Hierarchy Divider Settings Preset found, generated one at {path}");
                    }
                    else if (guids.Length > 1)
                    {
                        UnityEngine.Debug.LogWarning($"Multiple LogSettingsPresets found, only 1 is needed. Please delete unnecessary files.");
                        for (int i = 0; i < guids.Length; i++)
                        {
                            UnityEngine.Debug.LogWarning($"LogSettingsPreset {i} : {AssetDatabase.GUIDToAssetPath(guids[i])}");
                        }
                        UnityEngine.Debug.LogWarning($"Loaded: {AssetDatabase.GUIDToAssetPath(guids[0])}");
                        settingsPreset = AssetDatabase.LoadAssetAtPath<SceneHierarchyDividerSettings>(AssetDatabase.GUIDToAssetPath(guids[0]));
                    }
                    else
                    {
                        settingsPreset = AssetDatabase.LoadAssetAtPath<SceneHierarchyDividerSettings>(AssetDatabase.GUIDToAssetPath(guids[0]));
                    }
                }
                return settingsPreset;
            }
        }


        private static readonly GUIStyle labelStyle = new()
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState
            {
                textColor = Color.white
            },
            wordWrap = false,
            clipping = TextClipping.Clip
        };

        static SceneHierarchyDivider()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            // divider gameobjects
            if (gameObject != null && gameObject.name.StartsWith("-", System.StringComparison.Ordinal))
            {
                int count = gameObject.name.Count(x => x == '-');
                count = count >= SettingsPreset.backgroundColors.Length ? SettingsPreset.backgroundColors.Length : count;
                EditorGUI.DrawRect(selectionRect, SettingsPreset.backgroundColors[count-1]);               
                EditorGUI.LabelField(selectionRect, gameObject.name.Replace("-", "").ToUpperInvariant(), labelStyle);
            }
            // Empty gameobjects
            if (gameObject != null && gameObject.name.Equals(" ", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, SettingsPreset.emptyFieldColor);
            }
        }
    }
}