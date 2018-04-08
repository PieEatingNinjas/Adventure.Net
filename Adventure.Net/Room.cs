using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure.Net
{
    public abstract class Room : Object
    {
        protected Room() 
        {
            Objects = new List<Object>();
            DarkToDark = () => Print("It's pitch black, and you can't see a thing.");
            CantGo = "You can't go that way.";
            Visited = false;
        }

        public IList<Object> Objects { get; private set;}

        public string CantGo { get; protected set; }

        public Action DarkToDark { get; protected set; }

        /// <summary>
        /// Called the first time a player enters the room
        /// </summary>
        public Action Initial { get; protected set; }

        /// <summary>
        /// Visited
        /// </summary>
        public bool Visited { get; set; }
        
        private readonly Dictionary<string, Func<Room>> roomMap = new Dictionary<string, Func<Room>>();

        private void AddToRoomMap<T>(string direction) where T:Room
        {
            Room room = Rooms.Get<T>();
            if (room != null)
                roomMap.Add(direction, () => room);
        }

        public void NorthTo<T>() where T : Room => AddToRoomMap<T>("n");

        public void NorthTo(Func<Room> getRoom) => roomMap.Add("n", getRoom);

        public Room N() => TryMove("n");

        public void SouthTo<T>() where T : Room =>AddToRoomMap<T>("s");

        public void SouthTo(Func<Room> getRoom) => roomMap.Add("s", getRoom);

        public Room S() => TryMove("s");
        
        public void EastTo<T>() where T: Room => AddToRoomMap<T>("e");

        public void EastTo(Func<Room> getRoom) => roomMap.Add("e", getRoom);

        public Room E() => TryMove("e");

        public void WestTo<T>() where T : Room => AddToRoomMap<T>("w");

        public void WestTo(Func<Room> getRoom) => roomMap.Add("w", getRoom);

        public Room W() => TryMove("w");

        public void NorthWestTo<T>() where T : Room => AddToRoomMap<T>("nw");

        public void NorthWestTo(Func<Room> getRoom) => roomMap.Add("nw", getRoom);

        public Room NW() => TryMove("nw");

        public void NorthEastTo<T>() where T : Room => AddToRoomMap<T>("ne");

        public void NorthEastTo(Func<Room> getRoom) => roomMap.Add("ne", getRoom);

        public Room NE() => TryMove("ne");

        public void SouthWestTo<T>() where T : Room => AddToRoomMap<T>("sw");
        
        public void SouthWestTo(Func<Room> getRoom) => roomMap.Add("sw", getRoom);

        public Room SW() => TryMove("sw");

        public void SouthEastTo<T>() where T : Room => AddToRoomMap<T>("se");

        public void SouthEastTo(Func<Room> getRoom) => roomMap.Add("se", getRoom);

        public Room SE() => TryMove("se");

        public void InTo<T>() where T : Room => AddToRoomMap<T>("in");

        public void InTo(Func<Room> getRoom) => roomMap.Add("in", getRoom);

        public Room IN() => TryMove("in");

        public void OutTo<T>() where T : Room => AddToRoomMap<T>("out");

        public void OutTo(Func<Room> getRoom) => roomMap.Add("out", getRoom);

        public Room OUT() => TryMove("out");

        public void UpTo<T>() where T : Room => AddToRoomMap<T>("up");

        public void UpTo(Func<Room> getRoom) => roomMap.Add("up", getRoom);

        public Room UP() => TryMove("up");

        public void DownTo<T>() where T : Room => AddToRoomMap<T>("down");

        public void DownTo(Func<Room> getRoom) => roomMap.Add("down", getRoom);

        public Room DOWN() => TryMove("down");
        
        protected virtual Room HandleMove() => this;    

        protected virtual Room TryMove(string dir)
        {
            if (!roomMap.ContainsKey(dir))
                return null;

            var getRoom = roomMap[dir];

            return getRoom()?.HandleMove() ?? this;
        }

        public void Has<T>() where T : Object
        {
            Object obj = Net.Objects.Get<T>();
            if (obj == null)
                obj = Net.Rooms.Get<T>();

            obj.Parent = this;
            Objects.Add(obj);
        }

        public bool Contains<T>() where T : Object => Objects.Any(o => o is T);

        public bool Contains(Object obj) => Objects.Contains(obj);

        public T Get<T>() where T:Object =>  Objects.FirstOrDefault(o => o is T) as T ?? default(T);
    }
}