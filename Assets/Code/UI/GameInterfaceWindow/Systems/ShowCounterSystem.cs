using Code.UI.GameInterfaceWindow.Components;
using Code.Units.BallUnit;
using Code.Units.BallUnit.EventComponents;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.UI.GameInterfaceWindow
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ShowCounterSystem))]
    public sealed class ShowCounterSystem : UpdateSystem
    {
        private Filter _filterGameInterfaceWindow;
        private Filter _filterCreateBallFilter;
        private Filter _filterDestroyBall;
        
        public override void OnAwake()
        {
            _filterGameInterfaceWindow = World.Filter.With<Components.GameInterfaceWindow>();
            _filterCreateBallFilter = World.Filter.With<CreateBallEvent>();
            _filterDestroyBall = World.Filter.With<DestroyBallEvent>();

            foreach (var entity in _filterGameInterfaceWindow)
            {
                entity.AddComponent<BallCounter>();
            }
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filterCreateBallFilter)
            {
                ref var createdBall = ref entity.GetComponent<CreateBallEvent>();
                IncreaseBallCounter(createdBall.ballType);
                entity.RemoveComponent<CreateBallEvent>();
            }

            foreach (var entity in _filterDestroyBall)
            {
                ref var destroyedBall = ref entity.GetComponent<DestroyBallEvent>();
                DecreaseBallCounter(destroyedBall.ballType);
                entity.RemoveComponent<DestroyBallEvent>();
            }
        }

        private void IncreaseBallCounter(BallType ballType)
        {
            foreach (var entity in _filterGameInterfaceWindow)
            {
                ref var counter = ref entity.GetComponent<BallCounter>();

                switch (ballType)
                {
                    case BallType.Red:
                        counter.redCounter++;
                        break;
                    case BallType.Green:
                        counter.greenCounter++;
                        break;
                }
            }

            WriteInWindow();
        }
        
        private void DecreaseBallCounter(BallType ballType)
        {
            foreach (var entity in _filterGameInterfaceWindow)
            {
                ref var counter = ref entity.GetComponent<BallCounter>();

                switch (ballType)
                {
                    case BallType.Red:
                        counter.redCounter--;
                        break;
                    case BallType.Green:
                        counter.greenCounter--;
                        break;
                }
            }

            WriteInWindow();
        }

        private void WriteInWindow()
        {
            foreach (var entity in _filterGameInterfaceWindow)
            {
                ref var window = ref entity.GetComponent<Components.GameInterfaceWindow>();
                ref var counter = ref entity.GetComponent<BallCounter>();

                window.redCountText.text = counter.redCounter.ToString();
                window.greenCountText.text = counter.greenCounter.ToString();
            }
        }
    }
}