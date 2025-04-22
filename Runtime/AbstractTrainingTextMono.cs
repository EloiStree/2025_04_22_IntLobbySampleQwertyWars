using UnityEngine;


namespace Eloi.Qwerty
{
    public abstract class  AbstractTrainingTextMono : MonoBehaviour , I_TrainingText
    {
        public abstract void GetTrainingCharArray(out char[] charArray);
        public abstract void GetRandomChar(out char choosedChar);
    }
}