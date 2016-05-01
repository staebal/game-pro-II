using UnityEngine;
using System.Collections;

public class WhipRigged : MonoBehaviour {

	// Use this for initialization
    public GameObject swapWhip;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ApplyDamage(int damageamount)
    {
        if(GameManager.instance)
			GameManager.instance.setWhipWasSabotaged(true);
        this.gameObject.SetActive(false);
        swapWhip.SetActive(true);
    }
}
