using System;
using System.Collections;
using UnityEngine;

public class UI_FadeTransition : MonoBehaviour
{


    public Animator m_animatorFade;

    Coroutine m_Coroutine;
    public void Inicialized()
    {
        if (m_animatorFade == null)
        {
            m_animatorFade = GetComponent<Animator>();
        }
    }
    // methods
    public void PlayAnimationFinish(string nameAnimation, Action actionFinish)
    {
        if (m_animatorFade == null) return;

        m_Coroutine = StartCoroutine(AnimatioFinish(nameAnimation,actionFinish));

    }

    public void PlayAnimationBeginh(string nameAnimation, Action actionFinish)
    {
        if (m_animatorFade == null) return;

        actionFinish?.Invoke();
        m_animatorFade.Play(nameAnimation);
        float timeWait = m_animatorFade.GetCurrentAnimatorClipInfo(0).Length;
    }


    // IEnumerator
    IEnumerator AnimatioFinish(string nameAnimation, Action actionFinish)
    {
        m_animatorFade.Play(nameAnimation);
        float timeWait = m_animatorFade.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(timeWait);
        actionFinish?.Invoke();
    }
}
