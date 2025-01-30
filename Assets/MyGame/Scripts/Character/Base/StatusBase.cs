using UnityEngine;

public class StatusBase : MonoBehaviour
{
    public StatesCharacter m_state;
    public Animator m_aniamotor;
     
    public virtual void Inicialized() { }

    public virtual void RemoveValue(float damageValue) { }

    public virtual void RecoveryValue(float recoveryhValue) { }

    public virtual void Action(DamageData damageDataValue) { }

    public virtual void RecoveryFull() {  }

    public virtual void ChangeValue(float value) { }




}
