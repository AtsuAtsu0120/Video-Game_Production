using UnityEngine;
using R3;
using UnityEngine.UI;

namespace Week03.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Spawner _spawner;

        [SerializeField] private Image _hpImage;
        
        private void Start()
        {
            _spawner.OnDamagePlayer.Subscribe(damage =>
            {
                _player.Damage(damage);
            });
            _player.OnHpChange.Subscribe(hp =>
            {
                _hpImage.fillAmount = hp / (float)_player.MaxHp;
            });
        }

        private void Update()
        {
            ProvideInput();
        }

        private void ProvideInput()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _player.Move(true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                _player.Move(false);
            }
        }
    }
}
