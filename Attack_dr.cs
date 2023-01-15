using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack_dr : MonoBehaviour
{
    private bool value = true;
    [SerializeField] private float AttackCooldowm;
    private Animator anim;
    [SerializeField] private float damage;
    private Hero move;
    // [SerializeField] private AudioClip attack_sword_Sound;
    [SerializeField] private AudioClip dragon_attack_Sound;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
   // [SerializeField] private GameObject fireball;
    private float cooldownTimer = Mathf.Infinity;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    //public bool injury_hero = false;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        //move = GetComponent<Hero>();
         leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
   
    private void FixedUpdate()
    {

        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3((float)0.4785466, (float)0.519052, (float)0.4393065);
               // fireball.transform.localScale = new Vector3((float)1, (float)1, (float)1);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3((float)-0.4785466, (float)0.519052, (float)0.4393065);
                //fireball.transform.localScale = new Vector3((float)-1, (float)1, (float)1);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
    private void Update()
    {
        if (cooldownTimer > AttackCooldowm )
        {
            Attackhero();
            cooldownTimer += Time.deltaTime;

        }
    }
    private void Attackhero()
    {
       if (GetComponent<box_script>().can()) 
       { 
         SoundManager.instance.PlaySound(dragon_attack_Sound);
         //SoundManager.instance.PlaySound(attack_sword_Sound);
         cooldownTimer = 0;
         // anim.SetTrigger("attack");// для гл.героя
         anim.SetTrigger("attack_dragon");
          for (int i = 0; i < 10; i++) 
          { 
            fireballs[i].transform.position = firepoint.position + (i * firepoint.position);
            fireballs[i].GetComponent<ball>().SetDirection(Mathf.Sign(transform.localScale.x));
          }
       }
    }
    

}
