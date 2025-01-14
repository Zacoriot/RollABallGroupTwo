using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game;

/// <summary>
/// CameraController Script.
/// </summary>
public class CameraController : Script
{
    [ShowInEditor, Serialize] Actor _Ball;
    [ShowInEditor, Serialize] float _FollowSpeed;
    [ShowInEditor, Serialize] Vector3 _Offset;

    public override void OnLateUpdate()
    {
        Actor.Position = Vector3.Lerp(Actor.Position, _Ball.Position + _Offset, Time.DeltaTime * _FollowSpeed);
        Actor.LookAt(_Ball.Position);
    }
}
