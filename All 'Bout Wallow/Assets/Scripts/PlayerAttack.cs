// https://unity3d.com/learn/tutorials/modules/beginner/scripting/get-button-and-get-key?playlist=17117
// http://docs.unity3d.com/ScriptReference/Input.GetButtonDown.html
// https://unity3d.com/learn/tutorials/modules/beginner/physics/colliders-as-triggers
// http://docs.unity3d.com/ScriptReference/Object.Instantiate.html
// http://docs.unity3d.com/ScriptReference/Quaternion-identity.html
// http://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147
// http://docs.unity3d.com/ScriptReference/Transform.Rotate.html
// http://docs.unity3d.com/ScriptReference/Vector3.html
// http://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html

using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	// public data
	// sword swipe image and collision
	public GameObject swipe;
	// spawn locations
	public Transform weaponNorth;
	public Transform weaponSouth;
	public Transform weaponEast;
	public Transform weaponWest;
	
	// local variables to declare
	//Animator animator;
	Transform swipeTransform;

	// Use this for initialization
	void Start () {
		//animator = GetComponent<Animator> ();
		swipeTransform = swipe.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		// vector inputs to determine direction of trigger and animations
		Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		
		// big if statement!!!
		if(Input.GetButtonDown("Sword")){	// if using sword
			// activate collision trigger dependent on current input axis
			// moving left
			if (movementVector.x >= 1){
				// rotate swipe image +180
				swipeTransform.Rotate(0, 0, 180);
				Instantiate(swipe, weaponWest.position, weaponWest.rotation);
			}
			// moving right
			else if (movementVector.x <= -1){
				// default sprite orientation is correct
				swipeTransform.Rotate(0, 0, 0);
				Instantiate(swipe, weaponEast.position, weaponEast.rotation);
			}
			// moving up
			else if (movementVector.y >= 1){
				// rotate swipe image +90
				swipeTransform.Rotate(0, 0, 90);
				Instantiate(swipe, weaponNorth.position, weaponNorth.rotation);
			}
			// moving down OR idle
			else if (movementVector.y <= -1 || (movementVector.x==0 && movementVector.y==0)){
				// rotate swipe image -90
				swipeTransform.Rotate(0, 0, -90);
				Instantiate(swipe, weaponSouth.position, weaponSouth.rotation);
			}
			
			// do matching sword swipe animation (should get animation directions from PlayerMover)
			//animator.SetBool("IsUsingSword", true);
			//animator.SetFloat("InputX", movementVector.x);
			//animator.SetFloat("InputY", movementVector.y);
		}
		else {								// if not using sword
			//animator.SetBool("IsUsingSword", false);
		}
	}
}

