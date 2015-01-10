using UnityEngine;
using System.Collections;

public class Vitals : MonoBehaviour {
	int PersonalityStrenght;
	string Personality;
    
	public int 
	    HitPoints,
	    Mana, 
	    HPRegen,
	    ManaRegen, 
		PotionEfficiency,
		DmgReduction, 
		MeleeAttack,
		RangedAttack,
		Actions, 
		Precision, 
		Movement, 
		MovementSpeed,
		MagicAttack,
		CastDuration,
		PhysicalDefence,
		MagicDefence,
		PhysicalStatusRes,
		MagicalStatusRes,
		BattleStatusResist,
		WeightFromItems,
		WeightFromGears,
		WeightLimit;

	//CLASS RELATED STUFF
	float
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
		WeightLimitCModifier;

	//GEARS RELATED STUFF
	 float
		GearsWeight,
		HitPointsGModifier,
		ManaGModifier, 
		HPRegenGModifier,
		ManaRegenGModifier, 
		PotionEfficiencyGModifier,
		DmgReductionGModifier, 
		MeleeAttackGModifier,
		RangedAttackGModifier,
		ActionsGModifier, 
		PrecisionGModifier, 
		MovementGModifier, 
		MovSpeedGModifier,
		MagicAttackGModifier,
		CastDurationGModifier,
		PhysicalDefenceGModifier,
		MagicDefenceGModifier,
		PhysicalStatusResGModifier,
		MagicalStatusResGModifier,
		BattleStatusResistGModifier,
		WeightLimitGModifier;

	//BUFFS RELATED STUFF
	float DefenceFromBuffs, AttackFromBuffs,MovSpeedFromBuffs;

