namespace MetodosExtension
{
    public static class ExtentionsMethods
    {
        public static string ValidateNullOrEmpty(this string cadena)
        {
            return string.IsNullOrEmpty(cadena) ? "0" : cadena;
        }
    }
}
