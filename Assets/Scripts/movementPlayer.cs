using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour {

    #region variables

    //inputs
    [SerializeField]
    private string HorizontalMovementInput, GravityChangeInput;

    [SerializeField]
    private float MovementSpeed;

    //change gravity interval
    [SerializeField]
    private float GravityChangeInterval;
    private bool CanChangeGravity = true;
    public float TimeToChangeGravity = 0f;

    #endregion

    // Update is called once per frame
    void Update () {

        ManageInputs();
		
	}

    //lidar com inputs
    private void ManageInputs()
    {
        float horizontal = Input.GetAxis(HorizontalMovementInput);
        float switchGravity = Input.GetAxis(GravityChangeInput);

        #region moving
        if (horizontal != 0)
        {
            print("Moving Horizontal");
            Vector3 newPosition = transform.position;
            newPosition += new Vector3(horizontal * MovementSpeed * Time.deltaTime, 0, 0);
            transform.position = newPosition;
        }
        #endregion

        #region gravity changing
        if (switchGravity != 0 && TimeToChangeGravity < Time.time)
        {
            print("Changed Gravity");            
            TimeToChangeGravity = Time.time + GravityChangeInterval;
            CanChangeGravity = false;
            this.GetComponent<Rigidbody2D>().gravityScale = -this.GetComponent<Rigidbody2D>().gravityScale*4;
        }

        if (this.GetComponent<Rigidbody2D>().gravityScale > 1)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = Mathf.Lerp(this.GetComponent<Rigidbody2D>().gravityScale, 1, 0.15f);
        }

        else if (this.GetComponent<Rigidbody2D>().gravityScale < -1)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = Mathf.Lerp(this.GetComponent<Rigidbody2D>().gravityScale, -1, 0.15f);
        }
        #endregion
    }
}
