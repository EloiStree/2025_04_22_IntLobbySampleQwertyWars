using UnityEngine;
using UnityEngine.Events;


namespace Eloi.Qwerty
{
    public class QwertyMono_TrainingTextAsset : AbstractTrainingTextMono
    {
        public Qwerty_TrainingTextAsset m_data;


        public override void GetRandomChar(out char charChoosed)
        {
            m_data.GetRandomChar(out charChoosed);
        }

        public override void GetTrainingCharArray(out char[] charArray)
        {
            m_data.GetTrainingChar(out charArray);
        }

    }

}