using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс с данными о точках 
/// </summary>
[System.Serializable]
public sealed class PathPoint 
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _direction;

    /// <summary>
    /// Конструктор класса
    /// </summary>
    public PathPoint(Vector3 position, Vector3 direction)
    {
        _position = position;
        _direction = direction;
    }


    /// <summary>
    /// Свойство для позиции 
    /// </summary>
    public Vector3 Position { get => _position;  }

    /// <summary>
    /// Свойство для направления
    /// </summary>
    public Vector3 Direction { get => _direction;}
}
[System.Serializable]

/// <summary>
/// Класса с списком данных о точках 
/// </summary>
public sealed class GhostData 
{
    [SerializeField] private List<PathPoint> _pathPoints = new List<PathPoint>();
    public List<PathPoint> PathPoints { get => _pathPoints; }


   /// <summary>
   /// Добавления новой точки основываясь на Transform 
   /// </summary>
   /// <param name="transform">Новый данные по котором будет строится точка</param>
    public void AddedPoint(Transform transform) 
    {
        PathPoint t_point = new PathPoint(transform.position,transform.forward);
        _pathPoints.Add(t_point);
    }

    /// <summary>
    /// Возврат позиции последней точки в списке 
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnLastPosition()
    {
        return _pathPoints[_pathPoints.Count-1].Position;
    }

    /// <summary>
    /// Возврат направления  последней точки в списке 
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnLastDirection() 
    {
        return _pathPoints[_pathPoints.Count-1].Direction;
    }
}
