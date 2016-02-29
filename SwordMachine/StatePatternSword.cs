using UnityEngine;
using System.Collections;

public class StatePatternSword : MonoBehaviour {

	public float actiontimer = 120;
	public int attackno = 0;
	public bool sardinesab;
	public bool shoesab;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public ISwordState currentState;
	[HideInInspector] public ISwordState idleState;
	[HideInInspector] public ISwordState defendState;
	[HideInInspector] public ISwordState moveState;
	[HideInInspector] public ISwordState prepState;
	[HideInInspector] public ISwordState chargeState;
	[HideInInspector] public ISwordState spinState;
	[HideInInspector] public ISwordState throwattackState;
	[HideInInspector] public ISwordState stunState;

	private void Awake(){
		idleState = new IdleState (this);
		defendState = new DefendState (this);
		moveState = new MoveState (this);
		prepState = new PrepState (this);
		chargeState = new ChargeState (this);
		spinState = new SpinState (this);
		throwattackState = new ThrowAttackState (this);
		stunState = new StunState (this);
	}

	// Use this for initialization
	void Start () {
		currentState = idleState;
	}
	
	// Update is called once per frame
	void Update () {
		actiontimer--;
		currentState.UpdateState ();
	}
}
