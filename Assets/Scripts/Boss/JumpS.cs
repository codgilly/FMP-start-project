using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpS : MonoBehaviour
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
        boss.GetComponent<EnemyAiTutorial>().Jump();
    }
}
