using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    Healthscripts healthscripts;

    public float damage;

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

    void OnTriggerEnter(Collider other)
    {
        print("dead");
        healthscripts.health =- damage;
    }
        
    
}
