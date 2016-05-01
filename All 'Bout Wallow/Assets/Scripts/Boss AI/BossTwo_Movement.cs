using UnityEngine;
using System.Collections;

public class BossTwo_Movement : MonoBehaviour {

	enum B2State {Idle, Summon, Chase, Attack, Die};

	public GameObject lionPreFab;
	public GameObject whipPreFab;
	public AudioClip hitSound;
	public AudioClip dieSound;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
	//public lionsab;
	float startx;
	float starty;
	float summonx;
	float summony;

	//Rigidbody2D rbody;
	Animator anim;
	B2State currstate;
	Transform target; //target Wallow
	float dir_x;
	float dir_y;

	int timer;
	int attackblink;
	int health;
	int hitblink;

	// Use this for initialization
	void Start () {
		SetIdle ();
		health = 10;
		attackblink = 0;
		hitblink = 0;
		source = GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		target = GameObject.FindWithTag("Player").transform; //target the player
		startx = transform.position.x;
		starty = transform.position.y;
		summonx = (float)startx;
		summony = (float)(starty + 1.5);
	}
	
	// Update is called once per frame
	void Update () {
		//Reduce timer for current action
		timer--;
		//Update current action
		switch(currstate)
		{
		//Idle
		case B2State.Idle:
			if (timer <= 0) {
				SetSummon ();
			}
			break;
		//Summon
		case B2State.Summon:
			if (timer <= 0) {
				SetChaseStart ();
			} else if (timer % 30 == 15) {
				//Create lion
				//if(!lionsab){
				Instantiate (lionPreFab, new Vector2(Random.Range(startx-1.5F, startx+1.5F), starty),
					transform.rotation);
				//}
			}
			break;
		//Chase
		case B2State.Chase:
			if (timer <= 0) {
				SetSummon ();
			} else{
				//Find distance to player
				float distx = target.position.x - transform.position.x;
				float disty = target.position.y - transform.position.y;
				if (distx <= 0) {
					dir_x = -1;
				} else {
					dir_x = 1;
				}
				if (disty <= 0) {
					dir_y = -1;
				} else {
					dir_y = 1;
				}
				//Near-perfect vertical alignment
				if (distx >= -0.65 && distx <= 0.65) {
					//face player
					dir_x = 0;
					//Attack if in range, else move into range
					if (disty >= -0.95 && disty <= 0.95) {
						SetAttack ();
					} else {
						MoveOn ();
					}
				}
				//Near-perfect horizontal alignment
				else if (disty >= -0.65 && disty <= 0.65) {
					//face player
					dir_y = 0;
					//Attack if in range, else move into range
					if (distx >= -0.45 && distx <= 0.45) {
						SetAttack ();
					} else {
						MoveOn ();
					}
				}
				//Not aligned either way
				else {
					MoveOn ();
				}
			
			}
			break;
		//Attack
		case B2State.Attack:
			attackblink--;
			if (attackblink <= 0) {
				SetChaseContinue ();
			} else if (attackblink == 15) {
				//Summon whip image
				if (dir_y == -1) {
					Instantiate (whipPreFab, (transform.position - transform.up),
						transform.rotation);
				} else if (dir_y == 1) {
					Instantiate (whipPreFab, (transform.position + transform.up),
						transform.rotation);
				} else if (dir_x == -1) {
					Instantiate (whipPreFab, (transform.position - transform.right),
						transform.rotation);
				} else {
					Instantiate (whipPreFab, (transform.position + transform.up),
						transform.rotation);
				}

			}
			break;
		//Die
		case B2State.Die:
			if (timer <= 0) {
				Destroy (this);
				Destroy (this.gameObject);
			}
			break;
		}//End update current action
		//Update Animator States
		if (hitblink > 0){
			hitblink--;
		}else{
			anim.SetBool("Hit_Blink", false);
		}
		float i = (float)currstate;
		anim.SetFloat("State_Flag", i);
		anim.SetFloat ("X_Dir", dir_x);
		anim.SetFloat ("Y_Dir", dir_y);

	}

	//Take Damage
	void ApplyDamage(int damageamount)
	{
		if (hitblink <= 0) {
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot (hitSound, vol);
			hitblink = 30;
			health -= damageamount;
			if (health <= 0) {
				SetDie ();
			}
		}
	}

	void SetIdle(){
		timer = 40;
		currstate = B2State.Idle;
		dir_x = 0;
		dir_y = 0;
	}
	void SetSummon(){
		timer = 300;
		currstate = B2State.Summon;
		dir_x = 0;
		dir_y = 0;
		transform.position = new Vector2(summonx, summony);
	}
	void SetChaseStart(){
		timer = 300;
		currstate = B2State.Chase;
		transform.position = new Vector2(startx, starty);
		dir_x = 0;
		dir_y = 0;
	}
	void SetChaseContinue(){
		currstate = B2State.Chase;
	}
	void SetAttack(){
		currstate = B2State.Attack;
		attackblink = 60;
	}
	void SetDie(){
		timer = 60;
		Destroy (this);
		Destroy (this.gameObject);
		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(dieSound,vol);
		currstate = B2State.Die;
	}

	void MoveOn(){
		//Move in current direction
		if(dir_x < 0){
			transform.position -= transform.right * 3 * Time.deltaTime;
		}else if(dir_x > 0){
			transform.position += transform.right * 3 * Time.deltaTime;
		}
		if(dir_y < 0){
			transform.position -= transform.up * 2 * Time.deltaTime;
		}else if(dir_y > 0){
			transform.position += transform.up * 2 * Time.deltaTime;
		}

	}

}
