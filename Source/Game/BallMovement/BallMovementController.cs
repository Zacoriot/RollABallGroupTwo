using FlaxEngine;

namespace Game;

/// <summary>
/// BallMovementController Script.
/// </summary>
public class BallMovementController : Script
{
    public override void OnUpdate()
    {
        Debug.Log(InputManager.GetMovementAxis());
    }
}
