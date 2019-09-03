using Rewired;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{

    private readonly int playerCount = 4;
    public List<GameObject> playerGOs = new List<GameObject>();
    public List<GameObject> playerCams = new List<GameObject>();

    public List<Player> playerControls = new List<Player>();

    [System.NonSerialized] // Don't serialize this so the value is lost on an editor script recompile.
    private bool initialized = false;

    private void Awake()
    {

    }

    private void Update()
    {
        if (!initialized)
        {
            Initialize(); // Reinitialize after a recompile in the editor
        }

        for (int i = 0; i < playerCount; i++)
        {
            if (playerGOs[i] != null)
            {
                if (playerControls[i].GetButtonUp("Pause"))
                {
                    if (playerGOs[i] != null)
                    {
                        playerGOs[i].SetActive(!playerGOs[i].activeSelf);
                        updateCameras();
                    }
                }
            }
        }
    }

    private void Initialize()
    {
        initialized = true;
        /* Need to rework auto finding/creating cameras and players. Set statically for now
        var cameras = FindObjectsOfType<Camera>();
        var players = FindObjectsOfType<Actor>();
        foreach (Actor play in players)
        {
            if(play.tag == "Player")
            {
                if (playerGOs.Count == 0)
                    playerGOs.Add(play.gameObject);
                else {
                    for(int i = 0; i < playerGOs.Count; i++)
                    {
                        if (play.GetComponent<RewiredControl>().playerId < playerGOs[i].GetComponent<RewiredControl>().playerId)
                        {
                            playerGOs.Insert(i, play.gameObject);
                            break;
                        }
                    }
                }
            }
        }
        foreach (Camera cam in cameras)
        {
            playerCams.Add(cam.gameObject);

            if (playerCams.Count == 0)
                playerCams.Add(cam.gameObject);
            else
            {
                for (int i = 0; i < playerGOs.Count; i++)
                {
                    if (cam.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow.GetComponent<RewiredControl>().playerId
                        < playerCams[i].GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow.GetComponent<RewiredControl>().playerId)
                    {
                        playerCams.Insert(i, cam.gameObject);
                        break;
                    }
                }
            }
        }
        */
        for (int i = 0; i < playerGOs.Count; i++)
        {
            playerControls.Add(ReInput.players.GetPlayer(i));
        }

        updateCameras();
    }


    private void updateCameras()
    {
        List<GameObject> activeCams = new List<GameObject>();
        for (int i = 0; i < playerCount; i++)
        {
            if (playerGOs[i] != null && playerGOs[i].activeSelf == true)
            {
                activeCams.Add(playerCams[i]);
            }
            else
                if (playerCams[i] != null)
            {
                playerCams[i].GetComponent<Camera>().rect = new Rect(0f, 0f, 0f, 0f);
            }
        }
        switch (activeCams.Count)
        {
            case 0:
                throw new System.ArgumentOutOfRangeException();
            case 1:
                activeCams[0].GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1f, 1f);
                break;
            case 2:
                activeCams[0].GetComponent<Camera>().rect = new Rect(0.0f, 0.5f, 1f, 1f);
                activeCams[1].GetComponent<Camera>().rect = new Rect(0.0f, -0.5f, 1f, 1f);
                break;
            case 3:
                activeCams[0].GetComponent<Camera>().rect = new Rect(0.0f, 0.5f, 1f, 1f);
                activeCams[1].GetComponent<Camera>().rect = new Rect(0.5f, -0.5f, 1f, 1f);
                activeCams[2].GetComponent<Camera>().rect = new Rect(-0.5f, -0.5f, 1f, 1f);
                break;
            case 4:
                activeCams[0].GetComponent<Camera>().rect = new Rect(-0.5f, 0.5f, 1f, 1f);
                activeCams[1].GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 1f, 1f);
                activeCams[2].GetComponent<Camera>().rect = new Rect(-0.5f, -0.5f, 1f, 1f);
                activeCams[3].GetComponent<Camera>().rect = new Rect(0.5f, -0.5f, 1f, 1f);
                break;
        }
    }
}
