using System;
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

        if (controller == null)
            controller = this.GetComponent<CharacterController2D>();
    }

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Collectible":
                CollectibleScript cs = col.GetComponent<CollectibleScript>();

                if (cs.thisCollectibleIs == "Apple")
                {
                    Debug.Log("Apple");
                }
                else if (cs.thisCollectibleIs == "Orange")
                {

                }
                else if (cs.thisCollectibleIs == "Strawberry")
                {

                }
                break;

            case "Object":
                ObjectScript os= col.GetComponent<ObjectScript>();
                if (os.thisObjectIs == "Exit")
                {
                    gm.GetComponent<LevelManager>().NextLevel();
                }
                else if (os.thisObjectIs == "Death")
                {
                    Death();
                }
                break;
        }

    }

    public void Death()
    {
        this.enabled = false;
        controller.enabled = false;

        anime.SetTrigger("isDead");
        //Invoke("Spawn", 2.0f);
    }

    public void Spawn()
    {
        transform.position = initPos.position;
        anime.SetTrigger("isSpawning");

        this.enabled = true;
        controller.enabled = true;
    }

    public void JumpAnimOff()
    {
        anime.SetBool("isJump", false);
    }
    
}