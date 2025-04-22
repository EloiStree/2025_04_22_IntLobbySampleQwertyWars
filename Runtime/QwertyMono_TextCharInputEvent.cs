using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


namespace Eloi.Qwerty
{
    public class QwertyMono_TextCharInputEvent : MonoBehaviour
    {
           private Keyboard keyboard;

        public UnityEvent<Key> m_onKeyPressed = new UnityEvent<Key>();
        public UnityEvent<Key> m_onKeyReleased = new UnityEvent<Key>();
        public UnityEvent<Key[]> m_onKeyPressingArray = new UnityEvent<Key[]>();
        public UnityEvent<char> m_onTextInput = new UnityEvent<char>();
        public UnityEvent<string> m_onKeyPressedAsString = new UnityEvent<string>();
        public UnityEvent<string> m_onKeyReleasedAsString = new UnityEvent<string>();

        private void Awake()
        {
            keyboard = Keyboard.current;
            keyboard.onTextInput += OnTextInput;
        }

        private void OnTextInput(char obj)
        {
            m_onTextInput.Invoke(obj);
        }

        public Key[] GetKeysOfEnum()
        {
            return (Key[])System.Enum.GetValues(typeof(Key));
        }


        public List<Key> m_previousKeys = new List<Key>();
        public List<Key> m_currentKeys = new List<Key>();
        public List<Key> m_removedKeys = new List<Key>();
        public List<Key> m_addedKeys = new List<Key>();


        public void Update()
        {
            UpdateKeys();
        }

        public void UpdateKeys()
        {

            m_previousKeys.Clear();
            m_previousKeys.AddRange(m_currentKeys);
            m_currentKeys.Clear();
            foreach (var kvp in GetKeysOfEnum())
            {
                if (kvp == Key.None)
                    continue;
                if (kvp == Key.IMESelected)
                    continue;

                    try
                {
                    if (keyboard[kvp].isPressed)
                    {
                        m_currentKeys.Add(kvp);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error checking key {kvp}: {e.Message}");
                }
            }
            // using LINQ to find key using distinct
            m_addedKeys = m_currentKeys.Except(m_previousKeys).ToList();
            m_removedKeys = m_previousKeys.Except(m_currentKeys).ToList();


            foreach (var key in m_addedKeys)
            {
                m_onKeyPressed.Invoke(key);
                m_onKeyPressedAsString.Invoke(key.ToString());
            }
            foreach (var key in m_removedKeys)
            {
                m_onKeyReleased.Invoke(key);
                m_onKeyReleasedAsString.Invoke(key.ToString());
            }
            m_onKeyPressingArray.Invoke(m_currentKeys.ToArray());
        }

        public List<Key> GetAllPressedKeys()
        {
            List<Key> keys = new List<Key>();
            foreach (var kvp in GetKeysOfEnum())
            {
                if (keyboard[kvp].isPressed)
                {
                    keys.Add(kvp);
                }
            }
            return keys;
        }
    }
}