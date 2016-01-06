using System.IO;

namespace DI {
    internal class FileFoo : IFoo {
        public void Hello( string message ) {
            File.AppendAllText( "C:\\foo.txt", "Hola " + message );
        }
    }
}
