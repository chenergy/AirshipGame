using UnityEngine;
using System.Collections;

[System.Serializable]
public class AirshipSerialized {
	public GameEnum.AirshipName airshipName;
	public string name;

    // Do not set.
	public bool isLocked = true;


    public AirshipSerialized(GameEnum.AirshipName airshipName, string name)
    {
        this.airshipName = airshipName;
        this.name = name;
    }

    public AirshipSerialized Clone()
    {
        return new AirshipSerialized(this.airshipName, this.name);
    }
}

