using System;

namespace Adventure.Net.Verbs
{
/*
Verb 'remove'
    * held                                      -> Disrobe
    * multi                                     -> Take
    * multiinside 'from' noun                   -> Remove;
*/

    public class Remove : Verb
    {
        public Remove()
        {
            Name = "remove";
            //Synonyms.Are("take", "carry", "hold");
            Grammars.Add(K.HELD_TOKEN, Disrobe);
            Grammars.Add(K.MULTI_TOKEN, Take);
        }

        private bool Disrobe() 
            => throw new NotImplementedException($"'{nameof(Disrobe)}' verb not implemented");

        private bool Take() =>  RedirectTo<Take>(K.MULTI_TOKEN);
    }
}

