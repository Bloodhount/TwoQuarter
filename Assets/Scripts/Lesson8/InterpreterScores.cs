using TMPro;
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
            const int _maxAlphaValue = 255;
            _textAddScore.GetComponent<TextMeshProUGUI>().alpha = _maxAlphaValue;  // TODO ������� ������� ����� ������������
            _textAddScore.text = " + " + value;                     // ������ ������� https://www.youtube.com/watch?v=XnHpJAb7yh0&list=PLKWKqJ1bWRh72mlJX-V_mt1bItUy2aSBu&index=15

            scores += value;
            string tmp = StringConverter(scores);
            _textTotalScoreTest.text = $"TEST: {scores} ";
            _textTotalScore.text = "  " + StringConverter(scores);

            Invoke(nameof(SetAlpha), 1.5f);
        }
        void SetAlpha()
        {
            const int _minAlphaValue = 0;
            if (_textAddScore.TryGetComponent(out TextMeshProUGUI text))  // TODO ������� ������� ����� ������������
            {
                text.alpha = _minAlphaValue;
            }
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
            switch (number)
            {
                case >= 1000000000000:
                    {
                        float curr = number;
                        var tmp = curr / 1000000000000;
                        return $" {tmp.ToString("0.0")} T";
                    }

                case >= 1000000000:
                    {
                        float curr = number;
                        var tmp = curr / 1000000000;
                        return $" {tmp.ToString("0.00")} B";
                    }

                case >= 1000000:
                    {
                        float curr = number;
                        var tmp = curr / 1000000;
                        return $" {tmp.ToString("0.00")} M";
                    }

                case >= 1000:
                    {
                        float curr = number;
                        var tmp = curr / 1000;
                        return $" {tmp.ToString("0.00")} K";
                    }

                case >= 1:
                    return $" {number}  ";
            }

            return string.Empty + "string.Empty";
        }

        //String.Format(tmp);  Console.WriteLine("{0:D7}",12345);
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
