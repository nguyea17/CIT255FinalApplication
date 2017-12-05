using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255FinalApplication
{
    class Program
    {/// <summary>
    /// To make this application works properly, I have used 
    /// some sample code provided by the instructor, Mr. John Velis
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            //add test data to the data file
            InitializeDataFileXML.AddTestData();

            //instantiate the controller
            Controller appController = new Controller();
        }
    }
}
