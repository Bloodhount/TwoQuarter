using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
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
                    _oldCommands.Add(_buttonW);
                    _stringCommandsView.Add(_buttonW.ToString());
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_buttonS.TryExecute())
                {
                    _oldCommands.Add(_buttonS);
                    _stringCommandsView.Add(_buttonS.ToString());
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_buttonA.TryExecute())
                {
                    _oldCommands.Add(_buttonA);
                    _stringCommandsView.Add(_buttonA.ToString());
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (_buttonD.TryExecute())
                {
                    _oldCommands.Add(_buttonD);
                    _stringCommandsView.Add(_buttonD.ToString());
                }
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (_buttonB.TryExecute())
                {
                    _oldCommands.Add(_buttonB);
                    _stringCommandsView.Add(_buttonB.ToString());

                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _buttonZ.TryExecute();
                if (_stringCommandsView.Count != 0)
                {
                    _stringCommandsView.RemoveAt(_stringCommandsView.Count - 1);
                }
            }
        }
    }
}
