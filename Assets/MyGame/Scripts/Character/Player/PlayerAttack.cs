using UnityEngine;

public class PlayerAttack : AttackBase
{

    [Header("Special Attack")]
    [SerializeField] private PlayerEnergiy playerEnergiy;
    [SerializeField] Projectile prefabAttackSpecial;
    [SerializeField] float valueForAtatckSpecial = 1f;
    [SerializeField] float specialReady = 1f;
    [SerializeField] float specialFairing = 0;
    [SerializeField] bool isHoldingSpecial = false;


    void Update()
    {
        if (canCombo)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer > comboDelay)
            {
                ResetAttack();
            }
        }
        SpecialFairing();
    }
    public override void Attack(string name, int layer)
    {
        base.Attack(name, layer);

        if (!m_states.canControl) return;
        if (!m_states.canAttack) return;
        if (m_states.isFreeze) return;
        if (!m_states.stateHealth.Equals(StateHealth.IsLive)) return;

        NextAttack(name, layer);

    }
    public override void NextAttack(string name, int layer)
    {
        base.NextAttack(name, layer);

        if (!canCombo && currentCombo > 0) return;

        m_animator.SetTrigger("Attack" + (currentCombo + 1));
        comboDelay = m_animator.GetCurrentAnimatorClipInfo(0).Length;

        canCombo = false;
    }

    public void SpecialBegin()
    {

        specialFairing = 0;
        isHoldingSpecial = true;

    }
    public void SpecialFairing()
    {
        if (!isHoldingSpecial) return;

        specialFairing = Mathf.Clamp(specialFairing + Time.deltaTime, 0f, specialReady);

    }
    public void SpecialEnd()
    {
        isHoldingSpecial = false;

        if (m_states.currentEnergy < valueForAtatckSpecial) return;

        if (specialFairing.Equals(specialReady))
        {
            AttackSpecial();
        }
        else
        {
            specialFairing = 0;
        }
    }
    public void AttackSpecial()
    {
        if (m_states.currentEnergy < valueForAtatckSpecial) return;

        playerEnergiy.RemoveValue(valueForAtatckSpecial);
    }
    public override void ReadyAttack()
    {
        if (currentCombo < maxCombo - 1)
        {
            canCombo = true;
            comboTimer = 0;
            currentCombo++;
        }
    }
    public override void ResetAttack()
    {

        base.ResetAttack();
        canCombo = false;
        currentCombo = 0;

    }
}
