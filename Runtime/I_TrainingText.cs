namespace Eloi.Qwerty
{
    public interface I_TrainingText
    {
        void GetTrainingCharArray(out char[] charArray);
        void GetRandomChar(out char choosedChar);
    }
}