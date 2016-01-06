using System;

namespace DI {
    internal class ConsoleFoo : IFoo {
        public void Hello( string message ) {
            Console.WriteLine( "Hello {0}", message );
        }
    }
}
