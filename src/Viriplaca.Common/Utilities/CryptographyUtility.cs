using System.Security.Cryptography;
using System.Text;
using Viriplaca.Common.Extensions;

namespace Viriplaca.Common.Utilities;

public static class CryptographyUtility
{
    public static string SHA256Hash(string input, string salt)
    {
        var bytes = Encoding.UTF8.GetBytes(input + salt);

        return SHA256.HashData(bytes).ToBase64String();
    }
}
