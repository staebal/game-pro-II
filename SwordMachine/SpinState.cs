using UnityEngine;
using System.Collections;

public class SpinState : ISwordState {

	private readonly StatePatternSword sword;
	public SpinState (StatePatternSword statepatternSword)
	{
		sword = statepatternSword;
		sword.actiontimer = 270;
	}
	// Update is called once per frame
	void UpdateState () {

		//Injure Wallow if the two touch

		if (sword.actiontimer > 0) {
			//Move towards Wallow
		}
		else {
			ToStunState ();
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
