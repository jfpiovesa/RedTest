using System;
using UnityEngine;

public static class OS_PlayerInGame
{
    public static CharacterBase Player { get; set; }

    public static Action<Transform> A_targetCam { get; set; }

    public static Action<float> A_healthChange { get; set; }
    public static Action<float> A_SpecialChange { get; set; }
    public static Action<bool> A_ActiveAttackSpecial { get; set; }
    public static Action<float> A_ChangeAttackSpecial { get; set; }
    public static Action A_deathPlayer { get; set; }


    // Methos Invoke actions

    public static void SetTarget(Transform value)
    {
        A_targetCam?.Invoke(value);
    }
    public  static  void HealthChange( float value)
    {
        A_healthChange?.Invoke(value);
    }
    public static void SpecialChange(float value)
    {
        A_SpecialChange?.Invoke(value);
    }
    public static void AtiveAttackSpecial(bool value)
    {
        A_ActiveAttackSpecial?.Invoke(value);
    }
    public static void ChangeAttackSpecial(float value)
    {
        A_ChangeAttackSpecial?.Invoke(value);
    }

    public static void DeathPlayer()
    {
        A_deathPlayer?.Invoke();
    }



}
