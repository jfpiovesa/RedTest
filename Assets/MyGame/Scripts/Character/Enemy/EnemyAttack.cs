using UnityEngine;

public class EnemyAttack : AttackBase
{
    public override void Attack(string name, int layer)
    {
        base.Attack(name, layer);

        if (!m_states.canControl) return;
        if (!m_states.canAttack) return;


        NextAttack(name, layer);

    }

    public override void NextAttack(string name, int layer)
    {
        base.NextAttack(name, layer);

        if (!m_states.statePerformace.Equals(StatePerformace.None)) return;

        m_states.statePerformace = StatePerformace.Attack;
        m_animator.Play(name, layer);

        //countAttack++;

        //if (countAttack >= maxCountAttack)
        //{
        //    countAttack = 0;
        //}

    }
    public override void ReadyAttack()
    {
        m_states.statePerformace = StatePerformace.None;
    }
    public override void ResetAttack()
    {
        base.ResetAttack();
      //  countAttack = 0;
        m_states.statePerformace = StatePerformace.None;

    }

}
