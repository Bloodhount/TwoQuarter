using System.Collections;
using System.Collections.Generic;
using Mediator.MVVM;
using TMPro;
using UnityEngine;
using static UnityEngine.Debug;

namespace Mediator
{
    public class MediatorExample : MonoBehaviour
    {
        #region MediatorBasic

        private Game _game;

       // [ContextMenu("Test MediatorBasic Init")]
        private void TestMediatorBasicInit()
        {
            _game = new Game();
        }

       // [ContextMenu("Test MediatorBasic Button")]
        private void TestMediatorBasicButton()
        {
            //  _game.();
        }

       // [ContextMenu("Test MediatorBasic MusicPlayer")]
        private void TestMediatorBasicMusicPlayer()
        {
            //  _game.();
        }

        #endregion

        [SerializeField]
        private static TextMeshProUGUI _text;
        [SerializeField] private View _view;

        private IModel _model;
        private IViewModel _viewModel;

        [ContextMenu("Test MVVM Init")]
        private void TestMVVMInit()
        {
            _model = new Model("some name..."); Log("_model =" + _model.Name);

            _viewModel = new ViewModel(_model); Log("_viewModel =" + _viewModel.Model.Name);

            _view.Initialize(_viewModel); Log("_view.Initialize " + _view.GetType().ToString());
        }


        [ContextMenu("Test MVVM Add Score")]
        private void TestMVVMAddScore()
        {
            _viewModel.AddScore(5);

            // int totalScore = _viewModel.Model.Score;
            //_text = GameObject.Find("Text for tests (TMP)  (3)").gameObject.GetComponent<TextMeshProUGUI>();
            //TextMessager.TextMessageUpdate(_text, totalScore.ToString());
        }
    }
}
