using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Eloi.Qwerty
{
    [System.Serializable]
    public class Qwerty_TrainingAbstractTextArray : I_TrainingText
    {
        public AbstractTrainingTextMono[] m_trainingReferences;

        public void GetRandomChar(out char choosedChar)
        {
            m_hideIndex++;
            GetRandomCharFromModuloIndexGroup(m_hideIndex, out choosedChar);
        }

        private int m_hideIndex = 0;
        public void GetRandomCharFromModuloIndexGroup(int index, out char choosedChar)
        {
            if (m_trainingReferences == null)
            {
                choosedChar = ' ';
                return;
            }
            if (m_trainingReferences.Length == 0)
            {
                choosedChar = ' ';
                return;
            }
            int moduloIndex = index % m_trainingReferences.Length;
            m_trainingReferences[moduloIndex].GetRandomChar(out choosedChar);

        }

        public void GetTrainingCharArray(out char[] charArray)
        {
            List<char> charList = new List<char>();
            for (int i = 1; i < m_trainingReferences.Length; i++)
            {
                char[] tempArray;
                m_trainingReferences[i].GetTrainingCharArray(out tempArray);
                charList.AddRange(tempArray);
            }
            charArray = charList.Distinct().ToArray();
        }

     
    }

    [System.Serializable]
    public class Qwerty_TrainingTextAssetArray : I_TrainingText
    {
        public TextAsset [] m_trainingReferences;

        public void GetRandomChar(out char choosedChar)
        {
            m_hideIndex++;
            GetRandomCharFromModuloIndexGroup(m_hideIndex, out choosedChar);
        }

        private int m_hideIndex = 0;
        public void GetRandomCharFromModuloIndexGroup(int index, out char choosedChar)
        {
            if (m_trainingReferences == null)
            {
                choosedChar = ' ';
                return;
            }
            if (m_trainingReferences.Length == 0)
            {
                choosedChar = ' ';
                return;
            }
            int moduloIndex = index % m_trainingReferences.Length;
            if (m_trainingReferences[moduloIndex] == null)
            {
                choosedChar = ' ';
                return;
            }
            if (m_trainingReferences[moduloIndex].text == null)
            {
                choosedChar = ' ';
                return;
            }
            int arrayLength = m_trainingReferences[moduloIndex].text.Length;
            if (arrayLength == 0)
            {
                choosedChar = ' ';
                return;
            }

            int randomIndex = Random.Range(0, arrayLength);
            choosedChar= m_trainingReferences[moduloIndex].text[randomIndex];


        }

        public void GetTrainingCharArray(out char[] charArray)
        {
            List<char> charList = new List<char>();
            for (int i = 0; i < m_trainingReferences.Length; i++)
            {
                if (m_trainingReferences[i] == null)
                {
                    continue;
                }
                if (m_trainingReferences[i].text == null)
                {
                    continue;
                }
                char[] tempArray = m_trainingReferences[i].text.ToCharArray();
                charList.AddRange(tempArray);
            }
            charArray = charList.Distinct().ToArray();
        }

        
    }

}