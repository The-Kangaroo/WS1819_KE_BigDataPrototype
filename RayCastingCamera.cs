using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastingCamera : MonoBehaviour
{

	public float timeToWait;

	private GameObject canvas;
	private GameObject storyDisplayed;
	private Camera cam;
	private Image loadingCircleImage;
	private Vector3 hitPosition;
	private bool storyPresent;
	private bool storyToBeDestroyed;

    // Start is called before the first frame update
    void Start() {

		canvas = GameObject.FindGameObjectWithTag ("canvas"); 
		canvas.SetActive (false);

		cam = GetComponent<Camera> ();
		storyPresent = false;
	
		if (timeToWait == 0.0f) {

			print ("Activation Time is set to 0! Nodes will trigger instantly!");

		}
    }

    // Update is called once per frame
    void Update()  {

		Ray ray = cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo)) {

			hitPosition = hitInfo.transform.position;
			print ("I'm looking at a " + hitInfo.transform.name);

			if (storyPresent != true) {

				DisplayStory ();
				storyPresent = true;
				storyToBeDestroyed = true;
			}
		} else {

			print ("I'm looking at nothing!");

			if (storyToBeDestroyed) {

				DestroyStory ();
				storyToBeDestroyed = false;
			}
		}
    }

	// Displays a Story when looking at a node
	void DisplayStory () {

		canvas.transform.position = hitPosition;
		canvas.SetActive (true);

	}		

	// Destorys the currently displayed story and allows for spawning a new one
	void DestroyStory () {

		canvas.SetActive (false);
		storyPresent = false;

	}
}