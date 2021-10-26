using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace GeneralizedRockPaperScissors
{
    class Table
    {
        List<string> Names;
        public Table(List<string> names)
        {
            Names = names;
        }

        public void Print()
        {
            var headerItems = Names.Prepend("PC \\ User");
            var table = new ConsoleTable(headerItems.ToArray());

            var judge = new Judge(Names.Count);

            for (int i = 0; i < Names.Count; i++)
            {
                var currentRow = new List<string>();
                currentRow.Add(Names[i]);
            
                for (int j = 0; j < Names.Count; j++)
                {
                    currentRow.Add(Enum.GetName(typeof(Outcome), judge.Decide(i, j)));
                }

                table.AddRow(currentRow.ToArray());
            }

            table.Write(Format.Alternative);
        }
    }
}
