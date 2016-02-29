using UnityEngine;
using System.Collections;

public class ChargeState : ISwordState {

	private readonly StatePatternSword sword;
	public ChargeState (StatePatternSword statepatternSword)
	{
		sword = statepatternSword;
		sword.actiontimer = 180;
	}

	// Update is called once per frame
	public void UpdateState()
	{
		//Injure Wallow if the two touch

		//Trip Over Shoes
		if (sword.actiontimer <= 160 && sword.shoesab) {
			ToStunState ();
		} 
		//Collision with arena wall
		/*else if (collided with wall) {
			ToStunState ();
		}*/
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
