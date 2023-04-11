namespace FrameworkTask.Model
{
    internal class ComputeEngineRequestModel
    {
        public string NumberOfInstances { get; set; } = "4";
        public string Os { get; set; } = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)";
        public string ProvisioningModel { get; set; } = "Regular";
        public string MachineSeries { get; set; } = "N1";
        public string MachineType { get; set; } = "n1-standard-8 (vCPUs: 8, RAM: 30GB)";
        public bool HasAdditionalGpus { get; set; } = true;
        public string GpuType { get; set; } = "NVIDIA Tesla P100"; //V100 isn't available for Frankfurt location
        public string GpuCount { get; set; } = "1";
        public string LocalSsds { get; set; } = "2x375 GB";
        public string DatecenterLocation { get; set; } = "Frankfurt (europe-west3)";
        public string CommittedUsage { get; set; } = "1 Year";
    }
}
