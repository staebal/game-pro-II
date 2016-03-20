using UnityEngine;
using System.Collections;

public class ThrowAttackState : ISwordState {


	private readonly StatePatternSword sword;
	public ThrowAttackState (StatePatternSword statepatternSword)
	{
		sword = statepatternSword;
		sword.actiontimer = 180;
	}
	// Update is called once per frame
	public void UpdateState()
	{
		if (sword.actiontimer <= 0) {
			ToMoveState ();
		}
		if (sword.actiontimer % 50 == 0) {
			if (sword.sardinesab) {
				//Create sardine
			}
			else {
				//Create throwing knife
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
