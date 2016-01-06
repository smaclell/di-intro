namespace DI {
    public class FooFactory {
        public IFoo Create() {
            return new ConsoleFoo();
        }
    }
}
