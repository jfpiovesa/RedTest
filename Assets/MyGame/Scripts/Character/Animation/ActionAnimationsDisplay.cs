using System.Collections.Generic;
using UnityEngine;

public class ActionAnimationsDisplay : MonoBehaviour
{

    public PartAttackCollision[] partsAttack;

    public AttackBase attackBase;
    SoundsEffectsCharacter soundsEffectsCharacter;
    private void Awake()
    {
        GetPartAttackCollision();
    }

    void GetPartAttackCollision()
    {
        if (attackBase == null)
        {
            attackBase = GetComponentInParent<AttackBase>();
        }
        if(soundsEffectsCharacter == null)
        {
            soundsEffectsCharacter = GetComponentInParent<SoundsEffectsCharacter>();
        }
    }
    public void AttackEnable(int idPart)
    {
        partsAttack[idPart].EnableDamage();
    }
    public void AttackDisenable(int idPart)
    {
        partsAttack[idPart].DisableDamage();
    }
    public void DisebleAttackAll()
    {
        foreach (PartAttackCollision part in partsAttack)
        {
            part.DisableDamage();
        }
    }
   
    public void ReadyAttack()
    {
        attackBase?.ReadyAttack();
    }
    public void ResetAttack()
    {
        attackBase?.ResetAttack();
    }
    public void  EffectSound(string name)
    {
        soundsEffectsCharacter.PlaySound(name);
    }

    public void ProjectilAttack()
    {
        attackBase.AttackSpecial();
    }
}
