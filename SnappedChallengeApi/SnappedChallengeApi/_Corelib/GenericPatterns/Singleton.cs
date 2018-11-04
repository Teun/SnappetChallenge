namespace SnappedChallengeApi._Corelib.GenericPatterns
{
    public abstract class Singleton<instanceType> where instanceType : new()
    {
        private static readonly instanceType fInstance = new instanceType();

        static Singleton() { }

        public static instanceType Instance()
        {
            return fInstance;
        }
    }
}
