using UnityEngine;
using UnityEngine.UI;

public class PencilBaseStat : MonoBehaviour, IPencilAbility
{
    public string StatName { get; protected set; }
    public int StatValue { get; protected set; }
    protected PencilModel pencilModel;
    protected Text statTextUI;

    void Start()
    {
        
    }

    public void Init(string statName, Text uiText, int statValue = 3)
    {
        this.StatName = statName;
        SetValue(statValue);
        this.statTextUI = uiText;
        pencilModel = GetComponent<PencilModel>();
    }

    public virtual void DecreaseValue(int amount) => SetValue(StatValue - amount);
    public virtual void IncreaseValue(int amount) => SetValue(StatValue + amount);

    public virtual void SetValue(int count)
    {
        StatValue = count;

        if (statTextUI)
            statTextUI.text = "X" + StatValue.ToString();

        if (count <= 0)
        {
            OnStatDepleated();
        }
    }

    public virtual void OnStatDepleated()
    {
        StatValue = 0;
        pencilModel.UpdateModel();
    }

    public virtual void UseAbility()
    {
        DecreaseValue(1);
    }

    public virtual bool CanUseAbility()
    {
        return StatValue > 0;
    }
}
