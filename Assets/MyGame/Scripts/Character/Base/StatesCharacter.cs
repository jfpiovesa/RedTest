using UnityEngine;

public class StatesCharacter : MonoBehaviour
{
    [Header("CHARACTER STATES")]

    [Header("Info"), Space(5)]
    public string nameCharacter;
    public Sprite icone;

    [Header("State Enuns"), Space(5)]
    public StateHealth stateHealth = StateHealth.IsLive;
    public StatePerformace statePerformace = StatePerformace.None;

    [Header("Checking  boolens"), Space(5)]
    public bool isGround = false;
    public bool isFalling = false;


    [Header("Can Actions"), Space(5)]
    public bool canControl = false;
    public bool canAttack = false;
    public bool canSpecialAttack = false;


    [Header("Actions"), Space(5)]
    public bool isFreeze = false;
    public bool isSpring = false;


    [Header("State Health "), Space(5)]
    public float currentealth = 100;
    public float maxHealth = 100;

    [Header("State Energy "), Space(5)]
    public float currentEnergy = 100;
    public float maxEnergy = 100;



}
