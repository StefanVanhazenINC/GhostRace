using Ashsvp;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Класс и триггером финиша
/// </summary>
public sealed class FinishTrigger : MonoBehaviour
{
    private UnityAction _touchFinish;

    /// <summary>
    /// Подписка на события касания финиша
    /// </summary>
    /// <param name="action">Событие</param>
    public void AddedActionTouchFinish(UnityAction action) 
    {
        _touchFinish += action;
    }

    /// <summary>
    /// Отписка на события касания финиша
    /// </summary>
    /// <param name="action">Событие</param>
    public void RemoveActionTouchFinish(UnityAction action) 
    {
        _touchFinish -= action;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<SimcadeVehicleController>()) 
        {
            _touchFinish?.Invoke();
        }
    }
}
