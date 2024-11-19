using UnityEngine;

public class Params : MonoBehaviour
{
    
    public void PrintLines(params string[] lines)
    {
        foreach (string line in lines)
        {
            print(line);
        }
    }
    
    private void Start()
    {
        print("start");
        string[] str = SplitExtension.Split("absd qwerrt", ' ');
        foreach (string s in str)
        {
            print(s);
        }
    }
}
