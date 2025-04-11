using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "RumbleSO")]
public class RumbleSO : ScriptableObject
{
    public float Duration;
    public AnimationCurve HighCurve;
    public AnimationCurve LowCurve;

    [Range(0, 1)]
    [FormerlySerializedAs("HighStrength")]
    public float HighFreq;

    [Range(0, 1)]
    [FormerlySerializedAs("LowStrength")]
    public float LowFreq;

    [ContextMenu("Test Rumble")]
    public void PlayRumble()
    {
        // Call the Rumble method from the RumbleService
        RumbleService.Instance.Rumble(this);
    }
}