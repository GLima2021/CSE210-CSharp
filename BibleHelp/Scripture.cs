using System;
using System.Linq;
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

        public void HideRandomWords(int count)
        {
            var visibleIndices = Enumerable.Range(0, _words.Length).Where(i => _wordVisible[i]).ToList();
            if (count > visibleIndices.Count)
            {
                count = visibleIndices.Count;
            }

            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(visibleIndices.Count);
                _wordVisible[visibleIndices[index]] = false;
                visibleIndices.RemoveAt(index);
            }
        }

        public string GetVisibleScripture()
        {
            var visibleText = new StringBuilder();
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
            return !_wordVisible.Any(visible => visible);
        }
    }
}
