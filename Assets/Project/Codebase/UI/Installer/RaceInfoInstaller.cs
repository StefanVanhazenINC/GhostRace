using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceInfoInstaller : MonoBehaviour
{
    [SerializeField] private RaceInfo _raceInfo;
    [SerializeField] private TrackManager _trackManager;

    private void OnEnable()
    {
        _trackManager.AddedActionSwitchState(_raceInfo.SetStateRace);
    }
    private void OnDisable()
    {
        _trackManager.RemoveActionSwitchState(_raceInfo.SetStateRace);
    }
}
