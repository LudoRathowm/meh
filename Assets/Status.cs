using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
	public bool Told, Buffed;
	// Use this for initialization
	public float DefenceFromBuffs, AttackFromBuffs,MovSpeedFromBuffs = 1;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AdjustBuff();

	}
	void AdjustBuff(){
		if (Told){
		
			DefenceFromBuffs = -10; 
		}
		else {
		
			DefenceFromBuffs = 0;
		}
		if (Buffed){
		
			AttackFromBuffs = 10;
		}
		else {
		
			AttackFromBuffs = 0;
		}
	}
}
