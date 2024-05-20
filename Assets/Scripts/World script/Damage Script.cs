using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    Healthscripts healthscripts;
    Movingscript Movingscript;
    public float damage;
    public enum CollideType
    {
        CollisionEnter,
        TriggerEnter,
    }
    void awake()
    {   
        healthscripts = GetComponent<Healthscripts>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("dead");
            Movingscript.Dead();

            other.GetComponent<Healthscripts>().TakeDamage(damage);
        }
    }


}
