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
	void Noodles(int setup){
		print ("swiped!");
        if(GameManager.instance!=null)
			GameManager.instance.setWhipWasSabotaged(true);
        gameObject.SetActive(false);
        swapWhip.SetActive(true);
    }
}
