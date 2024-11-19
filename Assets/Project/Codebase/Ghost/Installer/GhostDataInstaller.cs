
using UnityEngine;

/// <summary>
/// ���������� ������� ������� � ������������� ������ � �������� � ���������� �������� � ���������� �����
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
