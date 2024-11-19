using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] private GhostConfig _ghostConfig;

    private GameObject _ghostObject;
    //движение по записанным в кофиг точкам 
    private GhostData _ghostData;
    private int _positionIndex = 0;
    public GhostData GhostData {  set => _ghostData = value; }

    private Vector3 _lastPosition;
    private Vector3 _lastDirection;
    private float _timeElapsed = 0;
    private bool _enable = false;
    public void StartGhost() 
    {
        _enable = true;
        _ghostObject = Instantiate(_ghostConfig.GhostObject, _ghostData.PathPoints[_positionIndex].Position, Quaternion.identity);
        _ghostObject.transform.forward = _ghostData.PathPoints[_positionIndex].Direction;
        _lastPosition = _ghostData.PathPoints[_positionIndex].Position;
        _lastDirection = _ghostData.PathPoints[_positionIndex].Direction;
        AddedPointIndex();
    }
    private void AddedPointIndex() 
    {
        if (_positionIndex + 1 > _ghostData.PathPoints.Count-1)
        {
            _positionIndex = 0;
        }
        else
        {
            _positionIndex++;
        }
    }
    private void MoveGhost() 
    {
        if (_enable) 
        {
            if (_timeElapsed < _ghostConfig.TimeToPoint )
            {
                _ghostObject.transform.position = Vector3.Lerp(_lastPosition, _ghostData.PathPoints[_positionIndex].Position, _timeElapsed / _ghostConfig.TimeToPoint);
                _ghostObject.transform.forward = Vector3.Lerp(_lastDirection, _ghostData.PathPoints[_positionIndex].Direction, _timeElapsed / _ghostConfig.TimeToPoint);

                _timeElapsed += Time.deltaTime;
            }
            else 
            {
                _lastPosition = _ghostData.PathPoints[_positionIndex].Position;
                _lastDirection = _ghostData.PathPoints[_positionIndex].Direction;

                AddedPointIndex();
                _timeElapsed = 0;
            }
        }
    }
    
    public void ProcessGhost() 
    {
        MoveGhost();
    }
    private void LateUpdate()
    {
        ProcessGhost();
    }
}
