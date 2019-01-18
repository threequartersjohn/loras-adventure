using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    float HorizontalLimit;
    [SerializeField]
    float HorizontalSpeed;

    bool MoveLeft = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleDirectionChange();
        HandleMovement();
	}

    private void HandleDirectionChange()
    {
   
        if (Mathf.Abs(this.transform.position.x) > HorizontalLimit)
        { 
            print("Enemy direction change");
            MoveLeft = !MoveLeft;
            flipObjectHorizontal();
        }
    }

    private void HandleMovement()
    {
        Vector3 newPosition = this.transform.position;
        if (MoveLeft == true) newPosition.x -= HorizontalSpeed * Time.deltaTime;
        else newPosition.x += HorizontalSpeed * Time.deltaTime;

        this.transform.position = newPosition;
    }

    private void flipObjectHorizontal()
    {
        print("inverted");
        Vector3 OriginalLocalScale = this.transform.localScale;
        OriginalLocalScale.x *= -1;
        this.transform.localScale = OriginalLocalScale;

    }
}
