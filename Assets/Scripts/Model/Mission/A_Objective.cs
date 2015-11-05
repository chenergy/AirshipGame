using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class A_Objective
{
	public string name;
	public string desc;
	public bool isComplete = false;


	public A_Objective (string name, string desc){
		this.name = name;
		this.desc = desc;
	}

	public abstract void TriggerObjective ();
}

