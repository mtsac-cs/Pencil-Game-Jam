using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PencilBaseStat : MonoBehaviour, IPencilAbility
{
    public string StatName { get; protected set; }
    public int StatValue { get; protected set; }
    protected PencilModel pencilModel;
    protected Text statTextUI;

    public void Init(string statName, Text uiText, int statValue = 0)
    {
        pencilModel = GetComponent<PencilModel>();
        this.StatName = statName;
        this.statTextUI = uiText;
        SetValue(statValue);
    }

    public virtual void DecreaseValue(int amount) => SetValue(StatValue - amount);
    public virtual void IncreaseValue(int amount) => SetValue(StatValue + amount);

    public virtual void SetValue(int count, bool allowStatDepleded = true)
    {
        StatValue = count;

        if (statTextUI)
            statTextUI.text = "X" + StatValue.ToString();

        if (allowStatDepleded && count <= 0)
        {
            OnStatDepleated();
        }
    }

    public virtual void OnStatDepleated()
    {
        StatValue = 0;
        if (pencilModel != null)
        {
            pencilModel.UpdateModel();
        }
    }

    public virtual void UseAbility()
    {
        DecreaseValue(1);
    }

    public virtual bool CanUseAbility()
    {
        return StatValue > 0;
    }

    public void ResetValue()
    {
        SetValue(3);
    }
}
