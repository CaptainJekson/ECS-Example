//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BallComponents ballComponents { get { return (BallComponents)GetComponent(GameComponentsLookup.BallComponents); } }
    public bool hasBallComponents { get { return HasComponent(GameComponentsLookup.BallComponents); } }

    public void AddBallComponents(UnityEngine.Transform newTransform, UnityEngine.Rigidbody newRigidbody, UnityEngine.MeshRenderer newMeshRenderer, float newSpeed, Code.Ball.Types.BallType newBallType, UnityEngine.Vector3 newForce) {
        var index = GameComponentsLookup.BallComponents;
        var component = (BallComponents)CreateComponent(index, typeof(BallComponents));
        component.transform = newTransform;
        component.rigidbody = newRigidbody;
        component.meshRenderer = newMeshRenderer;
        component.speed = newSpeed;
        component.ballType = newBallType;
        component.force = newForce;
        AddComponent(index, component);
    }

    public void ReplaceBallComponents(UnityEngine.Transform newTransform, UnityEngine.Rigidbody newRigidbody, UnityEngine.MeshRenderer newMeshRenderer, float newSpeed, Code.Ball.Types.BallType newBallType, UnityEngine.Vector3 newForce) {
        var index = GameComponentsLookup.BallComponents;
        var component = (BallComponents)CreateComponent(index, typeof(BallComponents));
        component.transform = newTransform;
        component.rigidbody = newRigidbody;
        component.meshRenderer = newMeshRenderer;
        component.speed = newSpeed;
        component.ballType = newBallType;
        component.force = newForce;
        ReplaceComponent(index, component);
    }

    public void RemoveBallComponents() {
        RemoveComponent(GameComponentsLookup.BallComponents);
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

    static Entitas.IMatcher<GameEntity> _matcherBallComponents;

    public static Entitas.IMatcher<GameEntity> BallComponents {
        get {
            if (_matcherBallComponents == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BallComponents);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBallComponents = matcher;
            }

            return _matcherBallComponents;
        }
    }
}
