using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody rp;
    public float speed;
    public float timDiseble = 30f;

    Coroutine coroutine;
    private void OnEnable()
    {
        coroutine = StartCoroutine(TimeDiseble());
    }
    private void OnDisable()
    {
        coroutine = null;
    }
    public void SetUpDirection(Transform potionStart, Vector3 direction)
    {
        if (rp == null)
        {
            Debug.LogError("Rigidbody n�o atribu�do ao proj�til!");
            return;
        }

        this.gameObject.SetActive(true);
        this.transform.position = potionStart.position;

        rp.linearVelocity = Vector3.zero; 
        rp.angularVelocity = Vector3.zero; 
        rp.AddForce(direction, ForceMode.Impulse);

    }
    IEnumerator TimeDiseble()
    {
        yield return new WaitForSeconds(timDiseble); 
        this.gameObject.SetActive(false);   
    }

}
