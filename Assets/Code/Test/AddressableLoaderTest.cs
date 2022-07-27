using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Test
{
    public class AddressableLoaderTest : MonoBehaviour
    {
        [SerializeField] private AssetReference _cube;

        private void Start()
        {
            _cube.InstantiateAsync();
        }
    }
}
