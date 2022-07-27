using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Test
{
    public class AddressableLoaderTest : MonoBehaviour
    {
        [SerializeField] private AssetReference _assetReference;

        private Cube _cube;

        private void Start()
        {
            _assetReference.InstantiateAsync().Completed += handle =>
            {
                _cube = handle.Result.GetComponent<Cube>();
                Debug.Log("Объект загружен и создан");
                DestroyCube();
            };
        }
        
        private void DestroyCube()
        {
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(5.0f);
            sequence.AppendCallback(() =>
            {
                _assetReference.ReleaseInstance(_cube.gameObject);
                Debug.Log("Объект удалён и Ассет из памяти очищен");
            });
        }
    }
}
