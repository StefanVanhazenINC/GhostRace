using UnityEngine;

/// <summary>
/// Инсталлер для установки подписок на запуск призрака
/// </summary>
public sealed class GhostTrackingInstaller : MonoBehaviour
{
    [SerializeField] private GhostTracking _ghostTracking;
    [SerializeField] private GhostController _ghostController;
    [SerializeField] private TrackManager _trackManager;


    public void OnEnable()
    {
        _trackManager.AddedActionRaceToGhost(_ghostTracking.DisableWritePath);
        _trackManager.AddedActionRaceToGhost(_ghostController.StartGhost);
    }
    public void OnDisable()
    {
        _trackManager.RemoveActionRaceToGhost(_ghostTracking.DisableWritePath);
        _trackManager.RemoveActionRaceToGhost(_ghostController.StartGhost);
    }
}
