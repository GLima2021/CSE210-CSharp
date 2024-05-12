using System;
using System.Collections.Generic;
using System.Text;

namespace MemorizationApp
{
    public class Scripture
    {
        private string[] _words;
        private bool[] _wordVisible;
        private readonly Random _random = new Random();

        public string Reference { get; }
        public string Text { get; }

        public Scripture(string reference, string text)
        {
            Reference = reference;
            Text = text;
            InitializeWords();
        }

        private void InitializeWords()
        {
            _words = Text.Split(' ');
            _wordVisible = new bool[_words.Length];
            for (int i = 0; i < _wordVisible.Length; i++)
            {
                _wordVisible[i] = true;
            }
        }

        public void HideRandomWord()
        {
            int index = _random.Next(_words.Length);
            while (!_wordVisible[index])
            {
                index = _random.Next(_words.Length);
            }
            _wordVisible[index] = false;
        }

        public string GetVisibleScripture()
        {
            StringBuilder visibleText = new StringBuilder();
            for (int i = 0; i < _words.Length; i++)
            {
                if (_wordVisible[i])
                {
                    visibleText.Append(_words[i] + " ");
                }
                else
                {
                    visibleText.Append("____ ");
                }
            }
            return visibleText.ToString().Trim();
        }

        public bool AllWordsHidden()
        {
            foreach (bool visible in _wordVisible)
            {
                if (visible)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
