using Ashsvp;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Класс манаджер состояния трека 
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
    /// Подписка на событие перехода к гонке с призраком 
    /// </summary>
    /// <param name="action">Событие</param>
    public void AddedActionRaceToGhost(UnityAction action) 
    {
        _onSwitchTrackStateToGhost += action;
    }

    /// <summary>
    /// отписка на событие перехода к гонке с призраком 
    /// </summary>
    /// <param name="action">Событие</param>
    public void RemoveActionRaceToGhost(UnityAction action) 
    { 
        _onSwitchTrackStateToGhost -= action;
    }

    /// <summary>
    /// Подписка на событие перехода перехода состояния гонки
    /// </summary>
    /// <param name="action">Событие</param>
    public void AddedActionSwitchState(UnityAction<string> action) 
    {
        _onSwitchTrack += action;
    }

    /// <summary>
    /// Отписка на событие перехода перехода состояния гонки
    /// </summary>
    /// <param name="action">Событие</param>
    public void RemoveActionSwitchState(UnityAction<string> action)
    {
        _onSwitchTrack -= action;
    }

  
    private void Awake()
    {
        State = TrackState.Solo;
    }

    /// <summary>
    /// Начать гонку
    /// </summary>
    public void StartRace() 
    {
        _carController.enabled = true; 
    }

    /// <summary>
    /// Сменить состояние гонки
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
