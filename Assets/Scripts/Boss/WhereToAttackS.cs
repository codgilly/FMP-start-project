using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WhereToAttackS : MonoBehaviour
{
    EnemyAiTutorial bossScript;
    public NavMeshAgent navMeshAgent;
    public Transform Player;
    // Start is called before the first frame update
    private void Awake()
    {
        bossScript = GetComponent<EnemyAiTutorial>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {

            navMeshAgent.SetDestination(Player.position);

        }

        
    }
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {

            navMeshAgent.SetDestination(Player.position);

        }


    }


}
