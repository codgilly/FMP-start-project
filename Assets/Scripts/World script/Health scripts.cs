using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Healthscripts : MonoBehaviour
{
    Movingscript movingscript;
    [SerializeField]
    GameObject player;

    public GameObject objectToDestroy;

    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;

    public float damage;

    public float dead = 1;

    private void Awake()
    {
        movingscript = player.GetComponent<Movingscript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
        Test();
    }

    void HealthCheck()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if(health <= 0 && dead == 1)
        {
            dead = 0;
            movingscript.Dead();
        }
     
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            takeDamage(10);
        }
 
    }

    void takeDamage(float damage)
    {
        health -= damage;
    }
    void Partical()
    {
        GameObject Player = transform.GetChild(1).gameObject;
        ParticleSystem ps = Player.GetComponent<ParticleSystem>();

        ps.Play();
    }

    void EnemyDeath()
    {
        GameObject bottle = transform.GetChild(0).gameObject;
        ParticleSystem ps = bottle.GetComponent<ParticleSystem>();
        ps.Play();
    }
}
