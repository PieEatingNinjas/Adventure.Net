using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Adventure.Net
{
    public class Rooms
    {
        private static readonly List<Room> rooms = new List<Room>();

        public static void Load(IStory story)
        {
            rooms.Clear();
            Assembly ax = story.GetType().Assembly;
            rooms.AddRange(ax.SubclassOf<Room>());
            ax = Assembly.GetExecutingAssembly();
            rooms.AddRange(ax.SubclassOf<Room>());
        }

        public static IList<Room> All
        {
            get => rooms;
        }

        public static Room Get(Type type)
            => rooms.FirstOrDefault(r => r.GetType() == type);

        public static Room Get<T>() =>  Get(typeof (T));

        //Ignore casing?
        public static Room GetByName(string name)
            => rooms.Where(x => x.Name == name || x.Synonyms.Contains(name)).FirstOrDefault();

        //Ignore casing?
        public static IList<Room> WithName(string name)
            => rooms.Where(x => x.Name == name || x.Synonyms.Contains(name)).ToList();
    }
}
