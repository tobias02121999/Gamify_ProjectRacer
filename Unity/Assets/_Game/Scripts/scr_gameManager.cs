using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gameManager : MonoBehaviour
{
    // Initialize the public variables
    public string[] teamColor;
    public int[] teamScore;
    public Transform[] pathWaypoints;

    public GameObject carSpriteRed;
    public GameObject carSpriteGreen;
    public GameObject careSpriteBlue;

    // Initialize the private variables
    int teamPlaceFirstID;

    // Run this code every frame
    void Update()
    {
        // Find the top three highest-scoring teams
        getTeamPlacing();
        getTeamColor();
    }

    // Get the leading player
    void getTeamPlacing()
    {
        var first = 0;

        for (var i = 0; i < teamScore.Length; i++)
        {
            if (teamScore[i] > teamScore[first])
                first = i;
        }

        teamPlaceFirstID = first;
    }

    // Get the color of the leading player
    void getTeamColor()
    {
        switch (teamColor[teamPlaceFirstID])
        {
            case "RED":
                carSpriteRed.SetActive(true);
                carSpriteGreen.SetActive(false);
                careSpriteBlue.SetActive(false);
                break;

            case "GREEN":
                carSpriteRed.SetActive(false);
                carSpriteGreen.SetActive(true);
                careSpriteBlue.SetActive(false);
                break;

            case "BLUE":
                carSpriteRed.SetActive(false);
                carSpriteGreen.SetActive(false);
                careSpriteBlue.SetActive(true);
                break;
        }
    }
}
