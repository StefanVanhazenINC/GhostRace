using TMPro;
using UnityEngine;

/// <summary>
/// ����� ���������� � ��������� �����
/// </summary>
public sealed class RaceInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _stateRaceText;

    /// <summary>
    /// ����������� ��������� �����
    /// </summary>
    /// <param name="value">�������� ��������� �����</param>
    public void SetStateRace(string value) 
    {
        _stateRaceText.text = value;
    }
}
