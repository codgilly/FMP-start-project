using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

enum States
{
    IdleNA,
    WalkNA,
    RunNA,
    IdelY,
    WalkY,
    RunY,
    Jump,
    Block,
    Roll,
    Light,
    Heavy,
    Scream,
    JumpAttack,
    Drink,
    Rest,
    Equip,
    UnEquip,

};

public class Movingscript : MonoBehaviour
{
    States state;

    Animator animator;


    int wepon = 0;
    Playercontroller input;


    Vector3 rotate;



    
    private void Awake()
    {

        state = States.IdleNA;

        input = new Playercontroller();


    }
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        DoLogic();

        //        Movent();

        //      print("v2= " + input.Charactercontrols.Movement.ReadValue<Vector2>() );



    }

    
    void DoLogic()
    {
        switch( state )
        {
            case States.IdleNA:
                IdleNA();
            break;

                
        }

        if (state == States.WalkNA)
        {
            WalkNA();
        }


        if( state == States.IdelY)
        {
            IdleY();
        }

        if(state == States.WalkY)
        {
            WalkY();
        }


        if (state == States.Jump)
        {
            Jump();
        }

        if(state == States.Block)
        {
            DoBlock();
        }

        if(state == States.Roll)
        {
            Roll();
        }

        if(state == States.Light)
        {
            Light();
        }

        if(state == States.Heavy)
        {
            Heavy();
        }

        if(state == States.Scream)
        {
            Scream();
        }

        if(state == States.JumpAttack)
        {
            JumpAttack();  
        }

        if(state == States.Drink)
        {
            Drink();
        }

        if(state == States.Rest)
        {
            Rest();
        }

        if(state == States.Equip)
        {
            Equip();
        }

        if(state == States.UnEquip)
        {
            UnEquip();
        }

       // print("Current state=" + state);
    }

    void IdleNA()
    {

        //print("idelNA");


        //check for walk

        // check for controller analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        if (  dir.x != 0 || dir.y != 0)
        {
            state = States.WalkNA;
            animator.SetBool("walkingNA", true);
        }

        if (Input.GetKey(KeyCode.JoystickButton0)) //A
        {
            state = States.Jump;
            Jump();
        }
        if (Input.GetKey(KeyCode.JoystickButton3)) //Y
        {
            state = States.Equip;
            animator.SetBool("Unsheeth", true);
            Unsheeth();
        }
        if (Input.GetKey(KeyCode.JoystickButton2)) //X
        {
            state = States.Drink;
            Drink();
        }
        if (Input.GetKey(KeyCode.JoystickButton4)) //Scream
        {
            state = States.Scream;
            Scream();
        }
        if (Input.GetKey(KeyCode.JoystickButton5)) //light 
        {

            state = States.Light;
            Light();
        }

        if (Input.GetKey(KeyCode.JoystickButton7)) // puase
        {
            Pause();
        }
       
        
        //input.Charactercontrols.Jump.performed += ctx => ctx.ReadValueAsButton();


        //if( analog stick moved ) walking(): play animation left sticxk moves root allowing to spin 

        //DoBlock();

    }
    void Pause()
    {

    }
   
    void WalkNA()
    {
        
        //print("walking");

        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        input.Charactercontrols.Movement.performed += ctx => rotate = ctx.ReadValue<Vector2>();

        
        Vector3 r = new Vector3 (rotate.z, rotate.x) * 100 * Time.deltaTime;
        transform.Rotate(r, Space.World);




        if (Input.GetKey(KeyCode.JoystickButton1))
        {
            //Debug.Log("wohoo!!");
            state = States.RunNA;
            animator.SetBool("RunningNA", true);
        }
        else
        {
            state = States.WalkNA;
            animator.SetBool("RunningNA", false);
        }

        if (dir.x == 0 && dir.y == 0)
        {
            //this is an exit, set up what the player needs to do when chaning states
            state = States.IdleNA;
            animator.SetBool("walkingNA", false);
            animator.SetBool("RunningNA", false);
        }
        

    }

    void Unsheeth()
    {
        wepon = 1;
        //animator.SetBool("Unsheeth", false);
        animator.SetBool("IdelY", true);
        state = States.IdelY;
        IdleY();
    }

    void Sheeth()
    {
        wepon = 0;
        IdleNA();
    }

    void IdleY()
    {
        if (Input.GetKey(KeyCode.JoystickButton3) && wepon == 1) //Y
        {
            animator.SetBool("sheeth", true);
            state = States.UnEquip;
            Sheeth();
        }
    }

    void WalkY()
    {

    }
    
    void Jump()
    {

    }
        
    void DoBlock()
    {
        // add code to perform block with L1


    }


    public void BlockEnded()
    {
        state = States.IdelY;
    }

    void Roll()
    {
        
    }

    void Light()
    {

    }

    void Heavy()
    {

    }

    void Scream()
    {

    }

    void JumpAttack()
    {

    }

    void Drink()
    {

    }

    void Rest()
    {

    }

    void Equip()
    {

    }

    void UnEquip()
    {

    }

    private void OnEnable()
    {
        input.Charactercontrols.Enable();
    }

    private void OnDisable()
    {
        input.Charactercontrols.Disable();
    }
}
