namespace DevelopmentAndBuildToolsTask
{
    internal interface IComparer
    {
        public void CompareAndAddResult(char first, char second);
        public int GetCurrentResult();
    }
}
