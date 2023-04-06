<<<<<<< HEAD
using UnityEngine;
using UnityEngine.UI;
using ChainOfResponsibility;
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69

namespace Command
{
    public class CommandExample : MonoBehaviour
    {
<<<<<<< HEAD
        [SerializeField] public InputHandler InputHandler;
        private Button _leftButton;
        private Button _rightButton;
        private InputHandler obj;

        void Awake()
        {
            _leftButton = GameObject.Find("ButtonLeft").GetComponent<Button>();
            _rightButton = GameObject.Find("ButtonRight").GetComponent<Button>();
            obj = Instantiate(InputHandler, Vector3.zero, Quaternion.identity);
        }
        private void OnEnable()
        {
            _leftButton.onClick.AddListener(MoveLeftHandler);
            _rightButton.onClick.AddListener(MoveRightHandler);
        }
        private void OnDisable()
        {
            _leftButton.onClick.RemoveListener(MoveLeftHandler);
            _rightButton.onClick.RemoveListener(MoveRightHandler);
        }
        public void MoveLeftHandler()
        {
            obj.MoveLeft();
            Debug.Log("MoveLeftHandler");

        }
        public void MoveRightHandler()
        {
            obj.MoveRight();
            Debug.Log("MoveRightHandler");
=======
        public InputHandler InputHandler;
        void Start()
        {
            Instantiate(InputHandler);
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
        }
    }
}
