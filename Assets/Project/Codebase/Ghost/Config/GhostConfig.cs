using UnityEngine;


/// <summary>
/// ������ ��� ��������� �������� 
/// </summary>
[CreateAssetMenu(menuName = "SO/GhostConfig")]
public sealed class GhostConfig : ScriptableObject
{
    
    [SerializeField] private GameObject _ghostObject;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _accurancyMovePath = 0.5f;

    /// <summary>
    /// �������� ��� ��������� ������� ��������
    /// </summary>
    public GameObject GhostObject { get => _ghostObject;  }


    /// <summary>
    /// �������� ��� ��������� ������� ���������� �� �������� � ����������� ��������� �� ����� 
    /// </summary>
    public float TimeToPoint { get => _accurancyMovePath / _speed; }
}
