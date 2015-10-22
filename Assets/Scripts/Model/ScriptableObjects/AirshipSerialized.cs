using UnityEngine;
using System.Collections;

[System.Serializable]
public class AirshipSerialized {
	public GameEnum.AirshipName airshipName;
	//public GameObject prefab;
	//public Sprite icon;
	public string name;
	public int slots;
	public bool isLocked = true;


    public AirshipSerialized(GameEnum.AirshipName airshipName, string name, int slots)
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

