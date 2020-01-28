using System.Collections;
using System.Collections;
using UnityEngine;
using System;

public class EnemyWalkTest : ActorControlBase
{
    // Start is called before the first frame update

    public int directionToMove = 0;
    public int movementCount = 0;
    private int moveCap = 1;
    public Vector2 newMovementVector = Vector2.zero;
    void Start()
    {
        SetDirection(new Vector2(0, -1));
        StartCoroutine(WalkCycle());
    }
    private void Update()
    {
        SetDirection(newMovementVector);
    }
    // Update is called once per frame
    IEnumerator WalkCycle()
    {
        while(true)
        {
            movementCount++;
            switch (directionToMove) { 
                case 0:
                    MoveRight();
                    break;
                case 1:
                    MoveUp();
                    break;
                case 2:
                    MoveLeft();
                    break;
                case 3:
                    MoveDown();
                    break;
            }
            yield return new WaitForSeconds(1);
            if (movementCount >= moveCap)
            {
                if (directionToMove == 3)
                    directionToMove = 0;
                else
                    directionToMove++;
                movementCount = 0;
            }
        }
    }

    private void UpdateAttack()
    {
        return;
    }

    void MoveRight()
    {
        newMovementVector.x = 1;
        newMovementVector.y = 0;
    }
    void MoveUp()
    {
        newMovementVector.x = 0;
        newMovementVector.y = 1;
    }
    void MoveLeft()
    {
        newMovementVector.x = -1;
        newMovementVector.y = 0;
    }
    void MoveDown()
    {
        newMovementVector.x = 0;
        newMovementVector.y = -1;
    }
}
