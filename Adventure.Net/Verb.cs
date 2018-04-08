using Adventure.Net.Verbs;
using System.Linq;

namespace Adventure.Net
{
    public abstract class Verb : ContextObject
    {
        Synonyms _Synonyms;
        Grammars _Grammars;

        public string Name { get; protected set; }

        public Synonyms Synonyms => _Synonyms ?? (_Synonyms = new Synonyms());

        public Grammars Grammars => _Grammars ?? (_Grammars = new Grammars());

        public bool ImplicitTake { get; set; }

        public bool IsNull
            => this.GetType() == typeof(NullVerb);

        protected bool RedirectTo<T>(string format) where T : Verb, new()
        {
            bool result = false;
            var verb = new T();
            var g = verb.Grammars.SingleOrDefault(x => x.Format == format);

            if (g != null)
            {
                var command =
                    new Command
                        {
                            Object = Context.Object,
                            IndirectObject = Context.IndirectObject,
                            Verb = verb,
                            Action = g.Action
                        };

                result = Context.Parser.ExecuteCommand(command);
            }
            return result;
        }
    }
}