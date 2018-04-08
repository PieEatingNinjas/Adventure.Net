using System.Collections.Generic;

namespace Adventure.Net
{
    public interface IStory
    {
        string Headline { get; }
        bool IsDone { get; set; }
        Room Location { get; set; }
        string Story { get; }
        
        void Initialize();
    }
}