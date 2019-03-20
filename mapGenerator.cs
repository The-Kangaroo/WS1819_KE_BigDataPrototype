using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

	public int maxNodes;
	public float range;
	public GameObject node;

	private Vector3 nodePosition;
	private Quaternion noRotation;

	// Instantiate the a node at a random position within the Map Area
	void CreateNodes () {
		
		for (int i = 0; i <= maxNodes; i++) {
			nodePosition = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
			Instantiate (node, nodePosition, noRotation);
		}

	}

	// Use this for initialization
	void Start () {

		noRotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		CreateNodes ();

	}
	
	// Update is called once per frame
	void Update () {
		
	} 
}
