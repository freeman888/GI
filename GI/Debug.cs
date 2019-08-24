using System;

namespace GI
{
    public static class Gdebug
    {
        public static Func<string,bool> toShow;
        public static void WriteLine(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
        public static void ThrowWrong(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
            toShow?.Invoke(msg);
        }
    }
}
