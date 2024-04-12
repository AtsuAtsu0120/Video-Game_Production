using System;
using UnityEngine;
using Week01.Scripts.Foundation;
using Random = UnityEngine.Random;

namespace Week01.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float _speedMax;
        [SerializeField] private float _speedMin;
        [SerializeField] private float _decaySpeed;
        [SerializeField] private Roulette _roulette;
        [SerializeField] private Needle _needle;

        private bool _isRotation;
        private float _rotationSpeed;

        private void Update()
        {
            if (!_isRotation && Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartRotation();
            }
        }

        private void FixedUpdate()
        {
            Rotation();
        }

        private void Rotation()
        {
            if (_rotationSpeed < 0)
            {
                _isRotation = false;
                Debug.Log(_needle.Result);
            }
            else
            {
                _roulette.Rotation(_rotationSpeed);
                _rotationSpeed -= _decaySpeed;
            }
        }
        private void StartRotation()
        {
            _isRotation = true;
            _rotationSpeed = Random.Range(_speedMin, _speedMax);
        }
    }
}
