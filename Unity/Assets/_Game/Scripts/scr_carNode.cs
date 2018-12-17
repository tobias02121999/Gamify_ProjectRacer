using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_carNode : MonoBehaviour
{
    // Initialize the public variables
    public scr_gameManager gameManager;
    public int carNodeTeamID;
    public float movementSpeed;
    public float waypointDistanceThreshold;
    public AudioSource audioSource;

    // Initialize the private variables
    int waypointCurrent;
    bool audioIsPlaying;

    // Run this code every frame
    void Update()
    {
        // Check if the carNode is currently not at the correct waypoint (causing it to move to the correct one)
        if (waypointCurrent != gameManager.teamScore[carNodeTeamID])
        {
            move(movementSpeed, waypointDistanceThreshold); // Move the carNode towards the next waypoint

            if (!audioIsPlaying)
            {
                audioSource.Play();
                audioIsPlaying = true;
            }
        }
        else
            audioIsPlaying = false;
    }

    // Move the carNode towards the next waypoint
    void move(float speed, float distanceToReach)
    {
        var targetVector = gameManager.pathWaypoints[waypointCurrent + 1].position;
        transform.position = Vector3.Lerp(transform.position, targetVector, speed);

        var distance = Vector3.Distance(transform.position, targetVector);
        if (distance <= distanceToReach)
            waypointCurrent++;
    }
}
