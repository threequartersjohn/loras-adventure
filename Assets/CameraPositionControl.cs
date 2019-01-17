using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionControl : MonoBehaviour {

    //inputs
    [SerializeField]
    private string VerticalCameraOffsetInput;

    //Camera offset and limits
    [SerializeField]
    float CameraOffsetValue;
    Vector3 CameraOffset;
    const float LOWER_LIMIT = 0;
    
    //Player variables
    Transform PlayerTransform;
    float PlayerPosition = 0;
    float OriginalPlayerPosition = 0;

	// Use this for initialization
	void Start () {
        PlayerTransform = GameObject.Find("Player").transform;
        OriginalPlayerPosition = PlayerTransform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        PlayerPosition = PlayerTransform.position.y;
        
        Vector3 newCameraPosition = new Vector3(this.transform.position.x, 
                                                Mathf.Clamp(PlayerPosition, 0, PlayerPosition), 
                                                this.transform.position.z);

        this.transform.position = newCameraPosition;

	}
}
