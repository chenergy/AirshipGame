using UnityEngine;
using System.Collections;

[System.Serializable]
public class SO_Abilities : ScriptableObject
{
	[System.Serializable]
	public class StraightShotProperties {
		public GameObject projectilePrefab;
	}

	[System.Serializable]
	public class TargetAOEProperties
	{
		public GameObject projectilePrefab;
	}

    [System.Serializable]
    public class AutoBulletProperties
    {
        public GameObject projectilePrefab;
    }

    [System.Serializable]
    public class FrontSwipeProperties
    {
        public GameObject swipePrefab;
    }

    public StraightShotProperties straightShot;
	public TargetAOEProperties targetAOE;
    public AutoBulletProperties autoBullet;
    public FrontSwipeProperties frontSwipe;
}

