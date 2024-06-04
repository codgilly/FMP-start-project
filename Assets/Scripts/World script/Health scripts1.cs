using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Healthscripts1 : MonoBehaviour
{
    Movingscript movingscript;
    [SerializeField]
    GameObject player;

    public Slider healthSlider;
    public float maxHealth;
    public float health;

    public PlayerK playerK;


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

    public void HealthCheck()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (health != healthSlider.value)
        {
            healthSlider.value = health;
        }

        if (health <= 0 && dead == 1)
        {
            playerK.GetComponent<EnemyAiTutorial>().DeadBoss();
            dead = 0;


        }
    }

   

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamage(10);
        }

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        playerK.SetSlider(health);
    }

    public void Healing(float Heal)
    {
        health += Heal;
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
