using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Animator anim;
    GlobalVariables gv;

    public float maxSpeed = 1;
    bool facingRight;
    bool facingFront;

    private Vector2 velocity;
	// Use this for initialization
	void Start ()
    {
        anim = this.GetComponent<Animator>();
        gv = new GlobalVariables();
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        Movement();

        Attack();

    }

    public void Movement() {

        //this function handels the movement of the player

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(gv.speed*maxSpeed, 0);
            anim.SetBool("SideMovement", true);
            if (facingRight) {
                LeftRightFlip();
            }

        }
        //works for some reason
        else 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            anim.SetBool("SideMovement", false);
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-gv.speed * maxSpeed, 0);
            anim.SetBool("SideMovement", true);
            if(!facingRight){
                LeftRightFlip();
            }
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, gv.speed * maxSpeed);
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -gv.speed * maxSpeed);
        }
    }

    public void LeftRightFlip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ForwardBackFlip()
    {
        facingFront = !facingFront;
        //add in anim for facing front and back
    }


    public void Attack() {
        bool isAttacking;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (facingRight)
                LeftRightFlip();
            anim.SetBool("rlAttack", true);
            isAttacking = true;
        }
        else
        {
            anim.SetBool("rlAttack", false);
            isAttacking = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!facingRight)
                LeftRightFlip();
            anim.SetBool("rlAttack", true);
            isAttacking = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (facingFront)
                ForwardBackFlip();
            //anim.SetBool("fbAttack", true);
            isAttacking = true;
        }
        else 
        {
            //anim.SetBool("fbAttack", false);
            isAttacking = false;
        }
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            if (!facingFront)
                ForwardBackFlip();
            //anim.SetBool("fbAttack", true);
        }
    }

}
