using UnityEngine;
using System.Collections;

public class FirewandRetrieve : MonoBehaviour {
	public GameObject Dialog;

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			if(GameManager.instance!=null)
			GameManager.instance.setRodWasStolen (false);
			Dialog.SetActive (true);
			Destroy (gameObject);
		}
	}
}
