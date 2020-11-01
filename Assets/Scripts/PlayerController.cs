using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject gm;
    public GameObject loadingScreen;


	public CharacterController2D controller;
	public Animator anime;
    public Transform initPos;
	public float runSpeed = 40f;
    public int deathType;


    public bool moveFlag = false;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    private void Awake()
    {
		if (anime == null)
			anime = this.GetComponent<Animator>();

        if (controller == null)
            controller = this.GetComponent<CharacterController2D>();
    }
    private void OnEnable()
    {
        anime.SetTrigger("isSpawning");
    }

    void Update()
	{
        if(moveFlag)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        
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
                    deathType = 1;
                    Death();
                }
                else if (os.thisObjectIs == "Death")
                {
                    deathType = 0;
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
        if(deathType == 0)
        {
            transform.position = initPos.position;
            anime.SetTrigger("isSpawning");

            this.enabled = true;
            controller.enabled = true;
        }
        else if(deathType == 1)
        {
            StartCoroutine(changeLevel());
        }
        
    }

    public IEnumerator changeLevel()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gm.GetComponent<LevelManager>().NextLevel();
    }

    public void spawnAnimFunction()
    {
        if(loadingScreen.activeInHierarchy)
        {
            loadingScreen.SetActive(false);
        }
    }

    public void JumpAnimOff()
    {
        anime.SetBool("isJump", false);
    }
    
}