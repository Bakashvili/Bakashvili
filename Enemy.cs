using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    [SerializeField] private float damage;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    public bool injury_hero = false;
    private void Awake()
    {
   
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
    private void FixedUpdate()
    {

        if(movingLeft)
        {
            if(transform.position.x  > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3((float)0.15, (float)0.15, (float)0.15);
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
                transform.localScale = new Vector3(-(float)0.15, (float)0.15, (float)0.15);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<heartsystem>().TakeDamage(damage);
            //CanInjuryAnim();
           // OnTriggerEnter2D

        }   

    }
    //public bool CanInjuryAnim()
    //{
    //    return injury_hero == true;
    //}
}
