using System.Security.Cryptography.Pkcs;

namespace Cyberhack;
using static Cyberhack.Form1;
public class KeyWordFinder
{
    private List<string> _keyWords = ["whatsapp", "instagram", "chrome", "settings", "background", "word", "excel", "powerpoint", "gallery", "brightness", "files", "pictures", "documents"];
    public String FindSubstring(String input)
    {
        foreach (String keyWord in _keyWords)
        {
            if (input.Contains(keyWord))
            {
                return keyWord;
            }
        }
        return null;
    }
}