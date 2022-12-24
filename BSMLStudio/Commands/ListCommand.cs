using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMLStudio.Commands
{
    public class ListCommand : ICommand
    {
        public string Name { get; set; } = "list";
        public string Description { get; set; } = "Lists all files currently in the BSMLStudio Environment.";
        public string Usage { get; set; } = "";
        public uint RequiredArgsCount { get; set; } = 0;

        public bool Execute(string[] args)
        {
            Console.WriteLine("Not yet finished!");

            return true;
        }
    }
}
