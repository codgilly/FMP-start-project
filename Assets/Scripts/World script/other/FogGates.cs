using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGates : MonoBehaviour
{
    public GameObject HealthScreen;
    public Transform teleport;
    private void Awake()
    {
        HealthScreen.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {

    }



    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            HealthScreen.gameObject.SetActive(true);
        }

        if (plyr.gameObject.tag == "Boss")
        {
            transform.position = teleport.position;
        }

    }

}
