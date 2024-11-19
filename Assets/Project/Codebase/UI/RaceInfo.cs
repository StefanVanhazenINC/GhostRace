using TMPro;
using UnityEngine;

/// <summary>
/// Класс информации о состоянии гонки
/// </summary>
public sealed class RaceInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _stateRaceText;

    /// <summary>
    /// Отображения состояние гонки
    /// </summary>
    /// <param name="value">Нынешнее состояние гонки</param>
    public void SetStateRace(string value) 
    {
        _stateRaceText.text = value;
    }
}
