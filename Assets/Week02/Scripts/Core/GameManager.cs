using R3;
using TMPro;
using UnityEngine;

namespace Week02.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        [Header("▼設定")] 
        [SerializeField] private float _decaySpeed;
        
        [Header("コンポーネント")]
        [SerializeField] private Flag _flag;
        [SerializeField] private DragHandler _dragHandler;
        [SerializeField] private Car _car;
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private TextMeshProUGUI _distance;

        private bool _isStart;
        private float _speed;
        private void Awake()
        {
            _dragHandler.SpeedSubject.Where(_ => !_isStart)
                .Subscribe(speed =>
                {
                    _speed = speed;
                    _isStart = true;
                    _audioSource.Play();
                });
        }

        private void FixedUpdate()
        {
            if (_isStart)
            {
                _car.Move(_speed);
                if (_speed < 0)
                {
                    _isStart = false;
                }

                _speed -= _decaySpeed;
            }

            var distance = (_flag.transform.position - _car.transform.position).sqrMagnitude;
            _distance.SetText("Distance from Flag\n{0}m", distance);
        }
    }
}