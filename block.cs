using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<heartsystem>().TakeDamage(damage);

        }
        //�������� � ���������� ��������(����) ����� �������� �� ����� �7 ��� ��������

    }
}
