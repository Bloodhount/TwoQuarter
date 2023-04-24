using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore;
 using UnityEngine.UI;

namespace Mediator.MVVM
{
    public class View //: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
         [SerializeField] private Text _text2;

        private IViewModel _viewModel;
        public void Initialize ()// (IViewModel viewModel)
        {
           // _viewModel = viewModel;

           // _viewModel.OnScoreChanged += OnScoreChanged;

          //  OnScoreChanged(_viewModel.Model.Score);
        }

        private void OnScoreChanged(int score)
        {
            _text.text = score.ToString();
        }
        private void OnDestroy()
        {
            _viewModel.OnScoreChanged -= OnScoreChanged;
        }
    }
}
