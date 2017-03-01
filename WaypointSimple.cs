using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Usage:
 * 
 * Tag your camera with the tag "MainCamera".
 * Add script as component to the waypoint object.
 * Add an event trigger to the waypoint object.
 * Add an Pointer Click event type.
 * Assign the waypoint object to the Pointer Click event.
 * Assign the WaypointSimple.Click() function to the Pointer Click event.
 * 
 * NOTE: When the player clicks on the waypoint the camera AKA player is moved
 * to the position of the waypoint, therefore, the waypoint should be positioned
 * at the location you want the player to be at after the click.
 * 
 */


public class WaypointSimple : MonoBehaviour {

	public void Click()
	{
		// Prints to console so we can see the Click function was called.
		Debug.Log ("--> WaypointSimple.Click() function called");

		// Finds the first enabled camera tagged 'MainCamera'
		// and assigns the position of the waypoint (gameObject.transform.position)
		// to the position of the camera (Camera.main.transform.position).
		// This moves the camera AKA player to the position of the waypoint.
		Camera.main.transform.position = gameObject.transform.position;
	}

}
