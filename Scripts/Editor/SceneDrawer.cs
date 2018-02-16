using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Linq;

[CustomPropertyDrawer(typeof(SceneAttribute))]
public class SceneDrawer: PropertyDrawer
{
    public int selectedIndex;

    SceneAttribute sceneAttribute { get { return ((SceneAttribute)attribute); } }

    #region ToOverride
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property) * 2;
    }

    public override void OnGUI(Rect rectBase, SerializedProperty property, GUIContent label)
    {
        // define space for elements
        Rect rectPopup = rectBase;
        Rect rectLabel = rectBase;
        rectPopup.xMin += 120f;
        // rectLabel.y += 20f;
        // rectPopup.y += 20f;

        //
        // Debug.Log($"{rectBase.xMax} {rectBase.position} {rectBase.center}");
        //

        // do some logic
        int[] sceneIndexes = Enumerable.Range(0, SceneManager.sceneCountInBuildSettings).ToArray();
        string[] sceneTitles = sceneIndexes.Select(x => GetSceneName(x)).ToArray();

        // draw and update properties
        EditorGUI.LabelField(rectLabel, sceneAttribute.onEventName, EditorStyles.boldLabel);
        EditorGUI.BeginChangeCheck();
        selectedIndex = EditorGUI.IntPopup(rectPopup, property.intValue, sceneTitles, sceneIndexes);
        if (EditorGUI.EndChangeCheck())
        {
            property.intValue = selectedIndex;
        }
    }
    #endregion



    public static string GetSceneName(int index)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(index);
        int startIndex = path.LastIndexOf('/') + 1;
        return path.Substring(startIndex, path.Length - (6 + startIndex));
    }

    //     int[] sceneIndexes = Enumerable.Range(0, SceneManager.sceneCountInBuildSettings).ToArray();
    //     GUIContent[] sceneNameOptions = sceneIndexes.Select(x => new GUIContent(GetSceneName(x))).ToArray();
}