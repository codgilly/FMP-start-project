using System.Collections;
using System.Collections.Generic;
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

    string WalkingNA;
    Playercontroller input;

    Vector2 currentMovemnt;
    Vector2 cameraP;
    Vector3 Velocity;


    bool movementPressed;
    bool runPressed;

    

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
        if( state == States.IdleNA )
        {
            IdleNA();
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

        }

        if(state == States.Block)
        {

        }

        if(state == States.Roll)
        {

        }

        if(state == States.Light)
        {

        }

        if(state == States.Heavy)
        {

        }

        if(state == States.Scream)
        {

        }

        if(state == States.JumpAttack)
        {

        }

        if(state == States.Drink)
        {

        }

        if(state == States.Rest)
        {

        }

        if(state == States.Equip)
        {

        }

        if(state == States.UnEquip)
        {

        }

        print("Current state=" + state);
    }

    void IdleNA()
    {

        print("idelNA");
        animator.SetBool(WalkingNA, false);

        // check for controller analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        if (  dir.x != 0 || dir.y != 0 || Input.GetKey("space"))
        {
            state = States.WalkNA;
        }


        //if( analog stick moved ) walking(): play animation left sticxk moves root allowing to spin 
 
        DoBlock();

    }

    void RunNA()
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

    void WalkNA()
    {
        
        print("walking");

        animator.SetBool(WalkingNA, true);

        // check for player letting go of analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();
        if (dir.x == 0 && dir.y == 0)
        {
            state = States.IdleNA;
        }
        

        if(Input.GetKey("q"))
        {
            IdleNA();
        }
        

        DoBlock();

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

    void roll()
    {

    }

    void Light()
    {

    }

    void Heavy()
    {

    }

    void JumpAttack()
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
