using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Week01.Scripts.Core
{
    public class Roulette : MonoBehaviour
    {
        public void Rotation(float rotationSpeed)
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
    }
}
