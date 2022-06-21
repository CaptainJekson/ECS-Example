using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameEntity _entity;
    
    public void Init(GameEntity entity)
    {
        _entity = entity;
    }

    private void OnCollisionEnter(Collision other)
    {
        var normal = new Vector3(other.contacts[0].normal.x, 0.0f, other.contacts[0].normal.z);
            
        if (other.collider.GetComponent<Wall>() || other.collider.GetComponent<Ball>())
        {
            if (_entity.hasReflectBallEvent == false)
            {
                _entity.AddReflectBallEvent(normal);
            }
        }
    }
}
