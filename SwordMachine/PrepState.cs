using UnityEngine;
using System.Collections;

public class PrepState : ISwordState {

	private readonly StatePatternSword sword;
	public PrepState (StatePatternSword statepatternSword)
	{
		sword = statepatternSword;
		sword.actiontimer = 180;
	}
	// Update is called once per frame
	public void UpdateState()
	{
		//Line up with Wallow
		if (sword.actiontimer > 60) {
			//Move hoizontally towards Wallow
		}
		//About to charge
		else if (sword.actiontimer > 0) {
			//Show angry face
		} 
		//Time to attack
		else {
			ToChargeState ();
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
