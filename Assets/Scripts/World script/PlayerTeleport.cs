using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleport : MonoBehaviour
{

    [SerializeField]GameObject player;
    [SerializeField] GameObject TeleportZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
