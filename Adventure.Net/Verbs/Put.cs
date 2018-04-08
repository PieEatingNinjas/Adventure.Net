using System;

namespace Adventure.Net.Verbs
{
    public class Put : Verb
    {
        public Put()
        {
            Name = "put";
            Grammars.Add("<multi> [in,inside,into] <noun>", InsertObject);
            Grammars.Add("<multiheld> [on,onto] <noun>", PutOnObject);
            Grammars.Add("on <held>", WearObject);
            Grammars.Add("down <multiheld>", DropObject);
            Grammars.Add("<multiheld> down", DropObject);
        }

        private bool InsertObject() => RedirectTo<Insert>("<multi> in <noun>");
        
        private bool PutOnObject()
        {
            if (!Object.InInventory)
            {
                Print("You need to be holding {0} {1} before you can put it on top of something else.", Object.Article, Object.Name);
                return true;
            }
            throw new NotImplementedException($"'{nameof(PutOnObject)}' is not implemented");
        }

        private bool WearObject()
            => throw new Exception($"'{nameof(WearObject)}' is not implemented");

        private bool DropObject() => RedirectTo<Drop>("<multiheld>");
    }
}
