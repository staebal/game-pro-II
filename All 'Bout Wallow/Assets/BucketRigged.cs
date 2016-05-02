using UnityEngine;
using System.Collections;

public class BucketRigged : MonoBehaviour {

	// Use this for initialization
    public GameObject swapBucket;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void WhipDamage(int damageamount)
    {
        if(GameManager.instance)
			GameManager.instance.setKnivesWereReplaced(true);
        swapBucket.SetActive(true);
    }
}
