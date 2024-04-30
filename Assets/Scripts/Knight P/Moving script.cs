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
    public Playercontroller input;

    Vector2 move;

    Vector3 rotate;



    
    private void Awake()
    {

        state = States.IdleNA;

        input = new Playercontroller();
        input.Charactercontrols.Movement.performed += ctx => Debug.Log(ctx.ReadValueAsObject());

    }
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();

        
    }


    void DoLogic()
    {
        switch( state )
        {
            case States.IdleNA:
                IdleNA();
            break;

            case States.WalkNA:
                WalkNA();
            break ;

            case States.IdelY:
                IdleY();
            break;

            case States.WalkY:
                WalkY();
            break;

            case States.Jump:
                Jump();
            break;

            case States.Block:
                DoBlock();
            break;

            case States.Roll:
                Roll();
            break;

            case States.Light:
                Light();
            break;

            case States.Heavy:
                Heavy();
            break;

            case States.Scream:
                Scream();
            break;

            case States.JumpAttack:
                JumpAttack();
            break;

            case States.Drink:
                Drink();
            break;

            case States.Rest:
                Rest();
            break;

            case States.Equip:
                Unsheeth();
            break;

            case States.UnEquip:
                Sheeth();
            break;

        }

    }

    void IdleNA()
    {

        print("idleNA");

        input.Charactercontrols.Movement.performed += ctx => Debug.Log(ctx.ReadValueAsObject());

        // check for controller analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        if (dir.x != 0 || dir.y != 0)
        {
            state = States.WalkNA;
            animator.SetBool("walkingNA", true);
        }

        if (Input.GetKey(KeyCode.JoystickButton0)) //A
        {
            state = States.Jump;
            
        }
        if (Input.GetKey(KeyCode.JoystickButton3) && wepon == 0) //Y
        {
            state = States.Equip;
            animator.SetBool("Unsheeth", true);
            
        }
        if (Input.GetKey(KeyCode.JoystickButton2)) //X
        {
            //state = States.Drink;
            animator.SetBool("Drink", true);
            
        }
        if (Input.GetKey(KeyCode.JoystickButton4)) //Scream
        {
           
            state = States.Scream;
            animator.SetBool("Scream", true);
            
        }

        if (Input.GetKey(KeyCode.JoystickButton1)) //B
        {
            state = States.Roll;
            animator.SetBool("Roll", true);
            
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


        Vector3 r = new Vector3(rotate.z, rotate.x) * 100 * Time.deltaTime;
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

        state = States.IdelY;
        
    }

    void Sheeth()
    {
        wepon = 0;
        state = States.IdleNA;
    }

    void IdleY()
    {

        animator.SetBool("IdelY", true);
        //animator.SetBool("Unsheeth", false);

        /*
        if (Input.GetKey(KeyCode.JoystickButton3) && wepon == 1) //Y
        {
            animator.SetBool("sheeth", true);
            state = States.UnEquip;
            Sheeth();
        }
        */
        if (Input.GetKey(KeyCode.JoystickButton5)) //light 
        {
            animator.SetBool("Light", true);
            //state = States.Light;
            
        }

        if (Input.GetKey(KeyCode.JoystickButton1)) //B
        {
            state = States.Roll;
            animator.SetBool("Roll", true);
            Roll();
        }

        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        if (dir.x != 0 || dir.y != 0)
        {
            state = States.WalkY;
            animator.SetBool("walkingY", true);
        }

        if (Input.GetKey(KeyCode.JoystickButton2)) //X
        {
            state = States.Drink;

        }

        if (Input.GetKey(KeyCode.JoystickButton4)) //Scream
        {

            //state = States.Scream;
            animator.SetBool("Scream", true);

        }
    }

    void WalkY()
    {
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        input.Charactercontrols.Movement.performed += ctx => rotate = ctx.ReadValue<Vector2>();


        Vector3 r = new Vector3(rotate.z, rotate.x) * 100 * Time.deltaTime;
        transform.Rotate(r, Space.World);
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
        
        print("rolled");

      
    }

    public void RollFinished()
    {
        print("roll finished");
        if (wepon == 0)
        {
            animator.SetBool("Roll", false);
            state = States.IdleNA;
            //IdleNA();
        }
        if (wepon == 1)
        {
            animator.SetBool("Roll", false);
            state = States.IdelY;
            //IdleY();
        }
    }

    void Light()
    {
        animator.SetBool("Light", false);
        state = States.IdelY;
    }

    void Heavy()
    {

    }

    void Scream()
    {
        print("Scream finished");
        
        if (wepon == 0)
        {
            animator.SetBool("Scream", false);
            state = States.IdleNA;
        }
        if (wepon == 1)
        {
            animator.SetBool("Scream", false);
            state = States.IdelY;
        }
        
    }
    void JumpAttack()
    {

    }

    void Drink()
    {
        print( state + "finished");
        if (wepon == 0)
        {
            animator.SetBool("Drink", false);
            state = States.IdleNA;
            //IdleNA();
        }
        if (wepon == 1)
        {
            animator.SetBool("Drink", false);
            state = States.IdelY;
            //IdleY();
        }

    }

    void Rest()
    {

    }

    void OnEndable()
    {
        input.Charactercontrols.Enable();
    }

    private void OnDisable()
    {
        input.Charactercontrols.Disable();
    }
}
