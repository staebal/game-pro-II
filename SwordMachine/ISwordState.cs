using UnityEngine;
using System.Collections;

public interface ISwordState {
	
	void UpdateState();

	void ToIdle();

	void ToDefend();

	void ToMove();

	void ToPrep();

	void ToCharge();

	void ToSpin();

	void ToThrowAttack();

	void ToStun();

}
