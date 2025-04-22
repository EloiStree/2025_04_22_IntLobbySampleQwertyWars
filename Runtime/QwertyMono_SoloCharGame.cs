using UnityEngine;
using UnityEngine.Events;


namespace Eloi.Qwerty
{

    public class QwertyMono_SoloCharGame : MonoBehaviour
    {
        public AbstractTrainingTextMono m_trainingReference;
        public char m_charToWrite;
        public UnityEvent m_onFailAttempt;
        public UnityEvent<char> m_onValideAttempt;
        public UnityEvent<char> m_onNewCharChoosen;

        public void PushIn(char charToTry)
        {
            if (m_charToWrite == charToTry)
            {



                m_onValideAttempt.Invoke(charToTry);
                ChooseNewChar();
            }
            else
            {
                m_onFailAttempt.Invoke();
            }
        }

        private void ChooseNewChar()
        {
            GetRandomChar(out m_charToWrite);
            m_onNewCharChoosen.Invoke(m_charToWrite);
        }

        private void GetRandomChar(out char charChoosed)
        {
            m_trainingReference.GetRandomChar(out charChoosed);

        }

        public void ReloaNewCharWithoutAttempt()
        {
            ChooseNewChar();
        }

    }
}