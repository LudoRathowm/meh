using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {
	int valuezero = 0; //strongest stat value
	int value1 = 0; //2nd strongest stat value
	float totalstats;
	string strongeststat;
	string secondstrongest;
	string PersonalityAdjective = "nigger";
	public int	Strength,Dexterity,Vitality,Intelligence; //the attributes
	public string Personality;
   public int PersonalityStrenght;
	public int  HitPoints,Mana, HPRegen,ManaRegen, PotionEfficiency,DmgReduction, MeleeAttack, RangedAttack,ShootPerRoundMultiplier,ActionsPerTurn, Precision, Movement,MovementSpeed, MagicAttack,CastDuration, PhysicalDefence,MagicDefence, PhysicalStatusRes,MagicalStatusRes,BattleStatusResist,WeightLimit; // the vitals
	// string Impulsive,Carefree,Calm,Active,Attent,Precise,Cheerful,Resolute,Energic,Cynical,Restless,Tireless; // personalities

	//STRENGHT MODIFIERS//
	float Str2Hp = 2000;
	float Str2HpR = 3f;
	float Str2Melee = 2;
	float Str2Weight = 75;
	float Str2Pdef = 50f;
	float Str2atkspd = 0.2f;
	float Str2mv = 0.4f; //str2movmenet
	float Strmvs = 0.1f;
	//DEXTERITY MODIFIERS//
	float Dex2Ranged = 1.7f;
	float Dex2Atkspd = 2.5f;
	float Dex2Precision = 10000f;
	float Dex2Movement = 0.2f;
	float Dex2MovementS = 0.7f;
	float Dex2Magic = 0.1f;
	float Dex2Cast = 0.06f;
	float Dex2Bullets = 0.15f;

	//VITALITY MODIFIERS//
	float Vit2hpr = 8;
	float Vit2mnr = 7;
	float Vit2psr = 1; //phisical status resistance
	float Vit2Dr = 5; //damage reduction
	float Vit2hp = 300;
	float Vit2mn = 30;
	float Vit2BSR = 0.5f; //battle status resist
	float Vit2mv = 0.1f; //vit2movement
	float Vit2mvs = 0.3f; //movspeed
	//float vit2minusmagic = 0.05f; //vitality decreases magic because yes
	float vit2potion= 0.08f;
	float vit2weight = 30;

	//INTELLIGENCE MODIFIERS//
	float Int2Magic = 0.08f;
	float Int2Mana = 100;
	float Int2ManaR = 3f;
	float Int2Mdef = 50f;
	float Int2msr = 1;
	float Int2Weight = 20; //smart weight partitioning m8
	float Int2mv = 0.1f; //int2movement
	float Int2cast = 0.1f;
   //VITAL MODIFIERS FOR DIMINISHING RETURNS//
	//float lessHp = 16f;
	//float lesshpr = 1.7f;
	//float lessmn = 16f;
	//float lessmnr = 1.7f;
	//float lessdr = 0.01f;
	float extraatkm = 0.1f;
	float extraatkr = 0.2f;
	float movementoffset = 20;
	float totalmovementmodifier = 2;
	float totalspeedmodifier = 1.6f;
	float speedoffset = 5;
	//float efficencyoffset = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Strength != 0 && Dexterity != 0 && Intelligence != 0 && Vitality != 0){
			AdjustVitals();
		AdjustAdjective();
			Choosepersonality();}
	}

	void AdjustVitals(){
		WeightLimit = Mathf.FloorToInt(Strength*Str2Weight+Intelligence*Int2Weight+Vitality*vit2weight);
		PotionEfficiency = (Mathf.FloorToInt(1000*Mathf.Exp(vit2potion*Vitality)/2980));
		if (PotionEfficiency < 20)
			PotionEfficiency = 20;
		HitPoints = Mathf.FloorToInt(Mathf.Log(Strength)*Str2Hp+Mathf.Log(Vitality)*Vit2hp);
		HPRegen = Mathf.FloorToInt(Mathf.Log(Strength)*Str2HpR+Mathf.Log(Vitality)*Vit2hpr);
		Mana = Mathf.FloorToInt(Mathf.Log (Intelligence)*Int2Mana+Mathf.Log (Vitality)*Vit2mn);
		ManaRegen = Mathf.FloorToInt(Mathf.Log (Intelligence)*Int2ManaR+Mathf.Log (Vitality)*Vit2mnr);
		DmgReduction = Mathf.FloorToInt(Mathf.Log (Vitality)*Vit2Dr);
		MagicAttack = Mathf.FloorToInt(Mathf.Exp(Intelligence*Int2Magic) + Mathf.Log (Dexterity)*Dex2Magic);
		if (MagicAttack<0) MagicAttack = 0;
		MeleeAttack = Mathf.FloorToInt(Strength*Str2Melee+Strength*Str2Melee*extraatkm);
		RangedAttack = Mathf.FloorToInt(Dexterity*Dex2Ranged+Dexterity*Dex2Ranged*extraatkr);
		ActionsPerTurn= Mathf.FloorToInt(-5*30/((-300+((Dexterity*Dex2Atkspd+Strength*Str2atkspd))))); //flat increase, no bullshit here
		if (ActionsPerTurn==0)
			ActionsPerTurn = 1;
		Precision = 100*(Mathf.FloorToInt(Mathf.Log (Dexterity)*Dex2Precision))/46050;
		Movement = Mathf.FloorToInt(Mathf.Log ((Dexterity*Dex2Movement+Intelligence*Int2mv+Strength*Str2mv+Vitality*Vit2mv))*totalmovementmodifier+movementoffset);
		MovementSpeed = Mathf.FloorToInt(Mathf.Log ((Dexterity*Dex2MovementS+Strength*Strmvs+Vitality*Vit2mvs))*totalspeedmodifier+speedoffset);
		PhysicalDefence = Mathf.FloorToInt(Mathf.Log (Strength*Str2Pdef)*Strength/10);
		MagicDefence = Mathf.FloorToInt(Mathf.Log (Intelligence*Int2Mdef)*Intelligence/10);
		PhysicalStatusRes = Mathf.FloorToInt(100*(Mathf.Log (Vitality*Vit2psr)*Vitality/4)/115);
		MagicalStatusRes = Mathf.FloorToInt(Mathf.Log (Intelligence)*Int2msr)*Intelligence/4;
		BattleStatusResist = Mathf.FloorToInt(Mathf.Log (Vitality*Vit2BSR)*Vitality/6);
		if (BattleStatusResist<0)
			BattleStatusResist=0;
		CastDuration = Mathf.FloorToInt(113-(100*Mathf.Exp(Dexterity*Dex2Cast)+Int2cast*Intelligence)/413);
		ShootPerRoundMultiplier = Mathf.FloorToInt(Dexterity*Dex2Bullets-Mathf.Log(Dexterity));
		if (ShootPerRoundMultiplier<0)
			ShootPerRoundMultiplier = 0;
	}

	void Choosepersonality(){
		CalculateStatStrenght();
		if (strongeststat == "Strenght" && secondstrongest == "Dexterity"){
			Personality = PersonalityAdjective+"Impulsive";
		
		}
		if (strongeststat == "Strenght" && secondstrongest == "Vitality"){
			Personality = PersonalityAdjective+"Carefree";
		
		}
		if (strongeststat == "Strenght" && secondstrongest == "Intelligence"){
			Personality = PersonalityAdjective+"Calm";
		
		}
		if (strongeststat == "Dexterity" && secondstrongest == "Strenght"){
			Personality = PersonalityAdjective+"Active";
		
		}		
		if (strongeststat == "Dexterity" && secondstrongest == "Vitality"){
			Personality = PersonalityAdjective+"Attent";
		
		}		
		if (strongeststat == "Dexterity" && secondstrongest == "Intelligence"){
			Personality = PersonalityAdjective+"Precise";
		
		}
		if (strongeststat == "Vitality" && secondstrongest == "Strenght"){
			Personality = PersonalityAdjective+"Cheerful";
		
		}
		if (strongeststat == "Vitality" && secondstrongest == "Dexterity"){
			Personality = PersonalityAdjective+ "Resolute";
		
		}
		if (strongeststat == "Vitality" && secondstrongest == "Intelligence"){
			Personality = PersonalityAdjective+"Energic";
		
		}
		if (strongeststat == "Intelligence" && secondstrongest == "Strenght"){
			Personality = PersonalityAdjective+"Cynical";
		
		}
		if (strongeststat == "Intelligence" && secondstrongest == "Dexterity"){
			Personality = PersonalityAdjective+"Restless";
		
		}
		if (strongeststat == "Intelligence" && secondstrongest == "Vitality"){
			Personality = PersonalityAdjective+"Tireless";
		
		}
	}

	void CalculateStatStrenght(){
        if (valuezero > Strength && strongeststat == "Strenght")
			valuezero = 0;
		if (valuezero > Dexterity && strongeststat == "Dexterity")
			valuezero = 0;
		if (valuezero > Vitality && strongeststat == "Vitality")
			valuezero = 0;
		if (valuezero > Intelligence && strongeststat =="Intelligence")
			valuezero = 0;

		if (valuezero < Strength){

			valuezero = Strength;
			secondstrongest = strongeststat;
			strongeststat = "Strenght";}
		if (valuezero < Dexterity){

			valuezero = Dexterity;
			secondstrongest = strongeststat;
			strongeststat = "Dexterity";
		}
		if (valuezero < Vitality){

			valuezero = Vitality;
			secondstrongest = strongeststat;
			strongeststat = "Vitality";
		}
		if (valuezero < Intelligence){

			valuezero = Intelligence;
			secondstrongest = strongeststat;
			strongeststat = "Intelligence";
		}
		if (value1 <= Strength && Strength < valuezero){
			value1 = Strength;
			secondstrongest = "Strenght";

		}
		if (value1<=Dexterity && Dexterity<valuezero){
			value1 = Dexterity;
			secondstrongest = "Dexterity";
		}
		if (value1<=Vitality && Vitality<valuezero){
			value1 = Vitality;
			secondstrongest = "Vitality";
		}
		if (value1 <= Intelligence && Intelligence<valuezero){
			value1 = Intelligence;
			secondstrongest = "Intelligence";
		}

	}
	void AdjustAdjective(){
		totalstats = Strength+Dexterity+Vitality+Intelligence;
		PersonalityStrenght = Mathf.FloorToInt((value1/totalstats)*100);
		if (PersonalityStrenght < 10)
			PersonalityAdjective = "Mildly ";
		if (PersonalityStrenght >= 10 && PersonalityStrenght<20)
			PersonalityAdjective = "Moderately ";
		if (PersonalityStrenght >= 20 && PersonalityStrenght<30)
			PersonalityAdjective = "Quite ";
		if (PersonalityStrenght >=30 && PersonalityStrenght<40)
			PersonalityAdjective = "Very ";
		if (PersonalityStrenght >= 40 && PersonalityStrenght<50)
			PersonalityAdjective = "Extremely ";
		if (PersonalityStrenght >= 50 && PersonalityStrenght<=100)
			PersonalityAdjective = "Incredibly ";
	}
}
