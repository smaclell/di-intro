using System;
using System.Collections.Generic;

namespace DI {

    public interface ISimpleContainer {
        T Resolve<T>();

        void Register<T>( Func<T> factory );
    }

    public class SimpleContainer : ISimpleContainer {
        private readonly Dictionary<Type, Delegate> m_registrations = new Dictionary<Type, Delegate>();

        public T Resolve<T>() {
            Func<T> factory = (Func<T>)m_registrations[typeof( T )];
            return factory();
        }

        public void Register<T>( Func<T> factory ) {
            m_registrations.Add( typeof( T ), factory );
        }
    }

    public class SimpleContainerExample {
        public void Run() {

        }
    }
}
