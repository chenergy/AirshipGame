using UnityEngine;
using System.Collections;

[System.Serializable]
public class SO_Airships : ScriptableObject
{
    [System.Serializable]
    public class AirshipScriptable
    {
        // Non-serializable data.
        //public GameEnum.AirshipName airshipName;
        public GameObject prefab;
        public Sprite icon;

        // Serializable data.
        public AirshipSerialized airshipData;
    }

	public AirshipScriptable[] airships;
}

