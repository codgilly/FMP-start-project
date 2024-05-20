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

    public PlayerK playerK;

    public float damage;

    public float timesHealed = 5;

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

        if (health != healthSlider.value)
        {
            healthSlider.value = health;
        }

        if (health <= 0 && dead == 1)
        {
            dead = 0;
            //Dead();
            movingscript.Dead();
            
        }

        if(health > maxHealth)
        {
            health = 100;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) && timesHealed >= 1)
        {
            Healing(40);
            timesHealed--;
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
