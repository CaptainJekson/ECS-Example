using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameEntity _entity;
    
    public GameEntity Entity => _entity;
    
    public void Init(GameEntity entity)
    {
        _entity = entity;
    }

    private void OnCollisionEnter(Collision other)
    {
        var normal = new Vector3(other.contacts[0].normal.x, 0.0f, other.contacts[0].normal.z);
            
        if (other.collider.GetComponent<Wall>())
        {
            if (_entity.hasReflectBallEvent == false)
            {
                _entity.AddReflectBallEvent(normal);
            }
        }
        
        if (other.collider.GetComponent<Ball>())
        {
            if (Entity.hasReflectBallEvent == false)
            {
                var typeCurrentBall = Entity.ballComponents.ballType;
                var typeCollisionBall = other.collider.GetComponent<Ball>().Entity.ballComponents.ballType;

                if (typeCurrentBall == typeCollisionBall)
                {
                    Entity.AddReflectBallEvent(normal);
                }
            }
        }
    }
    
    public void OnCollisionStay(Collision other)
    {
        if (other.collider.GetComponent<Ball>())
        {
            var typeCurrentBall = Entity.ballComponents.ballType;
            var typeCollisionBall = other.collider.GetComponent<Ball>().Entity.ballComponents.ballType;
    
            if (typeCurrentBall != typeCollisionBall)
            {
                if (Entity.hasReduceBallEvent == false)
                {
                    Entity.AddReduceBallEvent(other.collider.GetComponent<Ball>());
                }
            }
        }
    }
    
    public void OnCollisionExit(Collision other)
    {
        if (other.collider.GetComponent<Ball>())
        {
            if (Entity.hasReduceBallEvent)
            {
                Entity.RemoveReduceBallEvent();
            }
        }
    }
}
