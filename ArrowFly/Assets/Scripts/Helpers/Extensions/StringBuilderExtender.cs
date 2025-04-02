using System.Text;

namespace Helpers.Extensions
{
    static class StringBuilderExtender
    {
        public static string CreateString(params string[] text)
        {
            StringBuilder stringBuilder = new StringBuilder(100);
            foreach (var item in text)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }
    }
}
