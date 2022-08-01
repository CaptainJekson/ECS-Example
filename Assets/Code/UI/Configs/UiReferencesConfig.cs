using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.UI.Configs
{
    [CreateAssetMenu(fileName = "UiReferencesConfig", menuName = "Configs/UI/UiReferencesConfig")]
    public class UiReferencesConfig : ScriptableObject
    {
        [SerializeField] private AssetReference _testWindow;

        public AssetReference TestWindow => _testWindow;
    }
}
