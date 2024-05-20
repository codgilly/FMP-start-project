using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject objectToFind;

    public enum CollideType
    {
        CollisionEnter,
        CollisionStay,
        CollisionExit,
    }

    private void Awake()
    {
        
    }
    private void Start()
    {
       // objectToFind = transform.GetChild(0).gameObject;
       // Debug.Log(objectToFind);
    }

    private void Update()
    {

    }



}
