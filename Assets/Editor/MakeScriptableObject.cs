using UnityEngine;
using UnityEditor;
using System.Collections;

public class MakeScriptableObject : MonoBehaviour {

	[MenuItem ("Assets/Create/CharacterScriptableObject")]
	public static void CreateFighter (){
		SO_Characters asset = ScriptableObject.CreateInstance <SO_Characters> ();
		
		AssetDatabase.CreateAsset (asset, "Assets/Data/SO_Characters.asset");
		AssetDatabase.SaveAssets ();
		
		EditorUtility.FocusProjectWindow ();
		
		Selection.activeObject = asset;
	}

	[MenuItem ("Assets/Create/AbilityScriptableObject")]
	public static void CreateAbilities (){
		SO_Abilities asset = ScriptableObject.CreateInstance <SO_Abilities> ();
		
		AssetDatabase.CreateAsset (asset, "Assets/Data/SO_Abilities.asset");
		AssetDatabase.SaveAssets ();
		
		EditorUtility.FocusProjectWindow ();
		
		Selection.activeObject = asset;
	}
}
