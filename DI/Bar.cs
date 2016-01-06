namespace DI {
    public class Bar {
        IFoo m_foo;

        // --> Boom, injected
        public Bar( IFoo foo ) {
            m_foo = foo;
        }

        public void Example() {
            m_foo.Hello( "World" );
        }
    }
}
