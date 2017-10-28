using System;
using System.Collections;

namespace Iterators
{
    /// <summary>
    /// Using short form of IEnumerator (yield return)
    /// </summary>
    public sealed class SampleCollection_UsingYield : IEnumerable
    {
        string[] sequence = { "u", "v", "w", "x", "y", "z" };

        public IEnumerator GetEnumerator()
        {
            
            for (int index = 0; index < sequence.Length; index++)
            {
                yield return sequence[index];
            }
        }
    }

    /// <summary>
    /// Using long form of IEnumerator
    /// </summary>
    public sealed class SampleCollection_OldSchool : IEnumerable
    {
        string[] sequence = {"a","b","c","d","e"};

        public IEnumerator GetEnumerator()
        {
            return new Iterator(sequence);
        }
    }

    /// <summary>
    /// Implementation of IEnumerator interface for use by SampleCollection_OldSchool's GetEnumerator
    /// </summary>
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
