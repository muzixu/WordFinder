using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WordBase
    {
        // 单词长度
        public int Length = 0;

        // 随机排列的单词
        public string WordRandom;

        // 原单词
        private string _WordRaw;
        public string WordRaw
        {
            get { return _WordRaw; }
            set
            {
                if (_WordRaw != value) {

                    char[] _WordRandom = value.ToCharArray();

                    for (int i = 0; i < _WordRandom.Length; i++) {
                        int index = Random.Range(i, _WordRandom.Length - 1);
                        char tmp = _WordRandom[i];
                        _WordRandom[i] = _WordRandom[index];
                        _WordRandom[index] = tmp;
                    }

                    Length = value.Length;
                    _WordRaw = value;
                    WordRandom = new string(_WordRandom);
                }
            }
        }

    }
}
