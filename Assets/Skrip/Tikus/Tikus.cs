using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tikus : MonoBehaviour
{
    [SerializeField] private float damage;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Nyawa>().TakeDamage(damage);
            Debug.Log("Kena tikus");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weak Point")
        {
            Destroy(collision.gameObject);
        }
    }

}

