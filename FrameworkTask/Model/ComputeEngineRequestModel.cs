using System.Reflection;

namespace FrameworkTask.Model
{
    public class ComputeEngineRequestModel
    {
        public string NumberOfInstances { get; set; }
        public string Os { get; set; }
        public string ProvisioningModel { get; set; }
        public string MachineSeries { get; set; }
        public string MachineType { get; set; }
        public bool HasAdditionalGpus { get; set; }
        public string GpuType { get; set; }
        public string GpuCount { get; set; }
        public string LocalSsds { get; set; }
        public string DatecenterLocation { get; set; }
        public string CommittedUsage { get; set; }

        public string GetDescription()
        {
            string output = new("");

            foreach (PropertyInfo info in GetType().GetProperties())
            {
                output += info.Name + ": " + info.GetValue(this).ToString() + Environment.NewLine;
            }

            return output;
        }
    }
}
