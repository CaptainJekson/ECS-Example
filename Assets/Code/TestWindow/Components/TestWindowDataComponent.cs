using Code.TestWindow.Mono;
using Morpeh;
using UnityEngine;

namespace Code.TestWindow.Components
{
    public struct TestWindowDataComponent : IComponent
    {
        public GameObject gameObject;
        public TestWindowMono provider;
    }
}