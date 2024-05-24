using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageScript : MonoBehaviour
{
    Healthscripts healthscripts;
    Movingscript Movingscript;
    public float damage;
    public Slider health;
    public enum CollideType
    {
        CollisionEnter,
        TriggerEnter,
    }
    void Awake()
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
        healthscripts.TakeDamage(damage);
    }


}
