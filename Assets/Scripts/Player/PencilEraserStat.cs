public class PencilEraserStat : PencilBaseStat
{
    private void Start()
    {
        statTextUI = InGameUI.instance.pencilEraserText;
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