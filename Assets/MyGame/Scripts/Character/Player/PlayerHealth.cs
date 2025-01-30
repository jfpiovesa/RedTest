using UnityEngine;

public class PlayerHealth : StatusBase
{

    private void Awake()
    {
        Inicialized();
    }
    public override void Inicialized()
    {
        base.Inicialized();
        RecoveryFull();
    }
    public override void RemoveValue(float valueRemove)
    {
        base.RemoveValue(valueRemove);

        float valueDamage = Mathf.Clamp(m_state.currentealth - valueRemove, 0, m_state.maxHealth);

        ChangeValue(valueDamage);

        if (valueDamage <= 0)
        {
            m_state.stateHealth = StateHealth.IsDie;
        }
    }
    public override void RecoveryValue(float recoveryhValue)
    {
        base.RecoveryValue(recoveryhValue);

        float valueDamage = Mathf.Clamp(m_state.currentealth + recoveryhValue, 0, m_state.maxHealth);

        ChangeValue(valueDamage);

    }
    public override void Action(DamageData damageDataValue)
    {
        base.Action(damageDataValue);

        float dotProduct = Vector3.Dot(transform.forward, damageDataValue.knockDirection.normalized);

        if (dotProduct > 0)
        {
            m_aniamotor.Play("HitFront");
        }
        else
        {
            m_aniamotor.Play("HitBack");
        }
    }
    public override void RecoveryFull()
    {
        base.RecoveryFull();

        ChangeValue(m_state.maxHealth);
    }
    public override void ChangeValue(float value)
    {
        base.ChangeValue(value);

        m_state.currentealth = value;

        float valueChange = (value / m_state.maxHealth);

        OS_PlayerInGame.HealthChange(valueChange);
    }

}
