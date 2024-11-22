using FlaxEngine;

namespace Game;

/// <summary>
/// BallMovementController Script.
/// </summary>
public class BallMovementController : Script
{
    RigidBody _RigidBody;

    [Header("==MOVEMENT==")]
    [ShowInEditor, Serialize] float _RollSpeed;

    [Header("==JUMP==")]
    [ShowInEditor, Serialize] float _JumpForce;

    public override void OnStart()
    {
        _RigidBody = (RigidBody)Actor;
    }

    public override void OnEnable()
    {
        InputManager.GetJump().Pressed += Jump;
    }

    public override void OnFixedUpdate()
    {
        Vector3 finalForce = new Vector3(InputManager.GetMovementAxis().X, 
                                        0, 
                                        InputManager.GetMovementAxis().Y);

        finalForce = finalForce.Normalized * _RollSpeed;

        _RigidBody.AddForce(finalForce);
    }

    public override void OnDisable()
    {
        InputManager.GetJump().Pressed -= Jump;
    }

    void Jump()
    {
       _RigidBody.AddForce(Vector3.Up * _JumpForce);
    }
}
