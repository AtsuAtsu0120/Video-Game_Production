using UnityEngine;

namespace Week02.Scripts.Core
{
    public class Car : MonoBehaviour
    {
        public void Move(float speed)
        {
            Debug.Log(speed);
            
            var position = transform.position;
            position.x += speed;
            transform.position = position;
        }
    }
}
