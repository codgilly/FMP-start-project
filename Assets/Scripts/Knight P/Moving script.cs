using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
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
    int iswalkingnoSword;
    int isrunning;

    
    Playercontroller input;

    Vector2 currentMovemnt;
    Vector2 cameraP;
    Vector3 Velocity;


    bool movementPressed;
    bool runPressed;

    Vector3 rotate;
      

    private void Awake()
    {

        state = States.IdleNA;

        input = new Playercontroller();


    }
    void Start()
    {
        animator = GetComponent<Animator>();

        iswalkingnoSword = Animator.StringToHash("WalkingNA");
        isrunning = Animator.StringToHash("Running");
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

        if ( state == States.RunNA )
        {
            RunNA();
        }

        if( state == States.IdelY)
        {
            IdleY();
        }

        if(state == States.WalkY)
        {
            WalkY();
        }

        if (state == States.RunY)
        {
            RunY();
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

        print("Current state=" + state);
    }

    void IdleNA()
    {

        print("idelNA");
        animator.SetBool("walkingNA", false);


        //check for walk

        // check for controller analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        if (  dir.x != 0 || dir.y != 0 || Input.GetKey("space"))
        {
            state = States.WalkNA;
            animator.SetBool("walkingNA", true);
        }

        //input.Charactercontrols.Jump.performed += ctx => ctx.ReadValueAsButton();
        

        //if( analog stick moved ) walking(): play animation left sticxk moves root allowing to spin 
 
        //DoBlock();

    }

   
    void WalkNA()
    {
        
        print("walking");

        

        // check for player letting go of analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        input.Charactercontrols.Movement.performed += ctx => rotate = ctx.ReadValue<Vector2>();

        Vector3 r = new Vector3 (rotate.z, rotate.x) * 100 * Time.deltaTime;
        transform.Rotate(r, Space.World);

        if (dir.x == 0 && dir.y == 0)
        {
            //this is an exit, set up what the player needs to do when chaning states
            state = States.IdleNA;
            animator.SetBool("walkingNA", false);
        }
        

        //DoBlock();

    }
    void RunNA()
    {
        
    }


    void IdleY()
    {

    }

    void WalkY()
    {

    }
    void RunY()
    {
        /*
        animator.SetBool(iswalkingnoSword, true);

        // check for player letting go of analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();
        if( dir.x == 0 && dir.y == 0 )
        {
            state = States.IdleNA;
        }

        DoBlock();
        */
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
        state = States.IdleNA;
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

    /*
    void Movement()
    {
        bool walkingnoSword = animator.GetBool(iswalkingnoSword);
        bool Running = animator.GetBool(isrunning);

        if(movementPressed && !walkingnoSword)
        {
            animator.SetBool(iswalkingnoSword, true);
        }

        if (!movementPressed && walkingnoSword)
        {
            animator.SetBool(iswalkingnoSword, false);
        }

        if ((movementPressed && runPressed) && !Running)
        {
            animator.SetBool(isrunning, true);
        }

        if ((!movementPressed || !runPressed) && Running)
        {
            animator.SetBool(isrunning, false);
        }

    }
    */

    private void OnEnable()
    {
        input.Charactercontrols.Enable();
    }

    private void OnDisable()
    {
        input.Charactercontrols.Disable();
    }
}
