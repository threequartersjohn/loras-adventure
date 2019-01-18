using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateLevel : MonoBehaviour {

    [SerializeField]
    private float NumberOfTotalPfatforms;

    //prefabs
    [SerializeField]
    private GameObject Enemy, Floor;
    private GameObject EnemyList, FloorList;

	// Use this for initialization
	void Start () {

        EnemyList = GameObject.Find("Enemies");
        FloorList = GameObject.Find("Floors");

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    private void PopulateFloors()
    {
        
    }
}
