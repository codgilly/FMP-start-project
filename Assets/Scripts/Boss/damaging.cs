using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class damaging : MonoBehaviour
{
    public GameObject PlayerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.GetComponent<Healthscripts>().TakeDamage(9);
        }
    }
}
