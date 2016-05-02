using UnityEngine;
using System.Collections;

public class BootsRigged : MonoBehaviour {

	// Use this for initialization
    public GameObject swapBoots;

	void WhipDamage(int damageamount)
    {
		print ("we did it yah!");
        if(GameManager.instance!=null)
			GameManager.instance.setBootsWereSabotaged(true);
		swapBoots.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
