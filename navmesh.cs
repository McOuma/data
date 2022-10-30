public float distanceForMeleeAttack; //the distance for melee attack
	


//this gets all the vairables to correct values
public void GetVariablesFromAI()
{

		//to avoid complicating stuff in the prefab
		#if UNITY_EDITOR
		if(PrefabUtility.GetPrefabType(gameObject) == PrefabType.Prefab)
		{
			return;
		}
		#endif


if(gameObject.activeSelf == true)
{

//main objects that are crucial for the ai brain to function
patrolManager = GetComponent<AIStateManager>().patrolManager; //the patrol manager
sensorParent = GetComponent<AIStateManager>().ears.transform.parent.gameObject; //the parent that holds the sensors
ears = GetComponent<AIStateManager>().ears; //the ears object
sight = GetComponent<AIStateManager>().sight; //the sight object
model = GetComponent<AIStateManager>().animationManager;

//data about self, eg height, health
eyeHeight = GetComponent<SearchCover>().eyePosition; //the height of the eyes
health = GetComponent<AIStateManager>().healthManager.GetComponent<HealthManager>().health; //the amount of health the ai has at the start
disengagingHitsToKnockout = GetComponentInChildren<AIHealthExecuter>().disengagingHitsToKnockout; //the amount of disengaging hits the ai can take until it gets disengaged

if(GetComponent<NavMeshAgent>() != null)
{
radius = GetComponent<NavMeshAgent>().radius; //the size of our radius for the navmesh agent
height = GetComponent<NavMeshAgent>().height; //our height, for the nav mesh agent
}



//data about enemies, such as height, tag etc..
tagOfEnemy = GetComponent<AIStateManager>().tagToAvoidPrimary; //the tag of the enemy
tagOfBullet = GetComponent<AIStateManager>().tagToAvoidSecondary; //the tag of the object that shows danger, eg bullets
enemyCriticalHeight = GetComponent<AIStateManager>().enemyHeight; //the height at which the ai should aim
initAmmo = GetComponent<AIWeaponController>().amountOfAmmo; //the amount of ammo at the start

//reaction times, how quick does the ai react etc...
shockTime = GetComponent<AIStateManager>().shockTime; //seconds, how quickly we react to seeing an enemy, reference and manipulated by anderenaline
freezeTime = GetComponent<AIStateManager>().freezeTime; //seconds, how long we freeze when we hear a bullet
minCoverTime = GetComponent<AIStateManager>().minCoverTime; //seconds, minimum amount of time to hide in cover
maxCoverTime = GetComponent<AIStateManager>().maxCoverTime; //seconds, maximum amount of time to hide in cover
timeBetweenEnemyChecks = GetComponent<AIStateManager>().timeUntilNextCheck; //seconds, amount of time when we check whether the others are a danger or not
timeForGivingUpDuringEngagement = GetComponent<AIStateManager>().investigationTime; //seconds, the amount of time the ai will try and locate the enemy during an engagment before giving up and going back to patrol
timeForGivingUpSeeking = GetComponent<AIStateManager>().timeBarrierEngageToInvestigate; //frames, the amount of time the ai will try and locate the enemy if we suddenly see somebody else before giving up and going back to patrol 

//emotion control
initAndrenaline = GetComponent<AIStateManager>().andrenaline; //the amount of andrenaline we start off with
initFear = GetComponent<AIStateManager>().fear; //the amount of fear the ai starts off with
chanceForFight = GetComponent<AIStateManager>().chanceForFight; //the percentage for fight or flight instict, reference manipulated by andrenaline

//weapons and engagement
weapon = GetComponent<AIWeaponController>().weaponHoldingObject; //the weapon object
			otherWeapons = GetComponent<AIStateManager>().otherWeapons; //other weapons
			otherWeaponsMelee = GetComponent<AIStateManager>().otherWeaponsMelee; //other weapons melee
weaponHoldingLocation = GetComponent<AIWeaponController>().weaponHoldingLocation; //the object where the weapon is held
targetCheck = GetComponent<AIStateManager>().targetVisualCheck; //the name of the script that return whether the ai should attack or not
targetVisualCheckChance = GetComponent<AIStateManager>().targetVisualCheckChance;
distanceToEngageCloseCombatLogic = GetComponent<AIStateManager>().distanceToStopWalking; //the distance at which to engage
offsetFactor = GetComponent<AIStateManager>().offsetFactor;


//speed references
refSpeedPatrol = GetComponent<AIStateManager>().maxSpeedPatrol; //the reference speed for the patrol
refSpeedEngage = GetComponent<AIStateManager>().maxSpeedEngage; //the reference speed for when the ai engages
refSpeedChase = GetComponent<AIStateManager>().maxSpeedChase; //the reference speed for chase
refSpeedCover = GetComponent<AIStateManager>().maxSpeedCover; //the refernce speed at which the ai runs to cover

//model stuff
modelParentOfAllBones = model.GetComponent<RagdollTransitions>().boneParent; //the parent object that takes in all bones
handToUseInCharacter = model.GetComponent<HandIK>().handToUseInCharacter;


//patrol sutff
			if(patrolManager.GetComponent<PatrolManager>() != null)
			{
				waypointList = patrolManager.GetComponent<PatrolManager>().waypointList; //the list that contains all waypoinjts in correct order
				distanceToWaypointForRegistering = patrolManager.GetComponent<PatrolManager>().criticalDistanceToWaypoint; //how far we have to be from the waypoint for it to register that we are at it
				navmeshToUse = patrolManager.GetComponent<PatrolManager>().meshNav; //the navmesh to use
			}
			
			if(GetComponent<AIMovementController>() != null)
			{
				patrolMinDistanceToDestination = GetComponent<AIMovementController>().minDistanceToDestination;
				patrolFramesCriticalCheck = GetComponent<AIMovementController>().framesCriticalCheck;
				patrolChecksCritical = GetComponent<AIMovementController>().checksCriticalUntilStop;
			}
			if(GetComponent<AIMovementControllerASTAR>() != null)
			{
				patrolMinDistanceToDestination = GetComponent<AIMovementControllerASTAR>().minDistanceToDestination;
				patrolFramesCriticalCheck = GetComponent<AIMovementControllerASTAR>().framesCriticalCheck;
				patrolChecksCritical = GetComponent<AIMovementControllerASTAR>().checksCriticalUntilStop;
			}
		

//optimisation stuff
coverAmountOfRays = GetComponent<SearchCover>().amountOfRays; //the amount of rays that should be used to sample cover (the more the better, more slower)
coverFieldOfView = GetComponent<SearchCover>().fieldOfRays; //the field of view from which we find cove (recommend 360 for most cases)
coverDistanceToCheck = GetComponent<SearchCover>().distanceToCheck; //how far should the rays shoot; usually some arbitary large number 
patrolTickBarrier = GetComponent<AIStateManager>().tickBarrier; //this is how often the ai brain should check the patroling
coverTrueCoverTest = GetComponent<SearchCover>().trueCoverTest;


//melee stuff
meleeSetting = GetComponent<AIStateManager>().meleeAttackUsed;
distanceForMeleeAttack = GetComponent<AIStateManager>().meleeAttackDistance;

}

}