	//STATS RELATED STUFF
	int
	SHitPoints,
	SMana,
	SHPRegen,
	SManaRegen,
	SPotionEfficiency,
	SDmgReduction,
	SMeleeAttack,
	SRangedAttack,
	SShootPerRoundMultiplier,
	SActionsPerTurn,
	SPrecision,
	SMovement,
    SMovementSpeed,
	SMagicAttack,
	SCastDuration, 
	SPhysicalDefence,
	SMagicDefence, 
	SPhysicalStatusRes,
	SMagicalStatusRes,
	SBattleStatusResist,
	SWeightLimit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		BuffGetValues();
		StatGetValues();
		GearsGetValues();
		ClassGetValues();
		UpdateVitals();
		PersonalityStuff();
	}
	void UpdateVitals(){
		HitPoints = Mathf.FloorToInt(SHitPoints*HitPointsCModifier*HitPointsGModifier);
		Mana = Mathf.FloorToInt(SMana*ManaCModifier*ManaGModifier);

		HPRegen = Mathf.FloorToInt(SHPRegen*HPRegenCModifier*HPRegenGModifier);
		ManaRegen = Mathf.FloorToInt(SManaRegen*ManaCModifier*ManaRegenGModifier);
		PotionEfficiency = Mathf.FloorToInt(SPotionEfficiency*PotionEfficiencyCModifier*PotionEfficiencyGModifier);
		DmgReduction = Mathf.FloorToInt(SDmgReduction*DmgReductionCModifier*DmgReductionGModifier);
		Actions = Mathf.FloorToInt(SActionsPerTurn*ActionsCModifier*ActionsGModifier);
		Precision =Mathf.FloorToInt(SPrecision*PrecisionCModifier*PrecisionGModifier);
		MagicAttack = Mathf.FloorToInt(SMagicAttack*MagicAttackCModifier*MagicAttackGModifier);
		CastDuration = Mathf.FloorToInt (SCastDuration*CastDurationCModifier*CastDurationGModifier);
		PhysicalStatusRes = Mathf.FloorToInt(SPhysicalStatusRes*PhysicalStatusResCModifier*PhysicalStatusResGModifier);
		MagicalStatusRes = Mathf.FloorToInt(SMagicalStatusRes*MagicalStatusResCModifier*MagicalStatusResGModifier);
		BattleStatusResist = Mathf.FloorToInt(SBattleStatusResist*BattleStatusResistCModifier*BattleStatusResistGModifier);
		MeleeAttack = Mathf.FloorToInt(SMeleeAttack*MeleeAttackGModifier*AttackCModifier+AttackFromBuffs);
		RangedAttack = Mathf.FloorToInt(SRangedAttack*RangedAttackGModifier*AttackCModifier+AttackFromBuffs);
		PhysicalDefence = Mathf.FloorToInt(SPhysicalDefence*PhysicalDefenceGModifier*PhysicalDefenceCModifier + DefenceFromBuffs);
		MagicDefence = Mathf.FloorToInt(SMagicDefence*MagicDefenceGModifier*MagicDefenceCModifier+DefenceFromBuffs);
		WeightLimit = Mathf.FloorToInt(SWeightLimit*WeightLimitGModifier*WeightLimitCModifier);
		WeightFromGears = Mathf.FloorToInt(GearsWeight);
		int fullmovement = Mathf.FloorToInt(SMovement*MovementGModifier*MovementCModifier);
		float CurrentWeight = WeightLimit-WeightFromItems-WeightFromGears;
		float WeightLeftPercent = ((float)CurrentWeight)/((float)(WeightLimit));
		Movement = Mathf.FloorToInt(fullmovement*WeightLeftPercent);
		float fullmovspeed = Mathf.FloorToInt(SMovementSpeed*MovSpeedGModifier*MovSpeedCModifier);
		MovementSpeed = Mathf.FloorToInt(fullmovspeed*WeightLeftPercent);
	}
	void BuffGetValues(){
		DefenceFromBuffs = GetComponent<Status>().DefenceFromBuffs;
		AttackFromBuffs = GetComponent<Status>().AttackFromBuffs;
		MovSpeedFromBuffs = GetComponent<Status>().MovSpeedFromBuffs;
	}

	void StatGetValues(){
		SHitPoints = GetComponent<Statistics>().HitPoints;
		SMana = GetComponent<Statistics>().Mana;
		SHPRegen = GetComponent<Statistics>().HPRegen;
		SManaRegen = GetComponent<Statistics>().ManaRegen;
		SPotionEfficiency = GetComponent<Statistics>().PotionEfficiency;
		SDmgReduction = GetComponent<Statistics>().DmgReduction;
		SMeleeAttack = GetComponent<Statistics>().MeleeAttack;
		SRangedAttack = GetComponent<Statistics>().RangedAttack;
		SShootPerRoundMultiplier = GetComponent<Statistics>().ShootPerRoundMultiplier;
		SActionsPerTurn = GetComponent<Statistics>().ActionsPerTurn;
		SPrecision = GetComponent<Statistics>().Precision;
		SMovement = GetComponent<Statistics>().Movement;
		SMovementSpeed = GetComponent<Statistics>().MovementSpeed;
		SMagicAttack = GetComponent<Statistics>().MagicAttack;
		SCastDuration = GetComponent<Statistics>().CastDuration;
		SPhysicalDefence = GetComponent<Statistics>().PhysicalDefence;
		SMagicDefence = GetComponent<Statistics>().MagicDefence;
		SPhysicalStatusRes = GetComponent<Statistics>().PhysicalStatusRes;
		SMagicalStatusRes = GetComponent<Statistics>().MagicalStatusRes;
		SBattleStatusResist = GetComponent<Statistics>().BattleStatusResist;
		SWeightLimit = GetComponent<Statistics>().WeightLimit;
	}

	void GearsGetValues(){
		GearsWeight = GetComponent<Gears>().GearsWeight;
		HitPointsGModifier = GetComponent<Gears>().HitPointsGModifier;
		ManaGModifier = GetComponent<Gears>().ManaGModifier;
		HPRegenGModifier = GetComponent<Gears>().HPRegenGModifier;
		ManaRegenGModifier = GetComponent<Gears>().ManaRegenGModifier;
		PotionEfficiencyGModifier = GetComponent<Gears>().PotionEfficiencyGModifier;
		DmgReductionGModifier = GetComponent<Gears>().DmgReductionGModifier;
		MeleeAttackGModifier = GetComponent<Gears>().MeleeAttackGModifier;
		RangedAttackGModifier = GetComponent<Gears>().RangedAttackGModifier;
		ActionsGModifier = GetComponent<Gears>().ActionsGModifier;
		PrecisionGModifier = GetComponent<Gears>().PrecisionGModifier;
		MovementGModifier = GetComponent<Gears>().MovementGModifier;
		MovSpeedGModifier = GetComponent<Gears>().MovSpeedGModifier;
		MagicAttackGModifier = GetComponent<Gears>().MagicAttackGModifier;
		CastDurationGModifier = GetComponent<Gears>().CastDurationGModifier;
		PhysicalDefenceGModifier = GetComponent<Gears>().PhysicalDefenceGModifier;
		MagicDefenceGModifier = GetComponent<Gears>().MagicDefenceGModifier;
		PhysicalStatusResGModifier = GetComponent<Gears>().PhysicalDefenceGModifier;
		MagicalStatusResGModifier = GetComponent<Gears>().MagicalStatusResGModifier;
		BattleStatusResistGModifier = GetComponent<Gears>().BattleStatusResistGModifier;
		WeightLimitGModifier = GetComponent<Gears>().GearsWeightLimitModifier;
	}

	void ClassGetValues(){
		HitPointsCModifier = GetComponent<Class>().HitPointsCModifier;
		ManaCModifier = GetComponent<Class>().ManaCModifier;
		HPRegenCModifier = GetComponent<Class>().HPRegenCModifier;
		ManaRegenCModifier = GetComponent<Class>().ManaRegenCModifier;
		PotionEfficiencyCModifier = GetComponent<Class>().PotionEfficiencyCModifier;
		DmgReductionCModifier = GetComponent<Class>().DmgReductionCModifier;
		AttackCModifier = GetComponent<Class>().AttackCModifier;
		ActionsCModifier = GetComponent<Class>().ActionsCModifier;
		PrecisionCModifier = GetComponent<Class>().PrecisionCModifier;
		MovementCModifier = GetComponent<Class>().MovementCModifier;
		MovSpeedCModifier = GetComponent<Class>().MovSpeedCModifier;
		MagicAttackCModifier = GetComponent<Class>().MagicAttackCModifier;
		CastDurationCModifier = GetComponent<Class>().CastDurationCModifier;
		PhysicalDefenceCModifier = GetComponent<Class>().PhysicalDefenceCModifier;
		MagicDefenceCModifier = GetComponent<Class>().MagicDefenceCModifier;
		PhysicalStatusResCModifier = GetComponent<Class>().PhysicalDefenceCModifier;
		MagicalStatusResCModifier = GetComponent<Class>().MagicalStatusResCModifier;
		BattleStatusResistCModifier = GetComponent<Class>().BattleStatusResistCModifier;
		WeightLimitCModifier = GetComponent<Class>().WeightMovementMultiplier;
	}
	void PersonalityStuff(){
		PersonalityStrenght = GetComponent<Statistics>().PersonalityStrenght;
		Personality = GetComponent<Statistics>().Personality;
		if (Personality == "Impulsive"){

		}

	}
}
