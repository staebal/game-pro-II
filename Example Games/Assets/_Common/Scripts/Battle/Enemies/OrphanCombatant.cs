﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OrphanCombatant : EnemyCombatant {

	public bool IsJumping = false;

	// jump parameters
	private float StartDelay = 0;
	private int JumpForce = 100;
	private float Interval = 0.5f;
	private float jumpTimer = 0;
	private bool isLeaving = false;
	
	// Use this for initialization
	public override void Start () {

		base.Start ();

		// you can't kill an orphan! who would buy your knives then?
		immuneToDamage = true;

		//set up basic stats
		MaxHitPoints = 100;
		HitPoints = 100;

	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();

		// he is basically completely inert
		
	}

	// perform jump behavior
	void FixedUpdate() {
		if(!isSleeping && IsJumping) {
			jumpTimer += Time.fixedDeltaTime;
			
			if(jumpTimer > StartDelay) {
				if(jumpTimer > Interval) {
					GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
					
					jumpTimer = 0;
				}
			}
		} else if (isLeaving) {
			//once off screen, start doing nothing
			if(transform.position.x < -3.55f) {
				GetComponent<Renderer>().enabled = false;
				GetComponent<Rigidbody2D>().Sleep();
			}
		}
	}

	public override void AutoAttack (List<BattleCombatant> targetList) {
		// orphan doesn't attack (note: perhaps he should heal FF?)

	}

	public void leaveBattle() {
		participatingInBattle = false;
		IsJumping = false;
		isLeaving = true;
		WakeUp();
		GetComponent<Rigidbody2D>().isKinematic = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2(-6.0f, 0.0f);
	}
}
