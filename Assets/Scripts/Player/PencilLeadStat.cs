public class PencilLeadStat : PencilBaseStat
{
    private void Start()
    {
        statTextUI = InGameUI.instance.pencilLeadText;
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
