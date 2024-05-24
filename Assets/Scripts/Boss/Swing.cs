using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    //EnemyAiTutorial bossScript;
    public GameObject boss;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        //bossScript = GetComponent<EnemyAiTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("enterted swing");
            boss.GetComponent<EnemyAiTutorial>().Swing();
        }
            
    }
}
