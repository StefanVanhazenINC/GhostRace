using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Инсталлер подписывающий кнопку на события 
/// </summary>
public sealed class StartRaceButtonInstaller : MonoBehaviour
{
    [SerializeField] private TrackManager _trackManager;
    [SerializeField] private GhostTracking _ghostTracking;
    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
        
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(_trackManager.StartRace);
        _button.onClick.AddListener(() => gameObject.SetActive(false));
        _button.onClick.AddListener(_ghostTracking.EnableWritePath);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

}
