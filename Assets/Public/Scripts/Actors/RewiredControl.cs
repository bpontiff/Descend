using UnityEngine;
using System.Collections;
using Rewired;
using System;

public class RewiredControl : ActorControlBase
{
    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    [System.NonSerialized] // Don't serialize this so the value is lost on an editor script recompile.
    private bool initialized;
    

    void Start()
    {
        SetDirection(new Vector2(0, -1));
    }

    void Update()
    {
        if (!ReInput.isReady) return; // Exit if Rewired isn't ready. This would only happen during a script recompile in the editor.

        if (!initialized) Initialize(); // Reinitialize after a recompile in the editor

        UpdateDirection();
        //UpdateActions();
        UpdateAttack();
    }

    private void Initialize()
    {
        // Get the Rewired Player object for this player.
        player = ReInput.players.GetPlayer(playerId);

        initialized = true;
    }

    private void UpdateAttack()
    {
        if(player.GetButtonDown("Primary Action"))
            OnPrimaryPressed();
    }

    void UpdateDirection()
    {
        Vector2 newMovementVector = Vector2.zero;

        newMovementVector.x = player.GetAxis("Horizontal Movement");
        newMovementVector.y = player.GetAxis("Vertical Movement");
        SetDirection(newMovementVector);
    }
}
