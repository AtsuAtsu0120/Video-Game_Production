using System;
using R3;
using R3.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Week03.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public Observable<int> OnDamagePlayer => _onDamagePlayer;
        
        [SerializeField] private Arrow _arrowPrefab;
        [SerializeField] private float _spawnRate;
        [SerializeField] private int _damage;

        private readonly Subject<int> _onDamagePlayer = new();
        private ObjectPool<Arrow> _arrowObjectPool;
        private void Start()
        {
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(_spawnRate))
                .Subscribe(_ => SpawnArrow());

            _arrowObjectPool = new (30, _arrowPrefab);
        }
        private void SpawnArrow()
        {
            var arrow = _arrowObjectPool.ActiveObject();
            var randomPositionX = Random.Range(-10f, 10f);
            var position = arrow.transform.position;
            position.x = randomPositionX;
            position.y = transform.position.y;
            
            arrow.transform.position = position;
            
            arrow.OnCollisionEnter2DAsObservable()
                .Subscribe(other =>
                {
                    var arrowSelf = arrow;
                    if (other.collider.CompareTag("Player"))
                    {
                        _onDamagePlayer.OnNext(_damage);
                    }
                    
                    _arrowObjectPool.InactiveObject(arrowSelf);
                }).AddTo(arrow);
        }
    }
}
