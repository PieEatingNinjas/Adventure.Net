using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Adventure.Net
{
    public static class VerbList 
    {
        private static readonly List<Verb> verbs;

        static VerbList()
        {
            verbs = new List<Verb>();

            void add(IEnumerable<Type> list)
            {
                foreach (var type in list)
                {
                    if (type.IsSubclassOf(typeof(Verb)) && !type.IsAbstract)
                        verbs.Add(Activator.CreateInstance(type) as Verb);
                }
            }

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            add(types);

            var storyType = Context.Story.GetType();
            types = Assembly.GetAssembly(storyType).GetTypes();
            add(types);
        }

        public static IList<Verb> List => verbs;

        public static Verb GetVerbByName(string name)
            => List.Where(x => x.Name == name || x.Synonyms.Contains(name)).FirstOrDefault();

        public static IList<Verb> GetVerbsByName(string name)
            => List.Where(x => x.Name == name || x.Synonyms.Contains(name)).ToList();
    }
}