using System.Globalization;
using Code.UI.GameInterfaceWindow.EventComponents;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.UI.GameInterfaceWindow.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(TimeScaleSystem))]
    public sealed class TimeScaleSystem : UpdateSystem
    {
        private Filter _filterTimeIncrease;
        private Filter _filterTimeDecrease;
        
        public override void OnAwake()
        {
            _filterTimeIncrease = World.Filter.With<TimeIncreaseEvent>().With<Components.GameInterfaceWindow>();
            _filterTimeDecrease = World.Filter.With<TimeDecreaseEvent>().With<Components.GameInterfaceWindow>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filterTimeIncrease)
            {
                ref var window = ref entity.GetComponent<Components.GameInterfaceWindow>();
                Time.timeScale += window.stepTimeScale;
                window.timeScaleText.text = Time.timeScale.ToString(CultureInfo.InvariantCulture);
                entity.RemoveComponent<TimeIncreaseEvent>();
            }
            
            foreach (var entity in _filterTimeDecrease)
            {
                ref var window = ref entity.GetComponent<Components.GameInterfaceWindow>();
                if (Time.timeScale - window.stepTimeScale > 0)
                {
                    Time.timeScale -= window.stepTimeScale;
                }
                window.timeScaleText.text = Time.timeScale.ToString(CultureInfo.InvariantCulture);
                entity.RemoveComponent<TimeDecreaseEvent>();
            }
        }
    }
}