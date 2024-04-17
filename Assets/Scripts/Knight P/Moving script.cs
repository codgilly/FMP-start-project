using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movingscript : MonoBehaviour
{

    enum States
    {
        IdleNA,
        WalkNA,
        Run,
        Idel,
        Walk,
        Block,
    };


    States state;

    Animator animator;
    int iswalkingnoSword;
    int isrunning;

    Playercontroller input;

    Vector2 currentMovemnt;
    bool movementPressed;
    bool runPressed;

    private void Awake()
    {

        state = States.IdleNA;


        input = new Playercontroller();

        /*
        input.Charactercontrols.Movement.performed += ctx =>
        {
            currentMovemnt = ctx.ReadValue<Vector2>();
            movementPressed = currentMovemnt.x != 0 || currentMovemnt.y != 0;
            print("movement pressed=" + movementPressed);

        };
        input.Charactercontrols.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
        */

    }
    void Start()
    {
        animator = GetComponent<Animator>();

        iswalkingnoSword = Animator.StringToHash("walkingnoSword");
        isrunning = Animator.StringToHash("Running");
    }

    // Update is called once per frame
    void Update()
    {
        if( state == States.IdleNA )
        {
            Idle();
        }

        if (state == States.WalkNA)
        {
            WalkNO();
        }

        print("Current state=" + state);


        //        Movent();

        //      print("v2= " + input.Charactercontrols.Movement.ReadValue<Vector2>() );

    }



    void Idle()
    {
        animator.SetBool(iswalkingnoSword, false);

        // check for controller analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();

        if (  dir.x != 0 || dir.y != 0 )
        {
            state = States.WalkNA;
        }

        DoBlock();

    }

    void Run()
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

    void WalkNO()
    {
        animator.SetBool(iswalkingnoSword, true);

        // check for player letting go of analogue stick
        Vector2 dir = input.Charactercontrols.Movement.ReadValue<Vector2>();
        if (dir.x == 0 && dir.y == 0)
        {
            state = States.IdleNA;
        }

        DoBlock();
    }

    void DoBlock()
    {
        // add code to perform block with L1


    }

    public void BlockEnded()
    {
        state = States.IdleNA;
    }










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

    private void OnEnable()
    {
        input.Charactercontrols.Enable();
    }

    private void OnDisable()
    {
        input.Charactercontrols.Disable();
    }
}
