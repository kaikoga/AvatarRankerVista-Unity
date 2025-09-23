namespace Silksprite.AvatarRankerVista.API
{
    public interface ICriterionProvider
    {
        string Id { get; }
        string DisplayName { get; }
    }
    
    public interface ICriterionProvider<out T> : ICriterionProvider
    {
        T Measure(AvatarContext context);
    }
}
