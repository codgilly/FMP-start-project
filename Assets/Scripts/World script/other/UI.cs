using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{


    Healthscripts healthscripts;
    // Start is called before the first frame update
    public GameObject pScreen;
    private void Awake()
    {
        pScreen.SetActive(false);
    }

    void Start()
    {
        healthscripts = GetComponent<Healthscripts>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthScreen();

    }

    void HealthScreen()
    {

    }




}
