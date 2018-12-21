namespace DI_2_AutofacImplementation.DependencySample
{
    public class StringServices : IStringServices
    {
        public string SetPrefix(string text, string prefix)
        {
            return string.Format("{0}_{1}", prefix, text);
        }
    }

}
