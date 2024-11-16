using System.Security.Cryptography.Pkcs;

namespace Cyberhack;
using static Cyberhack.Form1;
public class KeyWordFinder
{
    public String FindSubstring(String input, List<String> keyWords)
    {
        foreach (String keyWord in keyWords)
        {
            if (input.Contains(keyWord))
            {
                return keyWord;
            }
        }
        return null;
    }
    
}