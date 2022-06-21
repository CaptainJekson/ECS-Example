using Entitas;

public class CreatePlayerSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public CreatePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddHealth(100);
        entity.AddTransform(null);
    }
}
