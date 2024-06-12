using UnityEngine;

namespace Awe.Utilities
{
    [CreateAssetMenu(fileName = "DividerSettings", menuName = "Awe/Scene Hierarchy Divider/Settings Preset", order = 1)]
    public class SceneHierarchyDividerSettings : ScriptableObject
	{
        public Color emptyFieldColor = new Color(0.215f, 0.215f, 0.215f, 1); //Default Unity Pro background color

        public Color[] backgroundColors =
        {
            new Color(0.584f, 0.647f, 0.650f, 1f), //gray
            new Color(0.160f, 0.501f, 0.725f, 1f), //blue
            new Color(0.086f, 0.627f, 0.521f, 1f), //green
            new Color(0.945f, 0.768f, 0.058f, 1f), //yellow
            new Color(0.901f, 0.494f, 0.133f, 1f), //orange
            new Color(0.843f, 0.188f, 0.192f, 1f), //red
            new Color(0.607f, 0.349f, 0.714f, 1f), //purple
            new Color(0.925f, 0.941f, 0.945f, 1f), //white
            new Color(0.204f, 0.286f, 0.380f, 1f) //dark
        };
    }
}