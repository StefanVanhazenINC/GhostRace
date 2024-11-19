using UnityEngine;

/// <summary>
/// Инсталлер для установки события финиша 
/// </summary>
public sealed class FinishTriggerInstaller : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finishTrigger;
    [SerializeField] private TrackManager _trackManager;

    private void OnEnable()
    {
        _finishTrigger.AddedActionTouchFinish(_trackManager.SwitchRaceState);
    }

    private void OnDisable()
    {
        _finishTrigger.RemoveActionTouchFinish(_trackManager.SwitchRaceState);
    }
}
