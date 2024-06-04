using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    Healthscripts healthscripts;
    PlayerDamage playerDamage;
    States state;
    float Healedtimes = 5;

    public float Defence;

    Animator animator;

    public GameObject dscreen;

    int wepon = 0;
    int dead = 0;
    int rest = 0;
    public Playercontroller input;
    private InputAction menu;


    public GameObject IsPaused;

    [SerializeField]
    private Camera _followCamera;

    public GameObject healing;

    public GameObject Sword;
    public GameObject hitbox;

    [Header("Tutorial")]

    public GameObject textMovement;


    public GameObject restHitBox;

    public string text1 = "press A";

    private void Awake()
    {

        state = States.IdleNA;

        input = new Playercontroller();

        dscreen.gameObject.SetActive(false);
        IsPaused.gameObject.SetActive(false);


    }
    void Start()
    {
        animator = GetComponent<Animator>();
        textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("use the left analog stick for movement " +
       "use the right analog stick for the camera");
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();

        OnEndable();

        if(wepon == 0)
        {
            Sword.gameObject.SetActive(false);
        }
        else
        {
            Sword.gameObject.SetActive(true);
        }


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
        
        animator.SetBool("sheeth", false);
       



        if (GetStickMagnitude() > 0.1f)
        {
            animator.SetBool("walkingNA", true);
            state = States.WalkNA;
            
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3) && wepon == 0) //Y
        {
            state = States.Equip;
            animator.SetBool("Unsheeth", true);
            
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2) && Healedtimes >= 1) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);
            

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {
           
            state = States.Scream;
            animator.SetBool("Scream", true);
            
        }


        
        
        //input.Charactercontrols.Jump.performed += ctx => ctx.ReadValueAsButton();


        //if( analog stick moved ) walking(): play animation left sticxk moves root allowing to spin 

        //DoBlock();

    }
    void Pause(InputAction.CallbackContext context)
    {
        IsPaused.gameObject.SetActive(true);
    }
   
    void WalkNA()
    {
        //get v & h and get the magnitued of them, and .normalise 
        textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("Hold down B to run");

        Vector2 aim = Gamepad.current.leftStick.ReadValue();
        Vector3 direction = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(aim.x, 0, aim.y);
        transform.rotation = Quaternion.LookRotation(direction);

        
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
            textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("Press Y to equip your sword");

            animator.SetBool("walkingNA", false);
            animator.SetBool("RunningNA", false);
            state = States.IdleNA;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) && Healedtimes >= 1) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);
            

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {

            state = States.Scream;
            animator.SetBool("Scream", true);

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton17) || Input.GetKeyDown(KeyCode.JoystickButton16) || Input.GetKeyDown(KeyCode.JoystickButton18)) // puase
        {
        }

    }

    void Unsheeth()
    {
        wepon = 1;
        textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("press the right bumper to attack");
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

        if (Input.GetKeyDown(KeyCode.JoystickButton5)) //light 
        {
            animator.SetBool("Light", true);
            //state = States.Light;
            textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("Press B to roll");

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1)) //B
        {
            
            animator.SetBool("Roll", true);
            Roll();
            textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("Press X to heal " +
                "but you can only heal 5 times so be careful");

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) && Healedtimes >= 1) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);
            textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("Press left bumper to do more damage");

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {
            state = States.Scream;
            textMovement.gameObject.GetComponent<TextMeshProUGUI>().text = ("Press start to pause");
            animator.SetBool("Scream", true);
            textMovement.gameObject.SetActive(false);

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
            animator.SetBool("JumpAttack", true);
            state = States.Jump;

        }

        if (GetStickMagnitude() > 0.1f)
        {
            animator.SetBool("WalkY", true);
            state = States.WalkY;
           
        }
    }

    void WalkY()
    {

        Vector2 aim = Gamepad.current.leftStick.ReadValue();
        Vector3 direction = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(aim.x, 0, aim.y);
        transform.rotation = Quaternion.LookRotation(direction);


        if (GetStickMagnitude() < 0.1f)
        {
            animator.SetBool("WalkY", false);
            state = States.IdelY;
            textMovement.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton5)) //light 
        {
            animator.SetBool("WalkY", false);
            animator.SetBool("Light", true);
            //state = States.Light;

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1)) //B
        {
            
            animator.SetBool("Roll", true);
            //Roll();
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) && Healedtimes >= 1) //X
        {
            state = States.Drink;
            animator.SetBool("Drink", true);

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //Scream
        {
            animator.SetBool("Scream", true);
            state = States.Scream;
        }


        if (Input.GetKeyDown(KeyCode.JoystickButton0)) //A
        {
            animator.SetBool("WalkY", false);
            animator.SetBool("JumpAttack", true);
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
            animator.SetBool("JumpAttack", false);
            state = States.IdleNA;
            //IdleNA();
        }
        if (wepon == 1)
        {
            animator.SetBool("JumpAttack", false);
            state = States.IdelY;
            //IdleY();
        }
    }

    
    void DoBlock()
    {

    }

    void Healing()
    {
        healing.GetComponent<Healthscripts>().Healing(40);
        Healedtimes--;
    }

    public void BlockEnded()
    {
        state = States.IdelY;
    }

    void Roll()
    {
       
    }
    public void RollFinished()
    {
        
        if (wepon == 0)
        {
            animator.SetBool("Roll", false);
            state = States.IdleNA;
            Defence = 0;
            //IdleNA();
        }
        if (wepon == 1)
        {
            animator.SetBool("Roll", false);
            state = States.IdelY;
            Defence = 0;
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
    void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Scream()
    {
        hitbox.GetComponent<PlayerDamage>().damage = 35;
        
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

    public void Drink()
    {
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
    void Heal()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            healthscripts.Healing(40);
        } 
            
    }
    public void Rest()
    {
        if(rest == 0)
        {
            animator.SetBool("Rest", true);
            rest = 1;
        }
        
        
        if (Input.GetKeyDown(KeyCode.JoystickButton1))//B
        {
            rest = 0;
            Healedtimes = 5;
            animator.SetBool("Rest", false);
            
        }

    }

    public void StopRest()
    {
       
        
            rest = 0;
            Healedtimes = 5;
            animator.SetBool("Rest", false);

        
    }

    public void FalsePlayer()
    {
        animator.SetBool("sheeth", true);
        animator.SetBool("Drink", false);
        animator.SetBool("Scream", false);
        animator.SetBool("Light", false);
        animator.SetBool("Roll", false);
        animator.SetBool("WalkY", false);
        animator.SetBool("walkingNA", false);
        animator.SetBool("RunningNA", false);
        animator.SetBool("IdelY", false);
        animator.SetBool("Unsheeth", false);
    }


    public void Dead()
    {
        if(dead == 0)
        {
            animator.SetTrigger("dead");
            dead = 1;
        }
       
    }

    public void DefenceRoll()
    {
        Defence = 10000;
    }
    void OnEndable()
    {
        menu = input.Charactercontrols.Puase;
        //move = CharacterController.Player.Move;
        input.Charactercontrols.Enable();
        menu.Enable();

        menu.performed += Pause;
    }

    public void DeathScreen()
    {
        dscreen.SetActive(true);
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
