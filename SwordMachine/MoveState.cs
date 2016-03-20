using UnityEngine;
using System.Collections;

//MoveState moves the sword swallower back to the center of the arena
public class MoveState : ISwordState {

	private readonly StatePatternSword sword;
	public MoveState (StatePatternSword statepatternSword)
	{
		sword = statepatternSword;
		sword.actiontimer = 100;
	}
	// Update is called once per frame
	public void UpdateState()
	{
		//Move to top and center of arena
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
