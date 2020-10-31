using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject gm;

	public CharacterController2D controller;
	public Animator anime;
    public Transform initPos;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    private void Start()
    {
		if (anime == null)
			anime = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove == 0)
        {
            anime.SetBool("isWalk", false);
            
            
        }
        else
        {
            anime.SetBool("isWalk", true);
        }
        //anime.SetFloat("Speed", horizontalMove);
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            anime.SetBool("isJump",true);

        }

		/*if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}*/

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
        
    }

	private void OnCollisionEnter2D(Collision2D col)
	{
		

	}

	public void Death()
    {
        anime.SetTrigger("isDead");
        //Invoke("Spawn", 2.0f);
    }

    public void Spawn()
    {
        transform.position = initPos.position;
        anime.SetTrigger("isSpawning");
    }

    public void JumpAnimOff()
    {
        anime.SetBool("isJump", false);
        

        print("Grounder");
    }
    
}