using UnityEngine;


/// <summary>
/// Конфиг для настройки призрака 
/// </summary>
[CreateAssetMenu(menuName = "SO/GhostConfig")]
public sealed class GhostConfig : ScriptableObject
{
    
    [SerializeField] private GameObject _ghostObject;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _accurancyMovePath = 0.5f;

    /// <summary>
    /// Свойство для получения визуала призрака
    /// </summary>
    public GameObject GhostObject { get => _ghostObject;  }


    /// <summary>
    /// Свойство для получения времени основаного на скорости и необходимой дистанции до точки 
    /// </summary>
    public float TimeToPoint { get => _accurancyMovePath / _speed; }
}
