using UnityEngine;
using System.Collections;

public class EventTrigger_OnDestroyEnemyAirship : A_EventTrigger
{
	public Airship_Enemy enemy;

	void OnDestroy (){
		GameManager.instance.InGameController.mc.TriggerObjectiveCondition(GameEnum.ObjectiveCondition.KILL_ENEMY, this.enemy.enemyName.ToString());
	}
}

