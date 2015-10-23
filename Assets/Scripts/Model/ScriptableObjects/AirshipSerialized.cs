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
public class AirshipSerialized {
	public GameEnum.AirshipName airshipName;
	public string name;
    public AirshipCharacterSlot[] slots;

    // Do not set.
	public bool isLocked = true;


    public AirshipSerialized(GameEnum.AirshipName airshipName, string name, AirshipCharacterSlot[] slots)
    {
        this.airshipName = airshipName;
        this.name = name;
        this.slots = slots;
    }

    public AirshipSerialized Clone()
    {
        return new AirshipSerialized(this.airshipName, this.name, this.slots);
    }
}

