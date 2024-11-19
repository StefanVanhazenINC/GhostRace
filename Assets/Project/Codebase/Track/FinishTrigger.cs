using Ashsvp;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ����� � ��������� ������
/// </summary>
public sealed class FinishTrigger : MonoBehaviour
{
    private UnityAction _touchFinish;

    /// <summary>
    /// �������� �� ������� ������� ������
    /// </summary>
    /// <param name="action">�������</param>
    public void AddedActionTouchFinish(UnityAction action) 
    {
        _touchFinish += action;
    }

    /// <summary>
    /// ������� �� ������� ������� ������
    /// </summary>
    /// <param name="action">�������</param>
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
