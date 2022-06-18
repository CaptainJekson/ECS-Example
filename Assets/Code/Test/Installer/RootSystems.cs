using Entitas;

public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        Add(new CreatePlayerSystem(contexts));
        Add(new LogHealthSystem(contexts));
    }

    public sealed override Systems Add(ISystem system)
    {
        return base.Add(system);
    }
}
