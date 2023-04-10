using Asteroids;
using TMPro;
using UnityEngine;
using static UnityEngine.Debug;

namespace Observer
{
    public sealed class ListenerHitShowDamage : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _EnemyHp;
        [SerializeField] public TextMeshProUGUI _EnemyHealthLabel;
        const int _minAlphaValue = 0;
        const int _maxAlphaValue = 255;
        private void Start()
        {
            WriteMessageToLebel("new Text ");
            ValueOnOnHitChange(message: " Damage Value", damage: _EnemyHp.DamageValue);
        }

        public void WriteMessageToLebel(string message)
        {
            _EnemyHealthLabel.text = message;
        }
        public void Add(IHit value)
        {
            value.OnHitChange += ValueOnOnHitChange;
        }
        public void Remove(IHit value)
        {
            value.OnHitChange -= ValueOnOnHitChange;
        }
        private void ValueOnOnHitChange(int damage)
        {
            SetAlpha(_maxAlphaValue);
            //WriteMessageToLebel($"<color=yellow>Enemy</color>: {gameObject.name} ," +
            //    $" HP: color=red>{damage}</color> damage");
            _EnemyHealthLabel.text = $"<color=yellow>Enemy</color>: {gameObject.name} ," +
                $" <color=red>{damage}</color> damage";
            Invoke(nameof(SetAlpha), 0.9f);
        }
        private void ValueOnOnHitChange(int damage, string message)
        {
            SetAlpha(_maxAlphaValue);
            _EnemyHealthLabel.text = $"<color=yellow>Enemy</color>: {gameObject.name} ," +
                $" <color=red>{damage}</color> {message}";
            Invoke(nameof(SetAlpha), 0.9f);
        }
        void SetAlpha()
        {
            if (_EnemyHealthLabel.TryGetComponent(out TextMeshProUGUI text))  // TODO сделать плавную смену прозрачности
            {
                text.alpha = _minAlphaValue;
            }
        }
        void SetAlpha(int alphaValue)
        {
            int _alphaValue = alphaValue;
            if (_EnemyHealthLabel.TryGetComponent(out TextMeshProUGUI text))  // TODO сделать плавную смену прозрачности
            {
                text.alpha = _alphaValue;
            }
        }
    }
}
