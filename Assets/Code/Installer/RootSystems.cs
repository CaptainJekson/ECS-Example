using Code.Ball.Systems;
using Entitas;

public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        Add(new CreateBallsSystem(contexts));
        Add(new BallsMoveSystem(contexts));
        Add(new BallReflectSystem(contexts));
        Add(new BallReduceSystem(contexts));
    }

    public sealed override Systems Add(ISystem system)
    {
        return base.Add(system);
    }
}
