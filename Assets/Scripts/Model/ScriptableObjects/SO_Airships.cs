using UnityEngine;
using System.Collections;

[System.Serializable]
public class AirshipCharacterSlot
{
    public float centerX;
    public float centerY;
    public float width;
    public float height;
}

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
        public Sprite layout;
        public AirshipCharacterSlot[] slots;

        // Serializable data.
        public AirshipSerialized airshipData;
    }

	public AirshipScriptable[] airships;
}

