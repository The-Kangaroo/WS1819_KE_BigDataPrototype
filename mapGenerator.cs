using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

	public int nodeAmount;
	public float maxConnectionLenght;
	public float networkSize;
	public GameObject[] nodeTypes;

	private Quaternion noRotation;
	private GameObject[] nodes;

	// Use this for initialization
	void Start () {

		noRotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		nodes = new GameObject[nodeAmount];

		CreateNodes ();
		DrawConnections ();

	}

	// Instantiates a given maximum amount of diverse nodes in a given amount of maximum area
	void CreateNodes () {

		if (nodeTypes.Length == 0) {

			print ("No node types found!");
			return;
		}

		if (nodeAmount == 0) {

			print ("The node amount is set to 0!");
		}

		for (int i = 0; i < nodeAmount; i++) {

			int random = Random.Range (0, nodeTypes.Length);
			GameObject nodeCurrent = nodeTypes[random];

			Vector3 randomPosition = new Vector3(Random.Range(-networkSize, networkSize), Random.Range(-networkSize, networkSize), Random.Range(-networkSize, networkSize));

			nodes [i] = Instantiate (nodeCurrent, randomPosition, noRotation);
		}
	}

	// Draws lines between nodes as long as they're a given maximum distance apart
	void DrawConnections () {

		if (maxConnectionLenght == 0.0f) {

			print ("Maximum length of connections is set to 0!");

		}

		for (int i = 0; i < nodes.Length; i++) {

			GameObject startNode = nodes [i]; 
			Vector3 startNodePosition = startNode.transform.position;
			LineRenderer startNodeLineRenderer = startNode.GetComponent<LineRenderer>();

			GameObject targetNode = nodes [Random.Range (0, nodeAmount)];
			Vector3 targetNodePosition = targetNode.transform.position;

			float connectionLength = Vector3.Distance (startNodePosition, targetNodePosition);

			if (connectionLength <= maxConnectionLenght) {

				startNodeLineRenderer.SetPosition (0, startNodePosition);
				startNodeLineRenderer.SetPosition (1, targetNodePosition);
			
			} else {

				i--;

			}
		}
	}
}