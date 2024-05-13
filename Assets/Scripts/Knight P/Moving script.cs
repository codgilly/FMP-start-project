using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.Android.Gradle;
using Unity.Android.Gradle.Manifest;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.DefaultInputActions;

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
    hit,

};

public class Movingscript : MonoBehaviour
{
    States state;

   
    Animator animator;

    
    int wepon = 0;
    public Playercontroller input;
    
    Vector3 rotate;




    float h,v;
   
    public bool joystickPressed = false;
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

            case States.hit:
                Hit();
            break;

        }

    }
    void IdleNA()
    {
        
        animator.SetBool("sheeth", false);
        print("idleNA");

        input.Charactercontrols.Movement.performed += ctx => Debug.Log(ctx.ReadValueAsObject());
        
      
        if (GetStickMagnitude() > 0.1f)
        {
            animator.SetBool("walkingNA", true);
            state = States.WalkNA;
            joystickPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3) && wepon == 0) //Y
        {
            state = States.Equip;
            animator.SetBool("Unsheeth", true);
            
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2)) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);
            //animator.SetBool("Drink", false);

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {
           
            state = States.Scream;
            animator.SetBool("Scream", true);
            
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton7)) // puase
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
        //get v & h and get the magnitued of them, and .normalise 

        Vector2 aim = Gamepad.current.leftStick.ReadValue();
        Vector3 direction = new Vector3(aim.x, 0, aim.y); //if you're 2d side scroller, you need to swap 2nd and 3rd value.
        transform.rotation = Quaternion.LookRotation(direction);

        Debug.Log(Gamepad.current.leftStick.x.ReadValue());

        Debug.Log(Gamepad.current.leftStick.y.ReadValue());

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            //Debug.Log("wohoo!!");
            //state = States.RunNA;
            animator.SetBool("RunningNA", true);
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            
            animator.SetBool("RunningNA", false);
        }


        if (GetStickMagnitude() < 0.1f)
        {
            animator.SetBool("walkingNA", false);
            animator.SetBool("RunningNA", false);
            state = States.IdleNA;
        }


        if (Input.GetKeyDown(KeyCode.JoystickButton3) && wepon == 0) //Y
        {
            state = States.Equip;
            animator.SetBool("Unsheeth", true);

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2)) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);
            //animator.SetBool("Drink", false);

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {

            state = States.Scream;
            animator.SetBool("Scream", true);

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton7)) // puase
        {
            Pause();
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
        if (Input.GetKeyDown(KeyCode.JoystickButton5)) //light 
        {
            animator.SetBool("Light", true);
            //state = States.Light;
            
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1)) //B
        {
            state = States.Roll;
            animator.SetBool("Roll", true);
            Roll();
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2)) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {
            state = States.Scream;
            animator.SetBool("Scream", true);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3) && wepon == 1) //Y
        {
            state = States.UnEquip;
            animator.SetBool("Unsheeth", false);
            animator.SetBool("IdelY", false);
            animator.SetBool("sheeth", true);

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0)) //A
        {
            animator.SetBool("Jump", true);
            state = States.Jump;

        }

        if (GetStickMagnitude() > 0.1f)
        {
            animator.SetBool("WalkY", true);
            state = States.WalkY;
            joystickPressed = true;
        }
    }

    void WalkY()
    {
        
        Vector2 aim = Gamepad.current.leftStick.ReadValue();
        Vector3 direction = new Vector3(aim.x, 0, aim.y); //if you're 2d side scroller, you need to swap 2nd and 3rd value.
        transform.rotation = Quaternion.LookRotation(direction);

        if(GetStickMagnitude() < 0.1f)
        {
            animator.SetBool("WalkY", false);
            state = States.IdelY;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton5)) //light 
        {
            animator.SetBool("WalkY", false);
            animator.SetBool("Light", true);
            //state = States.Light;

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1)) //B
        {
            state = States.Roll;
            animator.SetBool("Roll", true);
            //Roll();
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2)) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {
            animator.SetBool("Scream", true);
            state = States.Scream;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3) && wepon == 1) //Y
        {
            state = States.UnEquip;
            animator.SetBool("Unsheeth", false);
            animator.SetBool("IdelY", false);
            animator.SetBool("sheeth", true);

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0)) //A
        {
            animator.SetBool("Jump", true);
            state = States.Jump;

        }
    }
    


    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.JoystickButton5) && wepon == 1)
        {

            state = States.JumpAttack;
            animator.SetBool("JumpAttack", true);
        }
        if (wepon == 0)
        {
            animator.SetBool("Jump", false);
            state = States.IdleNA;
            //IdleNA();
        }
        if (wepon == 1)
        {
            animator.SetBool("Jump", false);
            state = States.IdelY;
            //IdleY();
        }
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
        animator.SetBool("Jump", false);
        animator.SetBool("JumpAttack", false);
        state = States.IdelY;
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

    void Hit()
    {
        //when hit
    }

    void OnEndable()
    {
        //move = CharacterController.Player.Move;
        input.Charactercontrols.Enable();
    }

    float GetStickMagnitude()
    {
        float h, v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector2 vec = new Vector2(h, v);
        float mag = vec.magnitude;
        return mag;
    }
}
