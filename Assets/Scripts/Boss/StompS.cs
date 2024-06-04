using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompS : MonoBehaviour
{
    public GameObject boss;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss.GetComponent<EnemyAiTutorial>().Stomp();
        }
           
    }
}
