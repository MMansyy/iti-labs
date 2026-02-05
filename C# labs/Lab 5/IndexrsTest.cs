using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    internal class IndexrsTest
    {
        private List<string> items = new List<string>();
        private Dictionary<string, string> map = new Dictionary<string, string>();

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Count)
                    return items[index];
                else
                    return null;
            }
            set
            {
                if (index >= items.Count)
                    items.Add(value);
                else if (index >= 0)
                    items[index] = value;
            }
        }

        public string this[string key]
        {
            get
            {
                if (map.ContainsKey(key))
                    return map[key];
                else
                    return null;
            }
            set
            {
                map[key] = value;
            }
        }
    }

}
