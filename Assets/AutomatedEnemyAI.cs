using UnityEngine;
using System.Collections;

public class AutomatedEnemyAI : MonoBehaviour {
	public bool melee;
	public bool playerinsight;
	GameObject player;

	float reloadtimer = 0;
	public float _reloadtime;
	bool canshoot = false;
	float shootdelaytimer = 0 ;
	public float _shootdelay = 0;
	float shotbullets = 0;
	public float numberofbullets ;
	public Rigidbody bullet;
	public	Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerinsight = GetComponent<EnemySight>().playerinsight;
		if (playerinsight && target){
			transform.LookAt(target.position);
			GetComponent<Unit>().playeronsight = true;
			//if (!melee)
				Autoshoot();

			/*
			Vector3 vectorToTarget = target.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.z, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationspeed);*/
		}
		if (!playerinsight && target){
			Vector3 playerposition = GetComponent<EnemySight>().personalLastSighting;
			if (playerposition != new Vector3 (0,0,0))
			
				transform.LookAt(playerposition);
		}
	}

	void Autoshoot(){

		if (reloadtimer > 0 && !canshoot )
			reloadtimer -=Time.deltaTime;
		if (reloadtimer < 0 && !canshoot )
			reloadtimer = 0;
		if (reloadtimer ==0 && !canshoot){
			reloadtimer = _reloadtime;
			canshoot = true;

			shotbullets = 0;
		}
		if (shootdelaytimer >0 && canshoot)
			shootdelaytimer -=Time.deltaTime;
		if (shootdelaytimer <0 && canshoot )
			shootdelaytimer = 0;
		if (shootdelaytimer == 0 && canshoot){


			if (shotbullets<numberofbullets){
				shotbullets++;
				Shoot();
				shootdelaytimer = _shootdelay;}
			else  {
				canshoot = false;
			}

		}


	}
	void Shoot(){
		Rigidbody instantiateProjectile = Instantiate(bullet,transform.position,transform.rotation) as Rigidbody;
		instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0,0,22));}
}
