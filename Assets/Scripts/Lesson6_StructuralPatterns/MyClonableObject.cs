using UnityEngine;


namespace Asteroids.Prototype
{
    public class MyClonableObject : MonoBehaviour
    {
        [SerializeField] private int _health;
        private static int _cloneCount = 0;
        public MyClonableObject Clone()
        {
            _cloneCount++;

            var newObject = new GameObject(name: $"{name} clone #{_cloneCount}");
            var myClonableObject = newObject.AddComponent<MyClonableObject>();

            // далее нужно обращаться ко всем компонентам копируемого оригинала и-
            // -и в ручную прописывать все что нужно скопировать !!!
            if (gameObject.TryGetComponent<Transform>(out var transform))
            {
                var newTransform = newObject.transform;
                //       newTransform = transform + new Vector3(0,0,0);
                //var newTransform = newObject.AddComponent<Transform>();
                //newTransform.transform = transform.transform;
                //newTransform.position = transform.position;
                newTransform.localScale = transform.localScale;

                // и.т.п
            }
            if (gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                var newRigidbody = newObject.AddComponent<Rigidbody>();
                newRigidbody.mass = rigidbody.mass;
                newRigidbody.velocity = rigidbody.velocity;
                newRigidbody.angularVelocity = rigidbody.angularVelocity;
                newRigidbody.useGravity = rigidbody.useGravity;
                newRigidbody.constraints = rigidbody.constraints;
                // и.т.п
            }

            // ??? TODO протестить...
            if (gameObject.GetComponentInChildren<SpriteRenderer>().TryGetComponent<SpriteRenderer>(out var spriteRenderer))
            {
                var newSpriteRenderer = newObject.AddComponent<SpriteRenderer>();
                newSpriteRenderer.sprite = spriteRenderer.sprite;
            }
            if (gameObject.TryGetComponent<PlayerPursuit>(out var playerPursuit))
            {
                var newPlayerPursuit = newObject.AddComponent<PlayerPursuit>();
                newPlayerPursuit.SetRandomSpeed(44, 88);
            }
            // for example
            myClonableObject._health = _health;
            newObject.transform.position = transform.position + Vector3.right * _cloneCount;
            return myClonableObject;
        }
    }
}
