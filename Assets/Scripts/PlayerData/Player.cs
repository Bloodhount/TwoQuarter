using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _shootForce = 10f;
        private float _inputDirVertical, _inputDirHorizontal;

        [SerializeField] private Transform _startShotPosition;
        // [SerializeField] private GameObject _bullet;
        private Camera _camera;
        private Ship _ship;
        private Rigidbody _playerRigidbody;
        private AccelerationMove _moveTransform;
        //============================
        //private HealthBar _healthBar; public GameObject HealthBarPrefab;
        // [SerializeField] private int _initPrefabsCount = 3;
        // private BulletsPool _bulletsPool;

        public void Init(GameObject pooledGameObject)
        {
            // _bulletsPool = new BulletsPool(pooledGameObject, _startShotPosition, _initPrefabsCount);
        }
        //============================
        private void Start()
        {
            _camera = Camera.main;
            _playerRigidbody = GetComponent<Rigidbody>();
            _moveTransform = new AccelerationMove(_playerRigidbody, _speed, _acceleration);
            var _rotation = new RotationShip(transform);
            _ship = new Ship(_moveTransform, _rotation); // теперь можно поменять _ship на любой класс поддержывающий методы Move и Rotation(интерфейсы IMove, IRotation)
                                                         //-------------------------
                                                         // Init(_bullet);
            //GameObject healthBar = Instantiate(HealthBarPrefab);
            //_healthBar = healthBar.GetComponent<HealthBar>();
            //_healthBar.Setup(transform);
        }
        void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            PlayerInput();
        }

        private void PlayerInput()
        {

            _inputDirHorizontal = Input.GetAxis("Horizontal");
            _inputDirVertical = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                //Init(_bullet);

                GameObject bullet = BulletsPool.instance.Get();
                if (bullet != null)
                {
                    var temAmmunition = bullet.GetComponent<Rigidbody>();
                    // var temAmmunition = GameObject.Instantiate(_bullet, _startShotPosition.position, _startShotPosition.rotation).GetComponent<Rigidbody>();
                    temAmmunition.gameObject.transform.position = _startShotPosition.position;
                    temAmmunition.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    // temAmmunition.gameObject.transform.rotation = _startShotPosition.rotation;
                    temAmmunition.gameObject.SetActive(true);
                    temAmmunition.AddForce(_startShotPosition.up * _shootForce);
                    bullet.GetComponent<Bullet>().StartDisasbleGOTimer(); // StartCoroutine(StartTimer());
                }
                #region по методичке
                //var obj = _bulletsPool.Get();
                //if (obj != null)
                //{
                //    var temAmmunition = obj.GetComponent<Rigidbody>();//
                //                                                      // var temAmmunition = GameObject.Instantiate(_bullet, _startShotPosition.position, _startShotPosition.rotation).GetComponent<Rigidbody>();
                //    temAmmunition.gameObject.SetActive(true);
                //    temAmmunition.AddForce(_startShotPosition.up * _shootForce);
                //}
                //_bulletsPool.ReturnToPool(obj);
                #endregion
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                GameObject enemies = EnemiesPool.instance.Get();
                if (enemies != null)
                {
                    int random = Random.Range(-5, 5);
                    Vector3 _startVector = new Vector3(random, random, -1);

                    var temAmmunition = enemies.GetComponent<Rigidbody>();
                    temAmmunition.gameObject.SetActive(true);
                    temAmmunition.gameObject.transform.position = _startVector;
                    temAmmunition.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }
        private void FixedUpdate()
        {
            RbMove();
        }
        private void RbMove()
        {
            _ship.Move(_inputDirHorizontal, _inputDirVertical);
        }
        //private void OnDestroy()
        //{
        //    _bulletsPool.Dispose();
        //}
    }
}