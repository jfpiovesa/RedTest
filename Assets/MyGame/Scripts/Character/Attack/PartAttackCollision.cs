using UnityEngine;

public class PartAttackCollision : MonoBehaviour
{

    public PartAttack partAttack = PartAttack.None;

    public DamageData damage = new DamageData();

    public bool enableDamage = false;

    public float attackRange = 1f;

    public LayerMask enemyLayer;

    public AudioClip[] attackHit;
    public AudioSource attackSound;

    private void OnTriggerStay(Collider other)
    {
        if (!enableDamage) return;

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Vector3 hitPoint = enemy.ClosestPoint(transform.position);
            Vector3 knockDir = (enemy.transform.position - transform.position).normalized;

            damage.knockDirection = knockDir;
            TakeDamage(enemy.gameObject, hitPoint);
        }
    }
    public void TakeDamage(GameObject charcterValue, Vector3 position)
    {
        enableDamage = false;

        if (charcterValue == null) return;


        I_DamageTake<DamageData> damageTake = charcterValue.GetComponent<I_DamageTake<DamageData>>();

        if (damageTake == null) return;

        Effect(position);
        AudioPlayt();

        damageTake.ApplyDamage(damage);

    }
    public void Effect(Vector3 position)
    {
        if (damage.effectPrefab == null) return;

        GameObject effect = Instantiate(damage.effectPrefab);
        effect.transform.position = position;


    }
    public void AudioPlayt()
    {
        attackSound.clip = attackHit[Random.Range(0, attackHit.Length)];
        attackSound.Play();

    }
    public void EnableDamage()
    {
        enableDamage = true;
    }
    public void DisableDamage()
    {
        enableDamage = false;
    }
}
