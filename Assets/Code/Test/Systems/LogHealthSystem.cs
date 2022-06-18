using System.Collections.Generic;
using Entitas;
using UnityEngine;

//TODO реактивная система вызов которой происходит в данном случае когда изменяется значение компонента Health
public sealed class LogHealthSystem : ReactiveSystem<GameEntity>
{
    public LogHealthSystem(Contexts context) : base(context.game)
    {
    }

    public LogHealthSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var healthValue = entity.health.value;
            Debug.Log("H = " + healthValue);
        }
    }
}


//TODO обычная система вызов которой происходит в GameInstaller например в Start или Update
// public sealed class LogHealthSystem : IExecuteSystem
// {
//     private IGroup<GameEntity> _entities;
//     
//     public LogHealthSystem(Contexts contexts)
//     {
//         _entities = contexts.game.GetGroup(GameMatcher.Health);
//     }
//     
//     public void Execute()
//     {
//         foreach (var entity in _entities)
//         {
//             var healthValue = entity.health.value;
//             Debug.Log("H = " + healthValue);
//         }
//     }
// }