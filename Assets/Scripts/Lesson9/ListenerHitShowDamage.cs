using System.Collections;
using System.Collections.Generic;
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

        private void Start()
        {
            _EnemyHealthLabel.text = "new Text ";
            // _EnemyHealthLabel.text = GameObject.Find("Text (TMP) total score (test) (1)").GetComponent<TextMeshProUGUI>().text;
            ValueOnOnHitChange(_EnemyHp.DamageValue);
        }
        public void Add(IHit value)
        {
            Log("before Add");
            value.OnHitChange += ValueOnOnHitChange;
            Log($"after Add {value} ...");
        }

        public void Remove(IHit value)

        {
            value.OnHitChange -= ValueOnOnHitChange;
            Log($"<color=red>Remove</color> ...");
        }
        private void ValueOnOnHitChange(int damage)
        {
            Debug.Log("<color=yellow>ValueOnOnHitChange</color>: " + damage);
            // _EnemyHealthLabel.text = $"<color=yellow> new Text  2</color>:";
            const int _maxAlphaValue = 255;
            _EnemyHealthLabel.GetComponent<TextMeshProUGUI>().alpha = _maxAlphaValue;
            _EnemyHealthLabel.text = $"<color=yellow>Enemy</color>: {gameObject.name} ," +
                $" HP: -<color=red>{damage}</color> damage";
            Invoke(nameof(SetAlpha), 0.5f);
        }
        void SetAlpha()
        {
            const int _minAlphaValue = 0;
            if (_EnemyHealthLabel.TryGetComponent(out TextMeshProUGUI text))  // TODO сделать плавную смену прозрачности
            {
                text.alpha = _minAlphaValue;
            }
        }
    }
}
