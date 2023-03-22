using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _hp;

        private void OnCollisionEnter(Collision collision)
        {
            if (_hp < 1)
            {
                Destroy(gameObject);
                if (_hp < 0)
                {
                    _hp = 0;
                }
            }
            else
            {
                _hp--;
            }
        }
    }
}
