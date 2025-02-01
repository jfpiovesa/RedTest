using UnityEngine;

public class PlayerAttack : AttackBase
{

    [Header("Special Attack")]
    [SerializeField] private PlayerEnergiy playerEnergiy;
    [SerializeField] Projectile prefabAttackSpecial;
    [SerializeField] Transform  positionSpecialSpawn;
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

        m_animator.Play("AttackChange");
        m_animator.SetBool("SpecialActive", isHoldingSpecial);
        OS_PlayerInGame.AtiveAttackSpecial(isHoldingSpecial);
    }
    public void SpecialFairing()
    {
        if (!isHoldingSpecial) return;


        if (m_states.currentEnergy > valueForAtatckSpecial)
        {
            specialFairing = Mathf.Clamp(specialFairing + Time.deltaTime, 0f, specialReady);
        }
        else
        {
            specialFairing = 0f;
        }
     
        m_animator.SetFloat("SpeccialChange", specialFairing);
        OS_PlayerInGame.ChangeAttackSpecial(specialFairing);


    }
    public void SpecialEnd()
    {
        isHoldingSpecial = false;
        m_animator.SetBool("SpecialActive", isHoldingSpecial);
        OS_PlayerInGame.AtiveAttackSpecial(false);
    }
    public override void AttackSpecial()
    {
      
        if (m_states.currentEnergy < valueForAtatckSpecial) return;

        if (specialFairing.Equals(specialReady))
        {
             
            playerEnergiy.RemoveValue(valueForAtatckSpecial);
            Projectile projectile = Instantiate<Projectile>(prefabAttackSpecial);
            projectile.SetUpDirection(positionSpecialSpawn,transform.forward);

        }
        else
        {
            specialFairing = 0;
        }

      
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
