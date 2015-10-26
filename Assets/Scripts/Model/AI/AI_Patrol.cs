using UnityEngine;
using System.Collections;

public class AI_Patrol : A_AI
{
    protected override void InitAI()
    {
        /*
        I_PriorityProcessor inOrder = new Priority_InOrder();
        A_BTSelector P = new BTSelector_Priority(inOrder);

        // Short Distance
        A_BTSelector Short = new BTSelector_Concurrent();
        A_BTAction Short_Check = new BTAction_IsInDistance(this.fighter, 0.75f);
        A_BTSelector Short_Select = new BTSelector_Priority(inOrder);

        // Opponent is attacking
        A_BTSelector S_Block = new BTSelector_Concurrent();
        A_BTAction S_Block_Check = new BTAction_IsOpponentAttacking(this.fighter);
        A_BTAction S_Block_Action = new BTAction_Block(this.fighter);

        // Opponent is not attacking
        A_BTSelector S_Attack = new BTSelector_Priority(inOrder);

        A_BTSelector S_AttackA = new BTSelector_Concurrent();
        A_BTAction S_AttackA_Check = new BTAction_IsSuccessful(this.fighter, 0.4f);
        A_BTAction S_AttackA_Action = new BTAction_BasicAttackA(this.fighter, this, 0.25f);

        A_BTSelector S_AttackB = new BTSelector_Concurrent();
        A_BTAction S_AttackB_Check = new BTAction_IsSuccessful(this.fighter, 0.75f);
        A_BTAction S_AttackB_Action = new BTAction_BasicAttackB(this.fighter, this, 0.35f);

        A_BTSelector S_AttackSpecialA = new BTSelector_Concurrent();
        A_BTAction S_AttackSpecialA_Check = new BTAction_IsSuccessful(this.fighter, 0.5f);
        A_BTAction S_AttackSpecialA_Action = new BTAction_BasicAttackSpecialA(this.fighter, this, 0.5f);

        A_BTSelector S_AttackSpecialB = new BTSelector_Concurrent();
        A_BTAction S_AttackSpecialB_Check = new BTAction_IsSuccessful(this.fighter, 1.0f);
        A_BTAction S_AttackSpecialB_Action = new BTAction_BasicAttackSpecialB(this.fighter, this, 0.5f);


        // Far Distance Check
        A_BTSelector Far = new BTSelector_Concurrent();
        A_BTSelector Far_Select = new BTSelector_Priority(inOrder);

        // Opponent is attacking
        A_BTSelector F_Block = new BTSelector_Concurrent();
        A_BTAction F_Block_Check = new BTAction_IsOpponentAttacking(this.fighter);
        A_BTAction F_Block_Action = new BTAction_Block(this.fighter);

        // Far Distance fire special attack
        A_BTSelector F_AttackSpecialA = new BTSelector_Concurrent();
        A_BTAction F_AttackSpecialA_Check = new BTAction_IsSuccessful(this.fighter, 0.01f);
        A_BTAction F_AttackSpecialA_Action = new BTAction_BasicAttackSpecialA(this.fighter, this, 0.5f);

        // Move towards opponent
        A_BTAction F_Approach = new BTAction_MoveToOpponent(this.fighter);


        // Root Tree Parent
        this.root = P;
        P.AddChild(Short);
        P.AddChild(Far);

        // Short Distance Tree
        Short.AddChild(Short_Check);
        Short.AddChild(Short_Select);

        // Short Distance Select Block or Attack
        Short_Select.AddChild(S_Block);
        Short_Select.AddChild(S_Attack);

        // Short Distance Select A or B or Special
        S_Attack.AddChild(S_AttackA);
        S_Attack.AddChild(S_AttackB);
        S_Attack.AddChild(S_AttackSpecialA);
        S_Attack.AddChild(S_AttackSpecialB);

        // Short Distance Attack A Probability
        S_AttackA.AddChild(S_AttackA_Check);
        S_AttackA.AddChild(S_AttackA_Action);

        // Short Distance Attack B Probability
        S_AttackB.AddChild(S_AttackB_Check);
        S_AttackB.AddChild(S_AttackB_Action);

        // Short Distance Attack Special A Probability
        S_AttackSpecialA.AddChild(S_AttackSpecialA_Check);
        S_AttackSpecialA.AddChild(S_AttackSpecialA_Action);

        // Short Distance Attack Special A Probability
        S_AttackSpecialB.AddChild(S_AttackSpecialB_Check);
        S_AttackSpecialB.AddChild(S_AttackSpecialB_Action);

        // Short Distance Block Check
        S_Block.AddChild(S_Block_Check);
        S_Block.AddChild(S_Block_Action);



        // Far Distance Tree
        // Far Distance Select Block or Approach
        Far.AddChild(Far_Select);

        // Far Distance Block Check
        F_Block.AddChild(F_Block_Check);
        F_Block.AddChild(F_Block_Action);

        // Far Distance Select Block or Attack
        Far_Select.AddChild(F_Block);
        Far_Select.AddChild(F_AttackSpecialA);
        Far_Select.AddChild(F_Approach);

        // Far Distance Attack Special Attack
        F_AttackSpecialA.AddChild(F_AttackSpecialA_Check);
        F_AttackSpecialA.AddChild(F_AttackSpecialA_Action);

        */
    }
}
