using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class EnemyHealth : StatusBase
{


    public Image m_iBarHealth;

    public LookAtConstraint m_LookAtConstraint;


    public bool resetLife = false;
    private void Awake()
    {
        Inicialized();
    }
    public override void Inicialized()
    {
        base.Inicialized();

        RecoveryFull();
        ConstraintSource constraintSource = m_LookAtConstraint.GetSource(0);
        constraintSource.sourceTransform = Camera.main.transform;
        m_LookAtConstraint.SetSource(0, constraintSource);

    }
    public override void RemoveValue(float damageValue)
    {
        base.RemoveValue(damageValue);

        float valueDamage = Mathf.Clamp(m_state.currentealth - damageValue, 0, m_state.maxHealth);
        ChangeValue(valueDamage);


        if (valueDamage <= 0)
        {
            if (resetLife)
            {
                RecoveryFull();
            }
            else
            {
                m_state.stateHealth = StateHealth.IsDie;
            }
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
            m_aniamotor.Play("HitFront",0);
        }
        else
        {
            m_aniamotor.Play("HitBack",0);
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

        if (m_iBarHealth != null)
        {
            m_iBarHealth.fillAmount = (value / m_state.maxHealth);

        }
    }
}
