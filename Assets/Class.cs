using UnityEngine;
using System.Collections;
//this class stores all the class modifiers and sets a class for the item class and the skill class
public class Class : MonoBehaviour {
	public enum Classes{
		Testguy,
        Saboteurguy,
		Meteoguy,
		Spyguy,
		Knightguy,
		Defenderguy,
		Shooterguy,
		Mageguy,
		Huntardguy,
		Supporguy,
		Manafaggotguy,
		Disablerguy,
		Magichemistguy,
		Blackguy
		}
	public Classes ThisCharacter;
	public float
    HitPointsCModifier,
	ManaCModifier, 
	HPRegenCModifier,
	ManaRegenCModifier, 
	PotionEfficiencyCModifier,
	DmgReductionCModifier, 
	AttackCModifier,
	ActionsCModifier, 
	PrecisionCModifier, 
	MovementCModifier, 
    MovSpeedCModifier,
	MagicAttackCModifier,
	CastDurationCModifier,
	PhysicalDefenceCModifier,
	MagicDefenceCModifier,
	PhysicalStatusResCModifier,
	MagicalStatusResCModifier,
	BattleStatusResistCModifier,
	WeightMovementMultiplier;
	

	// Use this for initialization
	void Start () {

	

	}
	
	// Update is called once per frame
	void Update () {
		UpdateClassStats();
	}
	void UpdateClassStats(){
		if (ThisCharacter == Classes.Blackguy){
			HitPointsCModifier = 0.7f;
			ManaCModifier = 0.2f;
			HPRegenCModifier = 0.5f;
			ManaRegenCModifier = 0.1f;
			PotionEfficiencyCModifier = 0.8f;
			DmgReductionCModifier = 1.2f;
			AttackCModifier = 3.7f;
			ActionsCModifier = 1.2f;
			PrecisionCModifier = 1;
			MovementCModifier = 1.4f;
			MagicAttackCModifier = 0;
			CastDurationCModifier = 0;
			PhysicalDefenceCModifier = 0.8f;
			MagicDefenceCModifier = 0.7f;
			PhysicalStatusResCModifier = 1.15f;
			MagicalStatusResCModifier = 0.4f;
			BattleStatusResistCModifier = 3f;
			WeightMovementMultiplier = 1.3f;
			MovSpeedCModifier = 1.5f;
		}
		if (ThisCharacter == Classes.Mageguy){
			HitPointsCModifier = 0.65f;
			ManaCModifier = 2f;
			HPRegenCModifier = 1.15f;
			ManaRegenCModifier = 3f;
			PotionEfficiencyCModifier = 0.80f;
			DmgReductionCModifier = 1;
			AttackCModifier = 0;
			ActionsCModifier = 1.7f;
			PrecisionCModifier = 1.25f;
			MovementCModifier = 0.7f;
			MagicAttackCModifier = 1.7f;
			CastDurationCModifier = 0.7f;
			PhysicalDefenceCModifier = 0.4f;
			MagicDefenceCModifier = 2.3f;
			PhysicalStatusResCModifier = 0.2f;
			MagicalStatusResCModifier = 3;
			BattleStatusResistCModifier = 0.3f;
			WeightMovementMultiplier = 0.5f;
			MovSpeedCModifier = 0.6f;
		}
		if (ThisCharacter == Classes.Testguy){
			HitPointsCModifier = 1f;
			ManaCModifier = 1;
			HPRegenCModifier = 1f;
			ManaRegenCModifier = 1f;
			PotionEfficiencyCModifier = 1;
			DmgReductionCModifier = 1;
			AttackCModifier = 1;
			ActionsCModifier = 1;
			PrecisionCModifier = 1;
			MovementCModifier = 1f;
			MagicAttackCModifier = 1;
			CastDurationCModifier = 1f;
			PhysicalDefenceCModifier = 1;
			MagicDefenceCModifier = 1;
			PhysicalStatusResCModifier = 1;
			MagicalStatusResCModifier = 1;
			BattleStatusResistCModifier = 1;
			WeightMovementMultiplier = 1;
			MovSpeedCModifier = 1f;
		}

	}

}