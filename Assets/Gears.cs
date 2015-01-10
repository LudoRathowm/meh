using UnityEngine;
using System.Collections;

public class Gears : MonoBehaviour {
	//keeping things simple, 1 armor slot and 1 weapon slot. any class can wear anything.
	public enum Weapons {
		None,
		TestSword,
		TestBow
	}
	public enum Armor{
		None,
		TestArmor,
		TestRobeThatAlsoMakesYouRunRealGood
	}
	public Weapons Weapon;
	public Armor Clothing;

	public float
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
		WeaponWeightLimitGModifier,
	    ArmorWeightLimitGModifier;
	 
	 float WeaponWeight;
	 float ClothingWeight;

	public float GearsWeight;
	public float GearsWeightLimitModifier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWeaponStats();
		UpdateClothingStats();
		GearsWeight = ClothingWeight + WeaponWeight;
		GearsWeightLimitModifier = WeaponWeightLimitGModifier*ArmorWeightLimitGModifier;

	}
	void UpdateClothingStats(){
		if (Clothing == Armor.None){
			HitPointsGModifier = 1;
			ManaGModifier = 1;
			HPRegenGModifier = 1;
			ManaRegenGModifier = 1;
			PotionEfficiencyGModifier = 1;
			DmgReductionGModifier = 1;

			ActionsGModifier = 1;
			PrecisionGModifier = 1;
			MagicAttackGModifier = 1;
			CastDurationGModifier = 1;
			PhysicalStatusResGModifier=1;
			MagicalStatusResGModifier = 1;
			BattleStatusResistGModifier = 1;
			PhysicalDefenceGModifier = 1;
			MagicDefenceGModifier = 1;
			ClothingWeight = 0;
			ArmorWeightLimitGModifier = 1;
			MovementGModifier = 1;
			MovSpeedGModifier = 1;
		}
		if (Clothing == Armor.TestArmor){
			HitPointsGModifier = 1;
			ManaGModifier = 1;
			HPRegenGModifier = 1;
			ManaRegenGModifier = 1;
			PotionEfficiencyGModifier = 1;
			DmgReductionGModifier = 1;

			ActionsGModifier = 1;
			PrecisionGModifier = 1;
			MagicAttackGModifier = 1;
			CastDurationGModifier = 1;
			PhysicalStatusResGModifier=1;
			MagicalStatusResGModifier = 1;
			BattleStatusResistGModifier = 1;
			HitPointsGModifier = 1;
			PhysicalDefenceGModifier = 3;
			MagicDefenceGModifier = 1;
			ClothingWeight = 3000;
			ArmorWeightLimitGModifier = 1;
			MovementGModifier = 1;
			MovSpeedGModifier = 0.7f;
		}
		if (Clothing == Armor.TestRobeThatAlsoMakesYouRunRealGood){
			HitPointsGModifier = 1;
			ManaGModifier = 1;
			HPRegenGModifier = 1;
			ManaRegenGModifier = 1;
			PotionEfficiencyGModifier = 1;
			DmgReductionGModifier = 1;

			ActionsGModifier = 1;
			PrecisionGModifier = 1;
			MagicAttackGModifier = 1;
			CastDurationGModifier = 1;
			PhysicalStatusResGModifier=1;
			MagicalStatusResGModifier = 1;
			BattleStatusResistGModifier = 1;
			HitPointsGModifier = 1;
			PhysicalDefenceGModifier = 1;
			MagicDefenceGModifier = 4;
			ClothingWeight = 200;
			ArmorWeightLimitGModifier = 1;
			MovementGModifier = 2;
			MovSpeedGModifier = 3;
		}
	}

	void UpdateWeaponStats(){
		if (Weapon == Weapons.TestSword){
			HitPointsGModifier = 1;
			ManaGModifier = 1;

			HPRegenGModifier = 1;
			ManaRegenGModifier = 1;
			PotionEfficiencyGModifier = 1;
			DmgReductionGModifier = 1;

			ActionsGModifier = 1;
			PrecisionGModifier = 1;
			MagicAttackGModifier = 1;
			CastDurationGModifier = 1;
			PhysicalStatusResGModifier=1;
			MagicalStatusResGModifier = 1;
			BattleStatusResistGModifier = 1;
			HitPointsGModifier = 1;
			MeleeAttackGModifier = 30;
			RangedAttackGModifier = 0;
			WeaponWeight = 2000;
			WeaponWeightLimitGModifier = 1;
		}
		if (Weapon == Weapons.TestBow){
			HitPointsGModifier = 1;
			ManaGModifier = 1;

			HPRegenGModifier = 1;
			ManaRegenGModifier = 1;
			PotionEfficiencyGModifier = 1;
			DmgReductionGModifier = 1;

			ActionsGModifier = 1;
			PrecisionGModifier = 1;
			MagicAttackGModifier = 1;
			CastDurationGModifier = 1;
			PhysicalStatusResGModifier=1;
			MagicalStatusResGModifier = 1;
			BattleStatusResistGModifier = 1;
			HitPointsGModifier = 1;
			MeleeAttackGModifier = 1.5f;
			RangedAttackGModifier = 30;
			WeaponWeight = 1500;
			WeaponWeightLimitGModifier = 1;
		}
		if (Weapon == Weapons.None){
			HitPointsGModifier = 1;
			ManaGModifier = 1;
			HPRegenGModifier = 1;
			ManaRegenGModifier = 1;
			PotionEfficiencyGModifier = 1;
			DmgReductionGModifier = 1;

			ActionsGModifier = 1;
			PrecisionGModifier = 1;
			MagicAttackGModifier = 1;
			CastDurationGModifier = 1;
			PhysicalStatusResGModifier=1;
			MagicalStatusResGModifier = 1;
			BattleStatusResistGModifier = 1;
			HitPointsGModifier = 1;
			MeleeAttackGModifier = 1;
			RangedAttackGModifier = 0;
			WeaponWeight = 0;
			WeaponWeightLimitGModifier = 1;
	}
	}

}
