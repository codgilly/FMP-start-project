using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestSite : MonoBehaviour
{
    public GameObject Player;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Player.GetComponent<Movingscript>().StopRest();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Text.SetActive(true);
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Player.GetComponent<Movingscript>().Rest();
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                Text.gameObject.GetComponent<TextMeshProUGUI>().text = ("Press A to Rest");
                Player.GetComponent<Movingscript>().StopRest();
            }
        }
    }

    public void textUpdate()
    {
        Text.gameObject.GetComponent<TextMeshProUGUI>().text = ("Press B to leave");
    }


    private void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }
}
