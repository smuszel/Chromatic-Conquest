//Gameready assets, tips & tricks, tutorials www.not-lonely.com

using UnityEngine;
using UnityEditor;
using System;

public class ExtendedHotkeys : ScriptableObject 
{
	public static GameObject go;
	public static Vector3 goPos;

	[MenuItem ("Custom/Clear Log #_d")]
    static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
 
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
    
        clearMethod.Invoke(null, null);
    }

	// //Create a Cube ahead the scene camera by pressing Shift + 1
	// [MenuItem ("NOT_Lonely/Create Cube #_1")]
	// static void AddCube(){
	// 	go = GameObject.CreatePrimitive (PrimitiveType.Cube);
	// 	AfterCreation ();
	// }

	// //Create a Point Light ahead the scene camera by pressing Shift + 2
	// [MenuItem ("NOT_Lonely/Create Point Light #_2")]
	// static void AddPointLight(){
	// 	go = new GameObject ("Point Light");
	// 	go.AddComponent<Light> ().type = LightType.Point;
	// 	AfterCreation ();
	// }

	// //Create a Spotlight ahead the scene camera by pressing Shift + 3
	// [MenuItem ("NOT_Lonely/Create Spotlight #_3")]
	// static void AddSpotlight(){
	// 	go = new GameObject ("Spotlight");
	// 	go.AddComponent<Light> ().type = LightType.Spot;
	// 	go.transform.eulerAngles = new Vector3 (90, 0, 0);
	// 	AfterCreation ();
	// }
	// static void AfterCreation(){
	// 	goPos = SceneView.currentDrawingSceneView.camera.transform.TransformPoint (Vector3.forward * 1.1f);
	// 	go.transform.position = goPos;
	// 	Undo.RegisterCreatedObjectUndo (go, "Create " + go.name);
	// 	Selection.activeObject = go;
	// }
		
}