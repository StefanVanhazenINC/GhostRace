using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTracking : MonoBehaviour
{
    [SerializeField] private Transform _carPlayer;
    [SerializeField,Min(0),Range(0,2f)] private float _accurancyPath = 0.1f;

    //запись точек и поворотов 
    [SerializeField] private GhostData _ghostData;

    public GhostData GhostData {  set => _ghostData = value; }

    private bool _enabledWrite = false;
    private bool _enabled = false;
    

    private void Update()
    {
        WritePath();
    }

    public void EnableWritePath()
    {
        if (!_enabled) 
        {
            _enabled = true;
            _enabledWrite = true;
            _ghostData.AddedPoint(_carPlayer);
        }
    }
    public void DisableWritePath() 
    {
        _enabledWrite = false;
        _ghostData.AddedPoint(_carPlayer);
    }
    public void WritePath() 
    {
        if (_enabledWrite  )
        {
            if (Vector3.Distance(_carPlayer.position, _ghostData.ReturnLastPosition()) >= _accurancyPath)
            {
                _ghostData.AddedPoint(_carPlayer);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (_ghostData!=null) 
        {
            for (int i = 0; i < _ghostData.PathPoints.Count; i++)
            {
                Gizmos.DrawSphere(_ghostData.PathPoints[i].Position, 0.4f);
                Gizmos.DrawLine(_ghostData.PathPoints[i].Position, _ghostData.PathPoints[i].Position + (_ghostData.PathPoints[i].Direction * _accurancyPath));
            }
        }
    }
}
