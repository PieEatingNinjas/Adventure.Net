using System.Collections.Generic;
using System.Linq;

namespace Adventure.Net
{
    public class Synonyms : List<string>
    {
        public void Are(params string[] values) 
            => AddRange(values);

        public void Are(string commaSeparatedList) 
            => AddRange(commaSeparatedList.Split(',').Select(s => s.Trim()));
    }
}