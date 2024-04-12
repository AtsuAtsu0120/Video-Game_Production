using System;
using UnityEngine;
using Week01.Scripts.Foundation;

namespace Week01.Scripts.Core
{
    public class Needle : MonoBehaviour
    {
        public RouletteResult Result { get; private set; }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Result = Enum.Parse<RouletteResult>(other.name);
        }
    }
}
