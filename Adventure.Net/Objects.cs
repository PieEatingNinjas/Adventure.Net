using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Adventure.Net
{
    public class Objects
    {
        private static readonly IList<Object> objects = new List<Object>();

        public static void Load(IStory story)
        {
            objects.Clear();

            Assembly ax = story.GetType().Assembly;
            Type[] types = ax.GetTypes();

            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof (Object)) && !type.IsAbstract && !type.IsSubclassOf(typeof (Room)))
                {
                    if (Activator.CreateInstance(type) is Object obj)
                        objects.Add(obj);
                }
            }
        }

        public static IList<Object> All
        {
            get => objects;
        }

        public static Object GetByName(string name)
            => objects.SingleOrDefault(x => x.Name == name || x.Synonyms.Contains(name));

        public static IList<Object> WithName(string name)
            => objects.Where(x => x.Name == name || x.Synonyms.Contains(name)).ToList();

        public static T Get<T>() where T:Object
            => Get(typeof (T)) as T;

        public static Object Get(Type objectType)
            => objects.FirstOrDefault(o => o.GetType() == objectType);

        public static IList<Object> WithRunningDaemons()
            => objects.Where(x => x.Daemon != null && x.DaemonStarted == true).ToList();

        public static void Add(Object obj) => objects.Add(obj);
    }
}
