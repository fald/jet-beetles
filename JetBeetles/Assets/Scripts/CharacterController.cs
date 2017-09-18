using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rBody;

    public float drag = 0f;
    public float dragMod = 0f;

    public float currentSpeed = 0f;
    public float topSpeed = 0f;
    public float acceleration = 0f;

	// Use this for initialization
	void Start ()
    {
        rBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {}

    void FixedUpdate ()
    {
        drag = (acceleration / topSpeed) * dragMod;

        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            rBody.velocity += (Vector3.right * acceleration - (drag * rBody.velocity)) * Time.fixedDeltaTime;
        }
        else if(Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            rBody.velocity += (Vector3.left * acceleration - (drag * rBody.velocity)) * Time.fixedDeltaTime;
        }

        currentSpeed = rBody.velocity.magnitude;

        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0, 1, 0);
        }
    }
}
