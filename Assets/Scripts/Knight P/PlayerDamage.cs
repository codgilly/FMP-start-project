using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public GameObject EnemyHealth;
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Boss")
        {
            EnemyHealth.GetComponent<Healthscripts>().TakeDamage(damage);
            //DestroyObject(other.gameObject);
        }
    }
}
