namespace Eloi.Qwerty
{
    public class QwertyMono_TrainingAbstractTextArray : AbstractTrainingTextMono
    {
        
        public Qwerty_TrainingAbstractTextArray m_trainingReference;

        public override void GetRandomChar(out char choosedChar)
        {

            if (m_trainingReference == null)
            {
                choosedChar = ' ';
                return;
            }
            if (m_trainingReference.m_trainingReferences == null)
            {
                choosedChar = ' ';
                return;
            }
            m_trainingReference.GetRandomChar(out choosedChar);
        }

        public override void GetTrainingCharArray(out char[] charArray)
        {
            if (m_trainingReference == null)
            {
                charArray = new char[0];
                return;
            }
            if (m_trainingReference.m_trainingReferences == null)
            {
                charArray = new char[0];
                return;
            }
            m_trainingReference.GetTrainingCharArray(out charArray);
        }

        
    }

}