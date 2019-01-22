using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionControl : MonoBehaviour {

    #region variables

    //inputs
    [SerializeField]
    [Tooltip("Input for camera offset")]
    private string VerticalCameraOffsetInput;

    //Camera offset and limits
    [SerializeField]
    [Tooltip("Value in units that defines the Y reach of camera offset")]
    float CameraOffsetValue;
    [SerializeField]
    [Tooltip("The speed at which the camera moves to offset point")]
    float CameraOffsetSpeed;
    Vector3 CameraOffset;
    const float LOWER_LIMIT = 0;

    [SerializeField]
    Color nightColor;
    Color dayColor;
    
    //Player variables
    Transform PlayerTransform;
    float PlayerPosition = 0;
    float OriginalPlayerPosition = 0;



    #endregion

    // Use this for initialization
    void Start () {
        PlayerTransform = GameObject.Find("Player").transform;
        OriginalPlayerPosition = PlayerTransform.position.y;
        dayColor = this.GetComponent<Camera>().backgroundColor;
    }
	
	// Update is called once per frame
	void Update () {

        ManageInputs();

        ChangeColor();

        PlayerPosition = PlayerTransform.position.y;
        Vector3 newCameraPosition = new Vector3(this.transform.position.x, 
                                                Mathf.Clamp(PlayerPosition, 0, PlayerPosition), 
                                                this.transform.position.z);

        newCameraPosition += CameraOffset;
        newCameraPosition.y = Mathf.Clamp(newCameraPosition.y, 0, newCameraPosition.y);

        this.transform.position = newCameraPosition;
            

	}

    private void ChangeColor()
    {
        this.GetComponent<Camera>().backgroundColor = Color.Lerp(dayColor, nightColor, (this.transform.position.y / 2 - 10) / 100);
    }

    private void ManageInputs()
    {
        float offset = Input.GetAxis(VerticalCameraOffsetInput);

        if (offset != 0)
        {
            CameraOffset.y = CameraOffsetValue * offset * CameraOffsetSpeed;
        }
    }
}
