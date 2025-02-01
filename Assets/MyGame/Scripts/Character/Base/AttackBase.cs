using UnityEngine;

public class AttackBase : MonoBehaviour
{
    [Header("Vars")]
    public int currentCombo = 0;
    public int maxCombo = 0;
    public bool canCombo = false;
    public float comboTimer = 0f;
    public float comboDelay = 0.5f; 

    [Header("Componets")]
    public Animator  m_animator;
    public StatesCharacter m_states;


    public virtual void Attack(string name, int layer) { }

    public virtual void NextAttack(string name, int layer) { }

    public virtual void ReadyAttack(){    }

    public virtual void ResetAttack() { }

    public virtual void AttackSpecial() { }



}
