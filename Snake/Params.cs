using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Snake
{
    public class Params
    {
        private string ResorcesFolder; //!!!!!!!!//
        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString().IndexOf("bin", StringComparison.Ordinal);
            string binFolder = Directory.GetCurrentDirectory().ToString().Substring(0, ind).ToString();
            ResorcesFolder = binFolder + "resources\\";
        }
        public string GetResourceFolder()
        {
            return ResorcesFolder;
        }

    }
}
