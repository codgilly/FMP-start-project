using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemySlider : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    EnemyAiTutorial bossScript;
    public GameObject objectToDestroy;
    Animator animator;
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    GameObject boss;
    public PlayerK playerK;

    public float damage;

    public float dead = 1;

   

    private void Awake()
    {
        
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

        if (health <= 0 && dead == 1)
        {
            dead = 0;
            //Dead();
            animator.SetTrigger("die");
        }

        if(health > maxHealth)
        {
            health = 100;
        }
        
    }

   

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamage(10);
        }
    }

    public void deatoryedOnDeath()
    {
        Destroy(objectToDestroy);
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
