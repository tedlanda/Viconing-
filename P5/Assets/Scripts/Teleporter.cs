using UnityEngine;
using System.Collections;

/// The Teleporter class moves the viewer between a predetermined set of waypoints whenever they press the Cardboard button.
public class Teleporter : MonoBehaviour {
    // How tall is the player, in meters?
    public float height = 1.75f;
    // How fast to move to new location?
    public float speed = 10.0f;

    // Cached transforms for all waypoints
    private Transform[] waypoints;
    // Which waypoint is active?
    private int currentWaypointIndex = 0; 

    // Reference to the Google VR object in the scene
    private GvrViewer viewer;

    void Start() {
        // Locate the GvrViewer instance
        viewer = (GvrViewer)FindObjectOfType(typeof(GvrViewer));
        if (viewer == null) {
            Debug.LogError("No GvrViewer found. Please drag the GvrViewerMain prefab into the scene.");
            return;
        }

        // Initialize the waypoints
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            waypoints[i] = transform.GetChild(i);
        }
        currentWaypointIndex = 0;
    }

    void Update() {
        // Don't do anything unless the Google VR object and camera can be located
        if (viewer == null || Camera.main == null) {
            return;
        }
        // If the viewer pressed the cardboard button, then go to the next waypoint
        if (viewer.Triggered) {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        // Smoothly move the viewer towards to the active waypoint
        Vector3 destPos = waypoints[currentWaypointIndex].transform.position + Vector3.up * height;
        viewer.transform.position = Vector3.Lerp(viewer.transform.position, destPos, Time.deltaTime * speed);
    }
}
