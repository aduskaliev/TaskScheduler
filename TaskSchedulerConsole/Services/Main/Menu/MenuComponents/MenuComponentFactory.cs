using System;
using System.Collections.Generic;
using System.Text;


namespace TaskSchedulerConsole.Services.Main.Menu
{
    internal class MenuComponentFactory
    {
        public static IMenuComponent Create(string str)
        {
            return new MenuComponent(str);
        }

        public static IMenuComponent CreateFromList(
            List<string> strList, 
            string separator = "\n"
            )
        {
            StringBuilder builder = new StringBuilder();

            foreach (string el in strList)
            {
                builder
                    .Append(el)
                    .Append(separator);
            }

            return new MenuComponent(builder.ToString());
        }

        public static IMenuComponent CreateFromListMarked(
            List<string> strList, 
            string marker = "->", 
            string separator = "\n"
            )
        {
            StringBuilder builder = new StringBuilder();

            foreach (string el in strList)
            {
                builder
                    .Append(marker)
                    .Append(el)
                    .Append(separator);
            }

            return new MenuComponent(builder.ToString());
        }
        public static IMenuComponent CreatetFromListIndexed(
            List<string> strList, 
            string marker = ". ", 
            string separator = "\n"
            )
        {
            int counter = 1;
            StringBuilder builder = new StringBuilder();

            foreach (string el in strList)
            {
                builder.Append(counter);
                ++counter;
                builder
                    .Append(marker)
                    .Append(el)
                    .Append(separator);
            }

            return new MenuComponent(builder.ToString());
        }

        public static IMenuComponent CreateFromDictionary<DataType>(
            Dictionary<DataType, string> dict, 
            bool indexed = true, 
            string marker = ". ", 
            string separator = "\n"
            )
            where DataType : IFormattable
        {
            StringBuilder builder = new StringBuilder();
            foreach (var el in dict)
            {
                builder
                    .Append(el.Key.ToString())
                    .Append(marker)
                    .Append(el.Value)
                    .Append(separator);
            }

            return new MenuComponent(builder.ToString());
        }
        /*
        public static IMenuComponent CreateFromDictionary<KeyType, ValueType>(
            Dictionary<KeyType, ValueType> dict,
            bool indexed = true,
            string marker = ". ",
            string separator = "\n"
            )
            where KeyType : IFormattable
            where ValueType : IToStringCollection
        {
            StringBuilder builder = new StringBuilder();
            foreach (var el in dict)
            {
                var strValue = ((IFormattable)el.Value).ToString("\t");
 
                builder
                    .Append(el.Key.ToString())
                    .Append(marker)
                    .Append()
                    .Append(separator);
            }

            return new MenuComponent(builder.ToString());
        }
        */
    }
}
