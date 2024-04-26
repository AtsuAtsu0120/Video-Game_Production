using R3;
using UnityEngine;

namespace Week03.Scripts
{
    public class Player : MonoBehaviour
    {
        public int MaxHp => _maxHp;
        public Observable<int> OnHpChange => _hp;
        [SerializeField] private int _maxHp;

        private ReactiveProperty<int> _hp = new();

        private void Start()
        {
            _hp.Value = _maxHp;
        }

        public void Move(bool isRight)
        {
            var position = transform.position;
            position.x += isRight ? 0.1f : -0.1f;

            transform.position = position;
        }

        public void Damage(int damage)
        {
            _hp.Value -= damage;
        }
    }
}
