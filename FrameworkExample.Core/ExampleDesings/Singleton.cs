// double-check locked Singleton Design
namespace FrameworkExample.Core.ExampleDesings
{
    public class Singleton
    {
        private static readonly object _myLock = new object();
        private static Singleton _mySingleton = null;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (_mySingleton is null)
            {
                lock (_myLock)
                {
                    if (_mySingleton is null)
                    {
                        _mySingleton = new Singleton();
                    }
                }
            }

            return _mySingleton;
        }
    }
}
