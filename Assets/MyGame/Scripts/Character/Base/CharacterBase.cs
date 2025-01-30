using System;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public StatusBase m_health;
    public StatesCharacter m_states;

    public virtual void Inicialized() { }

    public virtual void Moviment() { }

    public virtual void CheckGround() { }

    public virtual void Teleportation(Vector3 valuePosition, Quaternion valueRotation, Action succesAction)
    {
        transform.SetPositionAndRotation(valuePosition, valueRotation);
    }

}
