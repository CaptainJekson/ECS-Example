//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ReduceBallEvent reduceBallEvent { get { return (ReduceBallEvent)GetComponent(GameComponentsLookup.ReduceBallEvent); } }
    public bool hasReduceBallEvent { get { return HasComponent(GameComponentsLookup.ReduceBallEvent); } }

    public void AddReduceBallEvent(Ball newOtherBall) {
        var index = GameComponentsLookup.ReduceBallEvent;
        var component = (ReduceBallEvent)CreateComponent(index, typeof(ReduceBallEvent));
        component.otherBall = newOtherBall;
        AddComponent(index, component);
    }

    public void ReplaceReduceBallEvent(Ball newOtherBall) {
        var index = GameComponentsLookup.ReduceBallEvent;
        var component = (ReduceBallEvent)CreateComponent(index, typeof(ReduceBallEvent));
        component.otherBall = newOtherBall;
        ReplaceComponent(index, component);
    }

    public void RemoveReduceBallEvent() {
        RemoveComponent(GameComponentsLookup.ReduceBallEvent);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReduceBallEvent;

    public static Entitas.IMatcher<GameEntity> ReduceBallEvent {
        get {
            if (_matcherReduceBallEvent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReduceBallEvent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReduceBallEvent = matcher;
            }

            return _matcherReduceBallEvent;
        }
    }
}
