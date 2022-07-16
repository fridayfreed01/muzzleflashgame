using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public bool IsDead = false;

    public Animator anim;

    public AudioClip clip;
    public AudioSource audioSource;

    public float Delay = 0.0f;

    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(LoopAudio());
    }

    void Update()
    {
   
    }

    IEnumerator LoopAudio()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = clip;

        float length = GetComponent<AudioSource>().clip.length;

        while (true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(length + 8f);
        }
    }

    

    public void TakeDamage (float amount)
    {

        health -= amount; 
        if (health <= 0f)
        { 
            Die();
        }
    }

    void Die ()
    {
        IsDead = true;

        anim.SetTrigger("death");
        
        Destroy(gameObject, 5f);
    }
}
