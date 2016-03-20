using UnityEngine;
using System.Collections;

public class StunState : ISwordState {

	private readonly StatePatternSword sword;
	public StunState (StatePatternSword statepatternSword)
	{
		sword = statepatternSword;
		sword.actiontimer = 90;
	}
	// Update is called once per frame
	public void UpdateState()
	{
		if (sword.actiontimer <= 0) {
			ToMoveState ();
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
