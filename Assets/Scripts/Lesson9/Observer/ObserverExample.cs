using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Observer
{
    public class ObserverExample : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI textGOdancerBob;
        [SerializeField]
        TextMeshProUGUI textGOsingerJill;

        private Radio _radio;
        private Dancer _dancerBob;
        private Singer _singerJill;

        private void Awake()
        {
            _dancerBob = new Dancer(); 
        }
            
        private void Start()
        {
            _dancerBob.SendRefToTextGO(textGOdancerBob);
        }

        [ContextMenu("TestObserver")]
        private void TestObserver()
        {
            _radio = new Radio();

            //  _dancerBob = new Dancer(textGO);
            _dancerBob.Listen(_radio); // radio.OnNextSong += OnNextSong;

            _singerJill = new Singer();
            _singerJill.SendRefToTextGO(textGOsingerJill);
            _singerJill.Listen(_radio);
        }

        [ContextMenu("Wait 1 minute")]
        private void WaitABit()
        {
            _radio.Wait(1);
        }

        [ContextMenu("Wait 5 minute")]
        private void WaitABitLonger()
        {
            _radio.Wait(5);
            if (_dancerBob._isSubscribe)
            {
                _dancerBob.UnsubscribeFromListening(_radio);
            }
        }
    }
}
