
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyAiTutorial : MonoBehaviour
{
    Animator animator;
    EnemySlider enemySlider;
    WhereToAttackS whenToAttack;
    Swing swing;
    StompS stomp;
    JumpS jump;

    Healthscripts healthscript;


    public float bossHealth;

    private void Awake()
    {
        
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        

    }

    public void Test()
    {
        enemySlider.TakeDamage(20);
    }
    public void DeadBoss()
    {
        False();
        print("dead boss script");
        animator.SetTrigger("deadBoss");
    }
    public void Jump()
    {
        animator.SetBool("jump", true);
    }
    public void Stomp()
    {
        animator.SetBool("stomp", true);
    }
    public void Swing()
    {
        animator.SetBool("swing", true);
    }
    void winningScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void False()
    {
        animator.SetBool("swing", false);
        animator.SetBool("stomp", false);
        animator.SetBool("jump", false);
    }



}



