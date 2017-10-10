using System;
using System.Collections;

namespace Iterators
{
    public class IterationSample : IEnumerable
    {
        string[] sequence = {"a","b","c","d","e"};

        public IEnumerator GetEnumerator()
        {
            //using long form of IEnumerator
            //return new Iterator(sequence);

            //using short form of IEnumerator
            for (int index = 0; index < sequence.Length; index++)
            {
                yield return sequence[index];
            }
        }
    }

    public class Iterator : IEnumerator
    {
        private string[] _sequence;
        int index;

        public Iterator(string[] sequence)
        {
            this._sequence = sequence;
            this.index = -1;
        }

        public object Current
        {
            get
            {
                return _sequence[index];
            }
        }

        public bool MoveNext()
        {
            index++;

            return index < _sequence.Length;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
