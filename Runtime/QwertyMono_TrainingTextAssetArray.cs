namespace Eloi.Qwerty
{
    public class QwertyMono_TrainingTextAssetArray : AbstractTrainingTextMono
    {
        public Qwerty_TrainingTextAssetArray m_trainingReference;

        public override void GetRandomChar(out char choosedChar)
        {
            m_trainingReference.GetRandomChar(out choosedChar);
        }
        public override void GetTrainingCharArray(out char[] charArray)
        {
            m_trainingReference.GetTrainingCharArray(out charArray);
        }
        

    }

}