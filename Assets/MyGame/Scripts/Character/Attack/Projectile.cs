using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody rp;
    public float speed;
    public float timDiseble = 30f;


    [Header("Damage")]

    public PartAttack partAttack = PartAttack.None;

    public DamageData damage = new DamageData();

    public float attackRange = 1f;

    public LayerMask enemyLayer;

    public AudioClip[] attackHit;
    public AudioSource attackSound;


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
            Debug.LogError("Rigidbody não atribuído ao projétil!");
            return;
        }

        this.gameObject.SetActive(true);
        this.transform.position = potionStart.position;
        this.transform.rotation = potionStart.rotation;

        rp.linearVelocity = Vector3.zero;
        rp.angularVelocity = Vector3.zero;
        rp.AddForce(direction * 10f, ForceMode.Impulse);

    }
    private void OnTriggerEnter(Collider other)
    {

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Vector3 hitPoint = enemy.ClosestPoint(transform.position);
            Vector3 knockDir = (enemy.transform.position - transform.position).normalized;

            damage.knockDirection = knockDir;
            TakeDamage(enemy.gameObject);
        }

        if (other.gameObject != null)
        {
            Destroy(this.gameObject,0.3f);
        }

    }
    public void TakeDamage(GameObject charcterValue)
    {

        if (charcterValue == null) return;


        I_DamageTake<DamageData> damageTake = charcterValue.GetComponent<I_DamageTake<DamageData>>();

        if (damageTake == null) return;

        AudioPlayt();

        damageTake.ApplyDamage(damage);

        Destroy(this.gameObject);


    }
    public void AudioPlayt()
    {
        attackSound.clip = attackHit[Random.Range(0, attackHit.Length)];
        attackSound.Play();

    }
    IEnumerator TimeDiseble()
    {
        yield return new WaitForSeconds(timDiseble);
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject, 03f);
    }
}
