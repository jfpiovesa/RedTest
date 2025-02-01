using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UI_Main : MonoBehaviour
{


    [SerializeField] private Image barHealth;
    [SerializeField] private Image barSpecial;

    [Header("Special")]
    [SerializeField] private GameObject contentChangeAttackSpecial;
    [SerializeField] private Image imageChangeAttackSpecial;

    Coroutine coroutine;
    private void Awake()
    {
        OS_PlayerInGame.A_healthChange += ChangeBarHealth;
        OS_PlayerInGame.A_SpecialChange += ChangeBarSpecial;
        OS_PlayerInGame.A_ActiveAttackSpecial += EnablecontentChangeAttackSpecial;
        OS_PlayerInGame.A_ChangeAttackSpecial += ChangeAttackSpecial;
    }

    private void OnEnable()
    {
        OS_PlayerInGame.A_healthChange += ChangeBarHealth;
        OS_PlayerInGame.A_SpecialChange += ChangeBarSpecial;
        OS_PlayerInGame.A_ActiveAttackSpecial += EnablecontentChangeAttackSpecial;
        OS_PlayerInGame.A_ChangeAttackSpecial += ChangeAttackSpecial;
    }
    private void OnDisable()
    {
        OS_PlayerInGame.A_ActiveAttackSpecial -= EnablecontentChangeAttackSpecial;
        OS_PlayerInGame.A_ChangeAttackSpecial -= ChangeAttackSpecial;
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
    public void EnablecontentChangeAttackSpecial(bool value)
    {
        if (barSpecial == null) return;

        if (value == true)
        {
            imageChangeAttackSpecial.fillAmount = 1;
            contentChangeAttackSpecial.SetActive(true);
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
        else
        {
            coroutine = StartCoroutine(ActiveObeject(false, contentChangeAttackSpecial));
        }
    }

    public void ChangeAttackSpecial(float value)
    {
        if (barSpecial == null) return;
        imageChangeAttackSpecial.fillAmount = Mathf.Lerp(1f, 0f, value);
    }
    public void RecoverEnergy()
    {
        OS_PlayerInGame.Player.GetComponent<PlayerEnergiy>().RecoveryFull();
    }

    IEnumerator ActiveObeject(bool valueActive, GameObject gbActive)
    {

        yield return new WaitForSeconds(0.5f);
        gbActive?.SetActive(valueActive);

    }
}
