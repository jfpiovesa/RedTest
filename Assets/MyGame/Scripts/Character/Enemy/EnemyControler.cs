using System;
using UnityEngine;

public class EnemyControler : CharacterBase, I_DamageTake<DamageData>
{

    public void ApplyDamage(DamageData damageData)
    {
        if (m_health == null) return;
        if (m_states.stateHealth.Equals(StateHealth.IsDie)) return;

         m_health.RemoveValue(damageData.damage);
         m_health.Action(damageData);


    }

    public override void Teleportation(Vector3 valuePosition, Quaternion valueRotation, Action succesAction)
    {

        StopActions(true);
        base.Teleportation(valuePosition, valueRotation, succesAction);
        succesAction?.Invoke();

    }
    public void StopActions(bool value)
    {
        m_states.isFreeze = value;
    }

}
