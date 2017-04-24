using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectNAPI.Core;
namespace ConnectNAPI.Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
           // ParseMessages parse = new ParseMessages();
           // parse.ParseData(Utility.Constants.Vital_Update_fileName);
            CreateMessage create = new CreateMessage();
            create.CreateData(Utility.Constants.Patient_details_fileName);
        }
    }
}
