using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YodleTest
{
    public class MissingLetters
    {
        readonly char[] Alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        public string GetMissingLetters(string sentence)
        {
            var observedLetters = Alpha.ToDictionary(l => l, l=> false); //init map with all letters
            var numObserved = 0;
            
            foreach (var letter in sentence)
            {
                var lower = Char.ToLower(letter);
                bool hasBeenObserved;
                if (observedLetters.TryGetValue(lower, out hasBeenObserved))
                {
                    numObserved = !hasBeenObserved ? numObserved + 1: numObserved;  //increment count only if it hasn't been observed before
                    observedLetters[lower] = true;
                    if (numObserved == 26) return ""; //short-circuit the search if all letters have been seen
                }

            }
            return String.Join("", observedLetters.Keys.Where(k => !observedLetters[k]).ToArray());
        }
    }
}
