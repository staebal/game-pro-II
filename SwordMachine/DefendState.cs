using UnityEngine;
using System.Collections;

public class DefendState : ISwordState {

	private readonly StatePatternSword sword;
	public DefendState (StatePatternSword statepatternSword)
	{
		sword = statepatternSword;
		sword.actiontimer = 180;
	}
	// Update is called once per frame
	public void UpdateState()
	{
		//Stall until time to attack again
		if (sword.actiontimer <= 0) {
			if (sword.attackno % 3 == 0) {
				ToPrepState ();
			}
			else if (sword.attackno % 3 == 1) {
				ToSpinState ();
			}
			else {
				ToThrowAttackState ();
			}
		}
	}

	public void ToIdleState(){
		sword.currentState = sword.idleState;
	}

	public void ToDefendState(){
		sword.currentState = sword.defendState;
	}

	public void ToMoveState(){
		sword.currentState = sword.moveState;
	}

	public void ToPrepState(){
		sword.currentState = sword.prepState;
	}

	public void ToChargeState(){
		sword.currentState = sword.chargeState;
	}

	public void ToSpinState(){
		sword.currentState = sword.spinState;
	}

	public void ToThrowAttackState(){
		sword.currentState = sword.throwattackState;
	}

	public void ToStunState(){
		sword.currentState = sword.stunState;
	}
}
