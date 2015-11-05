using UnityEngine;
using System.Collections;

[System.Serializable]
public class Objective_KillEnemy : A_Objective
{
    public GameEnum.ObjectiveCondition condition;
    public GameEnum.EnemyName enemyName;

    public Objective_KillEnemy (string name, string desc, GameEnum.EnemyName enemyName) : base (name, desc)
    {
        this.enemyName = enemyName;
    }


    public override void TriggerCondition(GameEnum.ObjectiveCondition condition, params string[] parameters)
    {
        
        if ((this.condition == condition) && (parameters.Length >= 1))
        {
            Debug.Log(parameters[0]);
            if (parameters[0] == this.enemyName.ToString())
            {
                this.isComplete = true;
                GameManager.instance.Data.Save();
            }    
        }
    }
}
