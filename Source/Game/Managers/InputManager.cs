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

    // INPUT ACTIONS
    static InputEvent _Jump;

    public override void OnAwake()
    {
        // INPUT AXIS
        _VerticalMovementAxis = new InputAxis("Vertical");
        _HorizontalMovementAxis = new InputAxis("Horizontal");

        // INPUT ACTIONS
        _Jump = new InputEvent("Jump");
    }

    public override void OnDestroy()
    {
        // INPUT AXIS
        _VerticalMovementAxis.Dispose();
        _HorizontalMovementAxis.Dispose();

        // INPUT EVENTS
        _Jump.Dispose();
    }

    public static Vector2 GetMovementAxis()
    {
        return new Vector2(_HorizontalMovementAxis.ValueRaw, _VerticalMovementAxis.ValueRaw);
    }

    public static InputEvent GetJump() => _Jump;
}
