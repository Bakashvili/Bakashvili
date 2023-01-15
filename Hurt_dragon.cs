using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;
public class Hurt_dragon : MonoBehaviour
{
    [SerializeField] private float StartHealth;
    public bool dead = false;
    public bool value;
    private Animator anim;
    private SpriteRenderer spriteRend;
    [SerializeField] private AudioClip injury_dr_Sound;
    [SerializeField] private AudioClip death_dr_Sound;
    [SerializeField] private GameObject sword_active_true;
    [SerializeField] public float CurrentHealth;
    private void Awake()
    {
        CurrentHealth = StartHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartHealth);

        if (CurrentHealth > 0)
        {
            SoundManager.instance.PlaySound(injury_dr_Sound);
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                SoundManager.instance.PlaySound(death_dr_Sound);
                spriteRend.color = new Color(1, 0, 0, 0.5f);
                anim.SetTrigger("dragondeath");
                //GetComponent<Enemy>().enabled = false;
                dead = true;
                Destroy(gameObject);
                //dead = true;
            }

        }

    }

    private IEnumerator Invunerability()
    {
        sword_active_true.SetActive(true);
        Physics2D.IgnoreLayerCollision(3, 6, true);
        spriteRend.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(1);
        spriteRend.color = Color.white;
        // yield return new WaitForSeconds(iFramesDuration / (NumberOfFlashes));
        Physics2D.IgnoreLayerCollision(3, 6, false);
        sword_active_true.SetActive(false);
    }
    public bool dead_fr()
    {
        return dead;
    }

}