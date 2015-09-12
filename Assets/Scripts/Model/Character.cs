using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character
{
	private Sprite icon;
	public Sprite Icon {
		get { return this.icon; }
	}

	private string name;
	public string Name {
		get { return this.name; }
	}

	private int maxHp;
	public int MaxHp {
		get { return this.maxHp; }
	}

	private int maxMp;
	public int MaxMp {
		get { return this.maxMp; }
	}

	private List<Ability> abilities;


	public Character (string name, Sprite icon, int maxHp, int maxMp) {
		this.name = name;
		this.icon = icon;
		this.maxHp = maxHp;
		this.maxMp = maxMp;
		this.abilities = new List<Ability> ();
	}

	public void AddAbility (Ability ability){
		this.abilities.Add (ability);
	}
}

