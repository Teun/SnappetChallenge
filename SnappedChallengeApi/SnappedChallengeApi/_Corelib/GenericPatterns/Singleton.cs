namespace SnappedChallengeApi._Corelib.GenericPatterns
{
    /// <summary>
    /// Generic singleton pattern implementation needed for rest client for the ui
    /// </summary>
    /// <typeparam name="instanceType"></typeparam>
    public abstract class Singleton<instanceType> where instanceType : new()
    {
        /// <summary>
        /// Generic static instance
        /// </summary>
        private static readonly instanceType fInstance = new instanceType();

        /// <summary>
        /// static constructor
        /// </summary>
        static Singleton() { }

        /// <summary>
        /// Generic Instance Provider Method
        /// </summary>
        /// <returns></returns>
        public static instanceType Instance()
        {
            return fInstance;
        }
    }
}
