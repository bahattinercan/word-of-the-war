using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Enemy enemy;
    public float normalAttackDelay, finisherAttackDelay;
    public HealthController healthController;
    private AudioSource audioSource;
    public AudioClip damageAudio, damageAudio2;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        healthController = GetComponent<HealthController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void NormalAttack()
    {
        anim.Play("attack");
        StartCoroutine(NormalAttackCo(10));
    }

    private IEnumerator NormalAttackCo(int damage, string attackType = "normal")
    {
        if (attackType == "normal")
            yield return new WaitForSeconds(normalAttackDelay);
        else
            yield return new WaitForSeconds(finisherAttackDelay);

        if (Random.Range(0, 2) == 1)
            audioSource.PlayOneShot(damageAudio);
        else
            audioSource.PlayOneShot(damageAudio2);

        enemy.TakeDamage(damage);
    }

    public void FinishedAttack()
    {
        anim.Play("finisherAttack");
        StartCoroutine(NormalAttackCo(100));
    }

    public void TakeDamage(int damage)
    {
        healthController.DecreaseHealth(damage);
        if (healthController.isDead())
        {
            StartCoroutine(Die());
        }
        else
        {
            anim.Play("TakeDamage");
           
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(.5f);
        anim.Play("die");
        transform.Rotate(new Vector3(transform.rotation.x, transform.position.y - 180, transform.rotation.z));
        GameController.instance.LoseTheGame();
    }
}
