using UnityEngine;
using System.Collections;


public class Skills : MonoBehaviour {
	public bool Testskills;
	public bool Leaderskills;
public	enum TabSkills {
		SkillOne,
		SkillTwo,
		SkillThree,
		SkillFour
	}
	public TabSkills CurrentSkill;
	public bool _myturn;
	void Start (){
		StartCoroutine("FSM");

		if (CurrentSkill == null)
			CurrentSkill = TabSkills.SkillOne;

	}


	void Update(){

	
	}

	private IEnumerator FSM(){

		while (_myturn){

			switch (CurrentSkill){
			case TabSkills.SkillOne:
			if (Input.GetButtonDown("Switch"))
					CurrentSkill = TabSkills.SkillTwo;
				SkillOne();
				break;
			case TabSkills.SkillTwo:
				if (Input.GetButtonDown("Switch"))
					CurrentSkill = TabSkills.SkillThree;
				SkillTwo();
				break;
			case TabSkills.SkillThree:
				if (Input.GetButtonDown("Switch"))
					CurrentSkill = TabSkills.SkillFour;
				SkillThree();
				break;
			case TabSkills.SkillFour:
				if (Input.GetButtonDown("Switch"))
					CurrentSkill = TabSkills.SkillOne;
				SkillFour();
				break;
			}
			yield return null;
		}
	}










	void SkillOne(){
		if (Testskills){
			if (Input.GetButtonDown("Fire1"))
				TestSkillOne();		
		}
	}
	void SkillTwo(){
		if (Testskills){
			if (Input.GetButtonDown("Fire1"))
				TestSkillTwo();		
		}
	}
	void SkillThree(){
		if (Testskills){
			if (Input.GetButtonDown("Fire1"))
				TestSkillThree();		
		}
	}
	void SkillFour(){
		if (Testskills){
			if (Input.GetButtonDown("Fire1"))
				TestSkillFour();		
		}
	}
	void TestSkillOne(){
		Debug.Log ("skill one");
		_myturn = false;
	}
	void TestSkillTwo(){
		Debug.Log ("skill two");
		_myturn = false;
	}
	void TestSkillThree(){
		Debug.Log ("skill three");
		_myturn = false;
	}
	void TestSkillFour(){
		Debug.Log ("skill four");
		_myturn = false;
	}

	void UpdateCharSkills(){
		if (Testskills){}

	}

}
