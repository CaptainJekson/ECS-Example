using Code.UI.GameInterfaceWindow.EventComponents;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.UI.GameInterfaceWindow.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class GameInterfaceWindowProvider : MonoProvider<Components.GameInterfaceWindow>
    {
        private void Start()
        {
            var component = Entity.GetComponent<Components.GameInterfaceWindow>();
            component.increaseTimeButton.onClick.AddListener(OnIncreaseTimeButtonClick);
            component.decreaseTimeButton.onClick.AddListener(OnDecreaseTimeButtonClick);
        }

        private void OnIncreaseTimeButtonClick()
        {
            if (Entity.Has<TimeIncreaseEvent>() == false)
            {
                Entity.AddComponent<TimeIncreaseEvent>();
            }
        }

        private void OnDecreaseTimeButtonClick()
        {
            if (Entity.Has<TimeDecreaseEvent>() == false)
            {
                Entity.AddComponent<TimeDecreaseEvent>();
            }
        }
    }
}