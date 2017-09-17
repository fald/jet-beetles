using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public CharacterController controllerIn;
    public GameObject cameraHandlerIn;
    public int moveSpeed;
    public float yMove;
    public float xMove;
    public bool canMove;
	public Animator animatorIn;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (canMove)
        {
            xMove = Input.GetAxis("Horizontal");
            yMove = Input.GetAxis("Vertical");
        }   else
        {
            xMove = 0;
            yMove = 0;
        } 	
	}

    void FixedUpdate()
    {
		animatorIn.SetFloat ("MoveSpeed", Mathf.Abs (xMove) + Mathf.Abs (yMove));
        // Can't move in Update, or speed would be dependant on machine's speed instead of player's input
        // TODO: Change to sin/cos for smoother movement and none of that diagonal magic bullshit?
        Vector3 moveDirection = new Vector3((xMove * moveSpeed), 0, (yMove * moveSpeed));
        controllerIn.SimpleMove(moveDirection);
        if (moveDirection != Vector3.zero)
        {
            controllerIn.transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        // Camera follow player
        cameraHandlerIn.transform.position = controllerIn.transform.position;

    }

    void OnTriggerEnter(Collider col)
    {

    }
}
