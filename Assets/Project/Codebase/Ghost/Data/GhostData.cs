using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� � ������� � ������ 
/// </summary>
[System.Serializable]
public sealed class PathPoint 
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _direction;

    /// <summary>
    /// ����������� ������
    /// </summary>
    public PathPoint(Vector3 position, Vector3 direction)
    {
        _position = position;
        _direction = direction;
    }


    /// <summary>
    /// �������� ��� ������� 
    /// </summary>
    public Vector3 Position { get => _position;  }

    /// <summary>
    /// �������� ��� �����������
    /// </summary>
    public Vector3 Direction { get => _direction;}
}
[System.Serializable]

/// <summary>
/// ������ � ������� ������ � ������ 
/// </summary>
public sealed class GhostData 
{
    [SerializeField] private List<PathPoint> _pathPoints = new List<PathPoint>();
    public List<PathPoint> PathPoints { get => _pathPoints; }


   /// <summary>
   /// ���������� ����� ����� ����������� �� Transform 
   /// </summary>
   /// <param name="transform">����� ������ �� ������� ����� �������� �����</param>
    public void AddedPoint(Transform transform) 
    {
        PathPoint t_point = new PathPoint(transform.position,transform.forward);
        _pathPoints.Add(t_point);
    }

    /// <summary>
    /// ������� ������� ��������� ����� � ������ 
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnLastPosition()
    {
        return _pathPoints[_pathPoints.Count-1].Position;
    }

    /// <summary>
    /// ������� �����������  ��������� ����� � ������ 
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnLastDirection() 
    {
        return _pathPoints[_pathPoints.Count-1].Direction;
    }
}
