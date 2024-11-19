using Ashsvp;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ����� �������� ��������� ����� 
/// </summary>
public sealed class TrackManager : MonoBehaviour
{
    [SerializeField] private SimcadeVehicleController _carController;
    [SerializeField] private TrackState _trackState;

    private UnityAction _onSwitchTrackStateToGhost;
    private UnityAction<string> _onSwitchTrack;

    private TrackState State 
    {
        get => _trackState;
        set  
        {
            _trackState = value;
            _onSwitchTrack?.Invoke(_trackState.ToString());
        }
    }
    private enum TrackState
    {
        Solo = 1,
        Ghost = 2,
    }

    /// <summary>
    /// �������� �� ������� �������� � ����� � ��������� 
    /// </summary>
    /// <param name="action">�������</param>
    public void AddedActionRaceToGhost(UnityAction action) 
    {
        _onSwitchTrackStateToGhost += action;
    }

    /// <summary>
    /// ������� �� ������� �������� � ����� � ��������� 
    /// </summary>
    /// <param name="action">�������</param>
    public void RemoveActionRaceToGhost(UnityAction action) 
    { 
        _onSwitchTrackStateToGhost -= action;
    }

    /// <summary>
    /// �������� �� ������� �������� �������� ��������� �����
    /// </summary>
    /// <param name="action">�������</param>
    public void AddedActionSwitchState(UnityAction<string> action) 
    {
        _onSwitchTrack += action;
    }

    /// <summary>
    /// ������� �� ������� �������� �������� ��������� �����
    /// </summary>
    /// <param name="action">�������</param>
    public void RemoveActionSwitchState(UnityAction<string> action)
    {
        _onSwitchTrack -= action;
    }

  
    private void Awake()
    {
        State = TrackState.Solo;
    }

    /// <summary>
    /// ������ �����
    /// </summary>
    public void StartRace() 
    {
        _carController.enabled = true; 
    }

    /// <summary>
    /// ������� ��������� �����
    /// </summary>
    public void SwitchRaceState() 
    {
        if (_trackState == TrackState.Solo) 
        {
            SwitchToGhostState();
        }
    }
    private void SwitchToGhostState() 
    {
        State = TrackState.Ghost;
        _onSwitchTrackStateToGhost?.Invoke();
    }


}
