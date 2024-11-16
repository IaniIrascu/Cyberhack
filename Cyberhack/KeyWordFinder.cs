using System.Security.Cryptography.Pkcs;

namespace Cyberhack;
using static Cyberhack.Form1;
public class KeyWordFinder
{
    private List<string> _keyWords = ["chrome", "settings", "setting", "background"];
    public Boolean FindSubstring(String input)
    {
        foreach (String keyWord in _keyWords)
        {
            if (input.Contains(keyWord))
            {
                return true;
            }
        }
        return false;
    }
}