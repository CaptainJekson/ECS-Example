using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Ball/BallConfig")]
public class BallConfig : ScriptableObject
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _speed;
    [SerializeField] private int _countRed;
    [SerializeField] private int _countGreen;

    public GameObject Ball => _ball;
    public float Speed => _speed;
    public int CountRed => _countRed;
    public int CountGreen => _countGreen;
}
