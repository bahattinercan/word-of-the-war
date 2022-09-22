using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float attackDelay,finisherDelay;
    private Player player;
    public HealthController healthController;
    private AudioSource audioSource;
    public AudioClip damageAudio, damageAudio2;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        healthController = GetComponent<HealthController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void NormalAttack()
    {
        anim.Play("attack");
        StartCoroutine(AttackCo(15));        
    }

    public void FinisherAttack()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y - 180, transform.rotation.z));
        anim.Play("finisherAttack");
        StartCoroutine(AttackCo(100,"finisher"));
    }

    public void TakeDamage(int damage)
    {
        anim.Play("takeDamage");        
        healthController.DecreaseHealth(damage);
        if (healthController.isDead())
        {
            anim.Play("die");
            GameController.instance.WinTheGame();
        }
            
    }



    public IEnumerator AttackCo(int damage,string attackType="normal")
    {
        if(attackType=="normal")
            yield return new WaitForSeconds(attackDelay);
        else
            yield return new WaitForSeconds(finisherDelay);

        if (Random.Range(0, 2) == 1)
            audioSource.PlayOneShot(damageAudio);
        else
            audioSource.PlayOneShot(damageAudio2);
        player.TakeDamage(damage);
    }

}
