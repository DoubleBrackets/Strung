using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleService : MonoBehaviour
{
    public static RumbleService Instance { get; private set; }

    private RumbleSO currentRumble;

    private float rumbleTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        rumbleTime -= Time.deltaTime;
        if (rumbleTime >= 0 && currentRumble != null)
        {
            Gamepad gamepad = Gamepad.current;
            float t = 1 - rumbleTime / currentRumble.Duration;
            if (gamepad != null)
            {
                float lowFreq = currentRumble.LowFreq * currentRumble.LowCurve.Evaluate(t);
                float highFreq = currentRumble.HighFreq * currentRumble.HighCurve.Evaluate(t);
                gamepad.SetMotorSpeeds(lowFreq, highFreq);
            }
        }
        else
        {
            Gamepad gamepad = Gamepad.current;
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(0, 0);
            }
        }
    }

    public void Rumble(RumbleSO rumble)
    {
        if (rumble == null)
        {
            Debug.LogError("RumbleSO is null");
            return;
        }

        currentRumble = rumble;
        rumbleTime = rumble.Duration;
    }
}