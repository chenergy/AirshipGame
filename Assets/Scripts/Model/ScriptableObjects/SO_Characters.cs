using UnityEngine;
using System.Collections;

[System.Serializable]
public class SO_Characters : ScriptableObject
{
    [System.Serializable]
    public class CharacterScriptable
    {
        // Non-serializable data.
        //public GameEnum.CharacterName charName;
        public Sprite icon;

        // Serializable data.
        public CharacterSerialized characterData;
    }

    public CharacterScriptable[] characters;
}
