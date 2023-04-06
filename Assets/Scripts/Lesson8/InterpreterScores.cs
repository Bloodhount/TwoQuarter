using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Interpreter
{
    public class InterpreterScores : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        // [SerializeField] private TextMeshProUGUI _textTotalScores;

        int scores = 0;
        public void Interpret(string value) // (string value) 
        {
            if (int.TryParse(value, out var number))
            {
                scores += number;
                _text.text = "  " + StringConverter(scores);
            }
            //_textTotalScores.text = scores.ToString();
        }
        public void Interpret(int value) // (string value) 
        {

            scores += value;
            _text.text = "  " + StringConverter(scores);
            //  _textTotalScores.text = scores.ToString();
        }

        private string StringConverter(int number)
        {
            if (number < 0 || number > 100000000)
            {
                return "incorrect data, enter a number from 0 to 10000";
            }

            //if (number > 950 || number < 1200) return " 1K ";
            //if (number > 1200 || number < 1700) return " 1.5K ";
            //if (number > 1700 || number < 2200) return " 2K ";
            //if (number is > 2200 or < 2700) return " 2.5K ";
            //if (number is > 2700 or < 3200) return " 2K ";

            return ValidateArgument(number);
            return string.Empty;
        }
        static string ValidateArgument(int number)
        {
            float curr = number / 1000;
            float min = curr * 0.7f;
            float max = curr * 1.2f;
            if (curr > min || curr < max)
            {
                if (curr >= 1000)
                {
                    return $" {curr} M ";
                }
                return $" {curr} K ";
            }


            return string.Empty + "string.Empty";
        }
        static string ValidateArgument(int[] number)
        {
            int count = number.Length;

            for (int i = 0; i < count; i++)
            {
                //if (number is > 2200 or < 2700)
                //{
                //   // " 2.5K ";
                //}
                float inNum = number[i];
                float curr = inNum / 1000;

                float min = count * 0.7f;
                float max = count * 1.2f;
                if (curr > min || curr < max)
                {
                    return $" {curr} K ";
                    count++;
                }
            }
            return string.Empty + "string.Empty";
        }
        //string s = ValidateArgument(number);
    }
}
