using System.Collections;
using System.Collections.Generic;
using Mediator.MVVM;
using UnityEngine;

namespace Mediator
{
    public class MediatorExample : MonoBehaviour
    {
        #region MediatorBasic

        private Game _game;

        [ContextMenu("Test MediatorBasic Init")]
        private void TestMediatorBasicInit()
        {
            _game = new Game();
        }

        [ContextMenu("Test MediatorBasic Button")]
        private void TestMediatorBasicButton()
        {
            //  _game.();
        }

        [ContextMenu("Test MediatorBasic MusicPlayer")]
        private void TestMediatorBasicMusicPlayer()
        {
            //  _game.();
        }

        #endregion


        [SerializeField] private View _view;

        private IModel _model;
        private IViewModel _viewModel;

        [ContextMenu("Test MVVM Init")]
        private void TestMVVMInit()
        {
            _model = new Model("some name...");

            _viewModel = new ViewModel(_model);

           // _view.Initialize(_viewModel);
        }


        [ContextMenu("Test MVVM Add Score")]
        private void TestMVVMAddScore()
        {
            _viewModel.AddScore(5);
        }
    }
}
