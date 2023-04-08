using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace Interpreter
{
    public class InterpreterScores : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTotalScore;
        [SerializeField] private TextMeshProUGUI _textTotalScoreTest;
        [SerializeField] private TextMeshProUGUI _textAddScore;

        long scores = 0;
        public void Interpret(string value)
        {
            if (int.TryParse(value, out var number))
            {
                scores += number;
                _textAddScore.text = "  " + StringConverter(scores);
            }
        }
        public void Interpret(long value)
        {
            _textAddScore.GetComponent<TextMeshProUGUI>().alpha = 255;
            _textAddScore.text = " + " + value;

            scores += value;
            string tmp = StringConverter(scores);
            //String.Format(tmp);  Console.WriteLine("{0:D7}",12345);
            _textTotalScoreTest.text = $"  {scores} ";
            _textTotalScore.text = "  " + StringConverter(scores);

            Invoke(nameof(SetAlpha), 1.5f);
        }
        void SetAlpha()
        {
            _textAddScore.GetComponent<TextMeshProUGUI>().alpha = 0;
        }

        private static string StringConverter(long number)
        {
            if (number < 0 || number > 10000000000000)
            {
                return "incorrect data, enter a number from 0 to 10.000.000.000.000";
            }

            return ValidateArgument(number);
        }
        static string ValidateArgument(long number)
        {
           // float curr = number / 1000;
            //float min = curr * 0.5f;
            //float max = curr * 2.2f;

            if (number >= 1000000000000)
            {
                float curr = number;
                var tmp = curr / 1000000000000;
                return $" {tmp.ToString("0.0")} T";
            }
            else if (number >= 1000000000)
            {
                float curr = number ;
                var tmp = curr / 1000000000;
                return $" {tmp.ToString("0.00")} B";
            }
            else if (number >= 1000000) // (curr > min || curr < max)
            {
                float curr = number ;
                var tmp = curr / 1000000;
                return $" {tmp.ToString("0.00")} M";
                // return $" {tmp.ToString("0.0")} K ";
                // _textTotalScoreTest.text = $"  {scores} ";
                // return $" {number.ToString("0.0")} K ";
                //return $" {curr.ToString("0.0")} K ";
                //return $" {curr.ToString("0.0")} K ";
            }
            else if(number >= 1000)
            {
                float curr = number;
                var tmp = curr / 1000;
                return $" {tmp.ToString("0.00")} K";
            }
            else if (number >= 1)
            {
                return $" {number}  ";
            }

            return string.Empty + "string.Empty";
        }
        /*
            ������      (���.) 	            	10^3 	10^3
            �������     (���) 	million     	10^6 	10^6
            ��������    (����) 	milliard    	10^9 	10^9
            �������         	billion     	10^9 	10^12
            ��������        	billiard         	� 	10^15
            ��������    (����) 	trillion 	    10^12 	10^18
            ���������       	trilliard       	� 	10^21
            �����������     	quadrillion 	10^15 	10^24 
            ������������    	quadrilliard    	� 	10^27
            ����������� 	    quintillion 	10^18 	10^30 
         */
    }
}
