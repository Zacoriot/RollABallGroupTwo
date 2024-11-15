using FlaxEngine;

namespace Game;

/// <summary>
/// InputManager Script.
/// </summary>
public class InputManager : Script
{
    // INPUT AXIS
    static InputAxis _VerticalMovementAxis;
    static InputAxis _HorizontalMovementAxis;

    public override void OnAwake()
    {
        _VerticalMovementAxis = new InputAxis("Vertical");
        _HorizontalMovementAxis = new InputAxis("Horizontal");
    }

    public override void OnDestroy()
    {
        _VerticalMovementAxis.Dispose();
        _HorizontalMovementAxis.Dispose();
    }

    public static Vector2 GetMovementAxis()
    {
        return new Vector2(_HorizontalMovementAxis.ValueRaw, _VerticalMovementAxis.ValueRaw);
    }
}
