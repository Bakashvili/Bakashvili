using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction; //для enemy и hero
    private bool hit;
    public bool value = false;
    [SerializeField] private float damage;
    //private float direction;
    private Animator anim; // для enemy и hero
    private BoxCollider2D BoxCollider;
    void Awake()
    {
        anim = GetComponent<Animator>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            hit = true;
            // = true;
            BoxCollider.enabled = false;
            anim.SetTrigger("attack_sword");
            collision.GetComponent<Hurt>().TakeDamage(damage);
            // anim.SetTrigger("re");
            value = true;

        }
        if (collision.CompareTag("Respawn"))
        {

            hit = true;
            // = true;
            BoxCollider.enabled = false;
            anim.SetTrigger("attack_sword");
            collision.GetComponent<Hurt_dragon>().TakeDamage(damage);
            //anim.SetTrigger("re");
            value = true;

        }

    }
    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        BoxCollider.enabled = true;
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
