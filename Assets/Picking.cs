using UnityEngine;
using System.Collections;

public class Picking : MonoBehaviour {

    public Camera pickingCamera;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0) == true)
        {
            //Create a ray that is cast from the mouse's position into the world
            Vector3 mousePosition = Input.mousePosition;
            Ray pickingRay = pickingCamera.ScreenPointToRay(mousePosition);

            //Use the ray to see if any object collides with it
            RaycastHit hit;
            bool success = Physics.Raycast(pickingRay, out hit);

            //If there is a successful hit and the gameObject clicked is a tagged as a tooth then that object is deactivated
            if(success && hit.collider.gameObject.CompareTag("Tooth"))
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("The name of the picked object is: " + hit.collider.gameObject);
            }
        }
	}
}
