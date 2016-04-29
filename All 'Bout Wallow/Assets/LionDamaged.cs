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
    void ApplyDamage(int damageamount)
    {
        if(GameManager.instance)
        GameManager.instance.setCageWasWelded(true);
        this.gameObject.SetActive(false);
        swapCage.SetActive(true);
    }
}
