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

    [Header("==GROUND DETECTION==")]
    [ShowInEditor, Serialize] float _GroundDetectRadius;
    [ShowInEditor, Serialize] Vector3 _GroundDetectOffset;
    [ShowInEditor, Serialize] LayersMask _GroundMask;
    bool _IsGrounded => Physics.CheckSphere(Actor.Position + _GroundDetectOffset, _GroundDetectRadius, _GroundMask);

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
        if(!_IsGrounded)
        {
            return;
        }

       _RigidBody.AddForce(Vector3.Up * _JumpForce);
    }

    public override void OnDebugDraw()
    {
        DebugDraw.DrawWireSphere(new BoundingSphere(Actor.Position + _GroundDetectOffset, _GroundDetectRadius), Color.Green);
    }
}
