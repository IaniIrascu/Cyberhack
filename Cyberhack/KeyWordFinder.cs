using System.Security.Cryptography.Pkcs;

namespace Cyberhack;
using static Cyberhack.Form1;
public class KeyWordFinder
{
    public string FindSubstring(string input, List<string> keyWords)
    {
        foreach (string keyWord in keyWords)
        {
            if (input.Contains(keyWord))
            {
                return keyWord;
            }
        }
        return null;
    }
    
}