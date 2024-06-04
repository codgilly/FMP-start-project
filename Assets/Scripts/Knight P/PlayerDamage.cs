using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public GameObject EnemyHealth;
    public float damage;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Boss")
        {
            EnemyHealth.GetComponent<Healthscripts1>().TakeDamage(damage);
            //DestroyObject(other.gameObject);
        }
    }

    private void Update()
    {
        if(damage == 35)
        {
            Invoke("Damage", 1);
        }
    }

    void Damage()
    {
        damage = 20;
    }
}
