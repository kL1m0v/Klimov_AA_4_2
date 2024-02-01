using UnityEngine;


namespace Arkanoid
{
    public class BallMover : MonoBehaviour
    {
        private float speed;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        internal void SetSpeed(float ballSpeed)
        {
            speed = ballSpeed;
        }

        
        
    }


}

