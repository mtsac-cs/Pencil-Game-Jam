using System;

public class PencilEraserStat : PencilBaseStat
{
    private void Start()
    {
        statTextUI = InGameUI.instance.pencilEraserText;
        Init("PencilEraserStat", statTextUI);
    }

    public override bool CanUseAbility()
    {
        return pencilModel.HasEraser() ? base.CanUseAbility() : false;
    }

    public override void UseAbility()
    {
        base.UseAbility();
    }

    public override void OnStatDepleated()
    {
        base.OnStatDepleated();
    }
}