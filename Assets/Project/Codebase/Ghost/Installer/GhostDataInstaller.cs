
using UnityEngine;

/// <summary>
/// Установщик который создает и устанавливает данные о призраке в контроллре призрака и контроллер точек
/// </summary>
public sealed class GhostDataInstaller : MonoBehaviour
{
    [SerializeField] private GhostTracking _ghostTracking;
    [SerializeField] private GhostController _ghostController;

    private void Awake()
    {
        GhostData ghostData = new GhostData();
        _ghostController.GhostData = ghostData;
        _ghostTracking.GhostData = ghostData;
    }
}
