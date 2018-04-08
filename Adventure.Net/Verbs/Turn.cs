using System;

namespace Adventure.Net.Verbs
{
    public class Turn : Verb
    {
        public Turn()
        {
            Name = "turn";
            Synonyms.Are("turn", "rotate", "screw", "twist", "unscrew");
            Grammars.Add("<noun>", TurnObject);
            Grammars.Add("<noun> on", SwitchOnObject);
            Grammars.Add("<noun> off", SwitchOffObject);
            Grammars.Add("on <noun>", SwitchOnObject);
            Grammars.Add("off <noun>", SwitchOffObject);
        }

        private bool SwitchOnObject() => RedirectTo<SwitchOn>("on <noun>");
        
        private bool SwitchOffObject() => RedirectTo<SwitchOff>("off <noun>");
        
        private bool TurnObject() => throw new NotImplementedException($"'{nameof(TurnObject)}' is not implemented!");
    }
}
