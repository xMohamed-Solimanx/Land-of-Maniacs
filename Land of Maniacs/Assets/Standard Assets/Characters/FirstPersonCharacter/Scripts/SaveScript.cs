using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int PlayerHealth = 100;       //to be available for other scripts
    public static bool HealthChanged = false;
    public static float BatteryPower = 1.0f;
    public static bool BatteryRefill = false;
    public static bool FlashLightOn = false;
    public static bool NVLightOn = false;
    public static int Apples = 0;
    public static int Batteries = 0;
    public static bool Axe = false;
    public static bool Knife = false;
    public static bool BaseballBat = false;
    public static bool Handgun = false;
    public static bool Crossbow = false;
    public static bool CabinKey = false;
    public static bool HouseKey = false;
    public static bool RoomKey = false;
    public static int HandgunAmmo = 0;
    public static int CrossbowAmmo = 0;
    public static bool InventoryActive = false;
    public static bool OptionsActive = false;


    public static bool HaveKnife = false;
    public static bool HaveBat = false;
    public static bool HaveAxe = false;
    public static bool HaveGun = false;
    public static bool HaveCrossbow = false;

    public static int Bullets = 12;
    public static int Arrows = 10;

    public static bool NewGame = false;

    public static Transform Target1;    // Used for spawning enemies, so that when they are spawned, they know what transforms to navigate to
    public static Transform Target2;
    public static Transform Target3;
    public static Transform Target4;
    public static Transform Target5;
    public static Transform Target6;
    public static Transform Target7;
    public static Transform Target8;
    public static Transform Target9;

    public static Transform PlayerChar;
    public static GameObject Chase;
    public static GameObject HurtScreen;

    //      EnemyDamage     //
    public static AudioSource StabSound;
    public static  GameObject SplatKnife;
    public static  GameObject SplatBat;
    public static  GameObject SplatAxe;
    //                      //

    //      WeaponsCube     //
    public static Animator Hurt;
    public static AudioSource AudioP;
    public static GameObject Arms;
    //                      //

    public static int MaxEnemiesOnScreen = 6;
    public static int EnemiesOnScreen = 0; // to keep track, it will be incremented and not greater than max.
    public static int MaxEnemiesInGame = 100;
    public static int EnemiesCurrent = 0;

    [SerializeField] Transform _Target1; //Used for spawning enemies, in order to appear in the inspector.
    [SerializeField] Transform _Target2;
    [SerializeField] Transform _Target3;
    [SerializeField] Transform _Target4;
    [SerializeField] Transform _Target5;
    [SerializeField] Transform _Target6;
    [SerializeField] Transform _Target7;
    [SerializeField] Transform _Target8;
    [SerializeField] Transform _Target9;

    [SerializeField] Transform PlayerPrefab;
    [SerializeField] GameObject ChaseMusic;
    [SerializeField] GameObject HurtUI;

    //      EnemyDamage     //
    [SerializeField] AudioSource StabPlayer;
    [SerializeField] GameObject BloodSplatKnife; //to turn the blood effect coming out of the player's weapon on and off
    [SerializeField] GameObject BloodSplatAxe;
    [SerializeField] GameObject BloodSplatBat;
    //                      //


    //      WeaponsCube     //
    [SerializeField] Animator HurtAnim;
    [SerializeField] AudioSource MyPlayer;
    [SerializeField] GameObject FPSArms; //used to decrease player stamina when hit by enemies
    //                      //





    private void Start()
    {

        Target1 = _Target1; //Now the trick is complete, we can access the transforms put in the inspector from code
        Target2 = _Target2;
        Target3 = _Target3;
        Target4 = _Target4;
        Target5 = _Target5;
        Target6 = _Target6;
        Target7 = _Target7;
        Target8 = _Target8;
        Target9 = _Target9;
        PlayerChar = PlayerPrefab;
        Chase = ChaseMusic;
        HurtScreen = HurtUI;
        StabSound = StabPlayer;
        SplatKnife = BloodSplatKnife;
        SplatBat = BloodSplatBat;
        SplatAxe = BloodSplatAxe;
        Hurt = HurtAnim;
        AudioP = MyPlayer;
        Arms = FPSArms;






        if (NewGame == true)
        {
            PlayerHealth = 100;       //to be available for other scripts
            HealthChanged = false;
            BatteryPower = 1.0f;
            BatteryRefill = false;
            FlashLightOn = false;
            NVLightOn = false;
            Apples = 0;
            Batteries = 0;
            Axe = false;
            Knife = false;
            BaseballBat = false;
            Handgun = false;
            Crossbow = false;
            CabinKey = false;
            HouseKey = false;
            RoomKey = false;
            HandgunAmmo = 0;
            CrossbowAmmo = 0;
            InventoryActive = false;

            HaveKnife = false;
            HaveBat = false;
            HaveAxe = false;
            HaveGun = false;
            HaveCrossbow = false;

            Bullets = 12;
            Arrows = 10;

        }
    }


















}



