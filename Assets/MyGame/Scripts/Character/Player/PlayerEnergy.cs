using UnityEngine;

public class PlayerEnergiy : StatusBase
{

    public float recoreverTime = 0.1f;
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

        float valueDamage = Mathf.Clamp(m_state.currentEnergy - valueRemove, 0, m_state.maxEnergy);

        ChangeValue(valueDamage);

    }
    public override void RecoveryValue(float recoveryhValue)
    {
        base.RecoveryValue(recoveryhValue);

        float valueDamage = Mathf.Clamp(m_state.currentEnergy + recoveryhValue, 0, m_state.maxEnergy);

        ChangeValue(valueDamage);

    }
    public override void RecoveryFull()
    {
        base.RecoveryFull();

        ChangeValue(m_state.maxEnergy);
    }
    public override void ChangeValue(float value)
    {
        base.ChangeValue(value);

        m_state.currentEnergy = value;

        float valueChange = (value / m_state.maxEnergy);

        OS_PlayerInGame.SpecialChange(valueChange);
    }
}
