using UnityEngine;
using UnityEngine.UI;


public class UI_Main : MonoBehaviour
{


    [SerializeField] private Image barHealth;
    [SerializeField] private Image barSpecial;

    private void Awake()
    {
        OS_PlayerInGame.A_healthChange += ChangeBarHealth;
        OS_PlayerInGame.A_SpecialChange += ChangeBarSpecial;
    }

    private void OnEnable()
    {
        OS_PlayerInGame.A_healthChange += ChangeBarHealth;
        OS_PlayerInGame.A_SpecialChange += ChangeBarSpecial;
    }
    private void OnDisable()
    {
        OS_PlayerInGame.A_healthChange -= ChangeBarHealth;
        OS_PlayerInGame.A_SpecialChange -= ChangeBarSpecial;
    }
    public void ChangeBarHealth(float value)
    {
        if (barHealth == null) return;
        barHealth.fillAmount = value;
    }
    public void ChangeBarSpecial(float value)
    {
        if (barSpecial == null) return;
        barSpecial.fillAmount = value;

    }

    public void  RecoverEnergy()
    {
        OS_PlayerInGame.Player.GetComponent<PlayerEnergiy>().RecoveryFull();
    }
}
