using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

	public int maxNodes;
	public int maxConnections;
	public float range;
	public GameObject[] nodeTypes;

	private Quaternion noRotation;
	private List<Vector3> nodePositions = new List<Vector3>();
	private GameObject[] nodes;
	private LineRenderer[] nodeLineRenderers; 

	// Instantiates a given maximum amount of diverse nodes in a given amount of maximum area
	void CreateNodes () {

		if (nodeTypes.Length == 0) {
			return;
		}

		for (int i = 0; i <= maxNodes; i++) {

			int random = Random.Range (0, nodeTypes.Length);
			GameObject nodeCurrent = nodeTypes[random];

			Vector3 randomPosition = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));

			Instantiate (nodeCurrent, randomPosition, noRotation);

			nodePositions.Add (randomPosition);

		}
	}

	// Draws lines between nodes as long as they're a given maximum distance apart
	void DrawConnections () {

		if (nodes == null) {
			
			nodes = GameObject.FindGameObjectsWithTag ("node");

		}

		for (int i = 0; i < nodes.Length; i++) {

			nodeLineRenderers [i] = nodes [i].GetComponent<LineRenderer>;

			// ACHTUNG! Dieses if-Statement muss true ausgeben, bevor i++ passiert, damit der der LineRenderer dieser Node ein Ziel bekommt.
			if (targetNode != notTooFarAway) {

				nodeLineRenderers [i].SetPosition (1, targetNode);
			
			}
		}
	}

	// Use this for initialization
	void Start () {

		noRotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		CreateNodes ();
		DrawConnections ();

	}
}