using System;
using System.Collections.Generic;

using Autofac;

namespace DI {
    class Program {
        static void Main( string[] args ) {
            string command = "autofac";
            if( args.Length > 0 ) {
                command = args[0].ToLower();
            }

            switch (command) {
                case "autofac":
                    ShowAutofac();
                    break;

                case "simple":
                    ShowSimpleContainer();
                    break;

                case "factory":
                    ShowFactory();
                    break;

		        default:
                    ShowHelp();
                    break;
	        }
        }

        static void ShowAutofac() {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ConsoleFoo>().As<IFoo>();
            builder.RegisterType<Bar>().AsSelf();

            IContainer container = builder.Build();

            Bar bar = container.Resolve<Bar>();

            bar.Example();
        }

        static void ShowSimpleContainer() {
            SimpleContainer container = new SimpleContainer();

            container.Register<IFoo>( () => new ConsoleFoo() );
            container.Register<Bar>(
                () => {
                    IFoo foo = container.Resolve<IFoo>();
                    return new Bar( foo );
                }
            );

            Bar bar = container.Resolve<Bar>();

            bar.Example();
        }

        static void ShowFactory() {
            FooFactory factory = new FooFactory();
            IFoo foo = factory.Create();

            Bar bar = new Bar( foo );

            bar.Example();
        }

        static void ShowHelp() {
            Console.WriteLine( @"
DI - a dependency injection demo

    DI
    DI autofac

    * Run a demo using the Dependency Injection Container, Autofac.

    DI factory

    * Runs a demo using a basic factory.

    DI simple

    * Runs a demo using the poor man's dependency injection container.
" );
        }
    }
}
