using UnityEngine;
using System.Collections;

public class LionDamaged : MonoBehaviour {

	// Use this for initialization
    public GameObject swapCage;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Weld(int damageamount)
    {
        if(GameManager.instance!=null)
			GameManager.instance.setCageWasWelded(true);
        swapCage.SetActive(true);
		this.gameObject.SetActive(false);
    }
}
