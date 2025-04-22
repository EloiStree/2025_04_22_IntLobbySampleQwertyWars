using UnityEngine;


namespace Eloi.Qwerty
{
    [System.Serializable]
    
    public class Qwerty_TrainingTextAsset 
{
    public TextAsset m_trainingChar;
    public string m_trainingTextLoaded;

    public void ForceMemoryReload()
    {
        m_trainingTextLoaded = string.Empty;
        if (m_trainingChar == null)
        {
            return;
        }
        if (m_trainingChar.text == null)
        {
            return;
        }
        m_trainingTextLoaded = m_trainingChar.text;

    }
    public void GetTrainingChar(out char[] charArray)
    {
        if (m_trainingChar == null)
        {
            charArray = new char [0];
            return;
        }
        if(string.IsNullOrEmpty(m_trainingTextLoaded))
        {
            m_trainingTextLoaded = m_trainingChar.text;
        }


        charArray = m_trainingTextLoaded.ToCharArray();
    }

    public void GetRandomChar(out char choosedChar)
    {
        char[] charArray;
        GetTrainingChar(out charArray);
        if (charArray.Length == 0)
        {
            choosedChar = ' ';
            return;
        }
        int randomIndex = Random.Range(0, charArray.Length);
        choosedChar = charArray[randomIndex];
    }
}

}