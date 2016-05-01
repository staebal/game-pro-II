using UnityEngine;
using System.Collections;

public class BootsRigged : MonoBehaviour {

	// Use this for initialization
    public GameObject swapBoots;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ApplyDamage(int damageamount)
    {
        if(GameManager.instance)
			GameManager.instance.setBootsWereSabotaged(true);
        this.gameObject.SetActive(false);
        swapBoots.SetActive(true);
    }
}
