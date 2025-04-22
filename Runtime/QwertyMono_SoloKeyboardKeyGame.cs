using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


namespace Eloi.Qwerty
{
    public class QwertyMono_SoloKeyboardKeyGame : MonoBehaviour
    {

        public List<Key> m_trainingKeyGroup = new List<Key>();
        public Key m_keyToWrite;
        public UnityEvent m_onFailAttempt;
        public UnityEvent<Key> m_onValideAttempt;
        public UnityEvent<Key> m_onNewCharChoosen;
        public UnityEvent<string> m_onNewCharChoosenAsString;

        public void PushIn(Key keyToTry)
        {
            if (m_keyToWrite == keyToTry)
            {
                m_onValideAttempt.Invoke(keyToTry);
                ChooseNewKey();
            }
            else
            {
                m_onFailAttempt.Invoke();
            }
        }
        public Key[] GetKeysOfEnum()
        {
            return (Key[])System.Enum.GetValues(typeof(Key));
        }

        public enum KeyGroup { F13ToF24, None, AllNumpad }

        public KeyGroup [] m_removeKeyGroup = new KeyGroup[] {  KeyGroup.F13ToF24 , KeyGroup.AllNumpad};
        private void Reset()
        {

            RefreshKeyList();
        }
        private void Awake()
        {
            RefreshKeyList();
        }

        private void RefreshKeyList()
        {
            m_trainingKeyGroup.Clear();
            m_trainingKeyGroup.AddRange(GetKeysOfEnum());
            m_trainingKeyGroup.Remove(Key.None);
            m_trainingKeyGroup.Remove(Key.IMESelected);
            if (m_removeKeyGroup.Contains(KeyGroup.F13ToF24))
            {
                m_trainingKeyGroup.Remove(Key.F13);
                m_trainingKeyGroup.Remove(Key.F14);
                m_trainingKeyGroup.Remove(Key.F15);
                m_trainingKeyGroup.Remove(Key.F16);
                m_trainingKeyGroup.Remove(Key.F17);
                m_trainingKeyGroup.Remove(Key.F18);
                m_trainingKeyGroup.Remove(Key.F19);
                m_trainingKeyGroup.Remove(Key.F20);
                m_trainingKeyGroup.Remove(Key.F21);
                m_trainingKeyGroup.Remove(Key.F22);
                m_trainingKeyGroup.Remove(Key.F23);
                m_trainingKeyGroup.Remove(Key.F24);
            }
            if (m_removeKeyGroup.Contains(KeyGroup.AllNumpad))
            {
                m_trainingKeyGroup.Remove(Key.Numpad0);
                m_trainingKeyGroup.Remove(Key.Numpad1);
                m_trainingKeyGroup.Remove(Key.Numpad2);
                m_trainingKeyGroup.Remove(Key.Numpad3);
                m_trainingKeyGroup.Remove(Key.Numpad4);
                m_trainingKeyGroup.Remove(Key.Numpad5);
                m_trainingKeyGroup.Remove(Key.Numpad6);
                m_trainingKeyGroup.Remove(Key.Numpad7);
                m_trainingKeyGroup.Remove(Key.Numpad8);
                m_trainingKeyGroup.Remove(Key.Numpad9);
                m_trainingKeyGroup.Remove(Key.NumpadEnter);
                m_trainingKeyGroup.Remove(Key.NumpadPlus);
                m_trainingKeyGroup.Remove(Key.NumpadMinus);
                m_trainingKeyGroup.Remove(Key.NumpadMultiply);
                m_trainingKeyGroup.Remove(Key.NumpadDivide);
                m_trainingKeyGroup.Remove(Key.NumpadPeriod);
                m_trainingKeyGroup.Remove(Key.NumpadEquals);

            }
            ReloaNewKeyWithoutAttempt();
        }

        private void ChooseNewKey()
        {
            GetRandomKey(out m_keyToWrite);
            m_onNewCharChoosen.Invoke(m_keyToWrite);
            m_onNewCharChoosenAsString.Invoke(m_keyToWrite.ToString());
        }

        public void GetRandomKey(out Key charChoosed)
        {
            int randomIndex = Random.Range(0, m_trainingKeyGroup.Count);
            charChoosed = m_trainingKeyGroup[randomIndex];
            m_keyToWrite = charChoosed;

        }

        public void ReloaNewKeyWithoutAttempt()
        {
            ChooseNewKey();
        }

    }
}