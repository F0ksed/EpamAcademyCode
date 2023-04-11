using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FrameworkTask.Model;

namespace FrameworkTask.Service
{
    internal class ComputerEngineRequestMaker
    {
        public ComputeEngineRequestModel GetModel()
        {
            return new ComputeEngineRequestModel();            
        }
    }
}
