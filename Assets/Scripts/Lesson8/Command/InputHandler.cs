using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids.Command
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Transform _box;

        [SerializeField] private float _moveDistance;

        private ICommand _buttonW;
        private ICommand _buttonS;
        private ICommand _buttonA;
        private ICommand _buttonD;
        private ICommand _buttonB;
        private ICommand _buttonZ;

        [SerializeField] private readonly List<ICommand> _oldCommands = new List<ICommand>();
        [SerializeField] private List<string> _stringCommandsView = new List<string>();

        void Start()
        {
            _buttonW = new MoveUp(_moveDistance, _box);
            _buttonS = new MoveDown(_moveDistance, _box);
            _buttonA = new MoveLeft(_moveDistance, _box);
            _buttonD = new MoveRight(_moveDistance, _box);
            _buttonB = new DoNothing();
            _buttonZ = new UndoCommand(_oldCommands);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (_buttonW.TryExecute())
                {
                    AddToList(_buttonW);
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_buttonS.TryExecute())
                {
                    AddToList(_buttonS);
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_buttonA.TryExecute())
                {
                    AddToList(_buttonA);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (_buttonD.TryExecute())
                {
                    AddToList(_buttonD);
                }
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (_buttonB.TryExecute())
                {
                    AddToList(_buttonB);
                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _buttonZ.TryExecute();
                if (_stringCommandsView.Count > 0)
                {
                    _stringCommandsView.RemoveAt(_stringCommandsView.Count - 1);
                    Log(_buttonZ + ". " + _oldCommands.GetType().Name);
                }
            }
        }

        public void AddToList(ICommand button)
        {
            _oldCommands.Add(button);
            _stringCommandsView.Add(button.ToString());
            Log("AddToList. " + button);
        }
        public void MoveLeft()
        {
            if (_buttonA.TryExecute())
            {
                AddToList(_buttonA);
                Log(".MoveLeft");
            }
        }
        public void MoveRight()
        {
            if (_buttonD.TryExecute())
            {
                AddToList(_buttonD);
                Log(".MoveRight");
            }
        }
    }
}
