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
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour {

	// public data
	// sword swipe image and collision
	public GameObject swipe;
	public GameObject fireball;
	public GameObject whip;
	public AudioClip hitSound;
	public AudioClip dieSound;
	public Text healthtext;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// spawn locations
	public Transform weaponNorth;
	public Transform weaponSouth;
	public Transform weaponEast;
	public Transform weaponWest;
	// sword rof
	public int swingTime;
	
	// private variables 
	private int currentTime;
	private bool hitblink;
	public int health=15;
	
	// local variables to declare
	enum WallowState {IdleMove, Swipe, AbilityFire, AbilityWhip, Hurt, Death, Victory, Move};
	WallowState currstate;
	Animator animator;
	Transform swipeTransform;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		source = GetComponent<AudioSource>();
		currstate = WallowState.IdleMove;
		currentTime = 0;
		hitblink = false;
		healthtext.text = "Health: " + health.ToString ();
		//health = 15;
		//swipeTransform = swipe.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		// decrement swing fire rate
		if (currentTime > 0) {
			currentTime--;
		} else {
			currstate = WallowState.IdleMove;
			hitblink = false;
		}

		float xface = animator.GetFloat ("InputX");
		float yface = animator.GetFloat ("InputY");
		switch (currstate) {
		//Idle
		case WallowState.IdleMove:
			if (Input.GetButtonDown ("Sword")) {
				currstate = WallowState.Swipe;
				currentTime = swingTime;
			} else if (Input.GetButtonDown ("Fire")) {
				currstate = WallowState.AbilityFire;
				currentTime = swingTime;
			} else if (Input.GetButtonDown ("Whip")) {
				currstate = WallowState.AbilityWhip;
				currentTime = swingTime;
			}
			break;
		case WallowState.Swipe:
			if (currentTime==(swingTime-2)){
				// activate collision trigger dependent on current input axis
				// moving left
				if (xface < 0){
					//Debug.Log ("swipe left!");
					Instantiate(swipe, weaponWest.position, weaponWest.rotation);
				}
				// moving right
				else if (xface > 0){
					//Debug.Log ("swipe right!");
					Instantiate(swipe, weaponEast.position, weaponEast.rotation);
				}
				// moving up
				else if (yface > 0){
					//Debug.Log ("swipe up!");
					Instantiate(swipe, weaponNorth.position, weaponNorth.rotation);
				}
				// moving down OR idle
				else{
					//Debug.Log ("swipe down!");
					Instantiate(swipe, weaponSouth.position, weaponSouth.rotation);
				}
			}
			break;
		case WallowState.AbilityFire:
			if (currentTime==(swingTime-2)){
				// activate collision trigger dependent on current input axis
				// moving left
				if (xface < 0){
					//Debug.Log ("swipe left!");
					Instantiate(fireball, weaponWest.position, weaponWest.rotation);
				}
				// moving right
				else if (xface > 0){
					//Debug.Log ("swipe right!");
					Instantiate(fireball, weaponEast.position, weaponEast.rotation);
				}
				// moving up
				else if (yface > 0){
					//Debug.Log ("swipe up!");
					Instantiate(fireball, weaponNorth.position, weaponNorth.rotation);
				}
				// moving down OR idle
				else{
					//Debug.Log ("swipe down!");
					Instantiate(fireball, weaponSouth.position, weaponSouth.rotation);
				}
			}
			break;
		case WallowState.AbilityWhip:
			if (currentTime==(swingTime-2)){
				// activate collision trigger dependent on current input axis
				// moving left
				if (xface < 0){
					//Debug.Log ("swipe left!");
					Instantiate(whip, weaponWest.position, weaponWest.rotation);
				}
				// moving right
				else if (xface > 0){
					//Debug.Log ("swipe right!");
					Instantiate(whip, weaponEast.position, weaponEast.rotation);
				}
				// moving up
				else if (yface > 0){
					//Debug.Log ("swipe up!");
					Instantiate(whip, weaponNorth.position, weaponNorth.rotation);
				}
				// moving down OR idle
				else{
					//Debug.Log ("swipe down!");
					Instantiate(whip, weaponSouth.position, weaponSouth.rotation);
				}
			}
			break;
		case WallowState.Hurt:
			break;
		case WallowState.Death:
			if (currentTime <= 0) {
				
				//Destroy (this.gameObject);
				Scene scene = SceneManager.GetActiveScene();
				//scene.name; yields name of scene
				// go back to pre rigging scene
				// reset rigs
				if(scene.name == "2.1 Getting Burned"){
					GameManager.instance.rigReset(1);
					GameManager.instance.ChangeToScene("1.2 Cake and Insults");
				}
				else if(scene.name == "3.1 Now Watch Me Whip"){
					GameManager.instance.rigReset(2);
					GameManager.instance.ChangeToScene("2.3 Wallow's Room");
				}
				else if(scene.name == "4.1 Bragging and the Final Bout"){
					GameManager.instance.rigReset(3);
					GameManager.instance.ChangeToScene("3.1.3 Wallow's Room");
				}
			}
			break;
		case WallowState.Victory:
			break;
		}

	}
	//Take Damage
	void ApplyDamage(int damageamount)
	{
		if (hitblink == false)
		{
			hitblink = true;
			currentTime = 30;
			health -= damageamount;
			healthtext.text = "Health: " + health.ToString ();
			float vol = Random.Range (volLowRange, volHighRange);
			if (health <= 0){
				source.PlayOneShot(dieSound,vol);
				currstate = WallowState.Death;
			}else{
				source.PlayOneShot(hitSound,vol);
				currstate = WallowState.Hurt;
			}
		}
	}

	void StartDancing()
	{
		hitblink = true;
		currentTime = 160;
		currstate = WallowState.Victory;
	}


}

