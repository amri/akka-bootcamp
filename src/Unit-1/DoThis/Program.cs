using System;
﻿using Akka.Actor;

namespace WinTail
{
    #region Program
    class Program
    {
        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            MyActorSystem = ActorSystem.Create("MyActorSystem");

            var consoleWriterProps = Props.Create(() => new ConsoleWriterActor());
            IActorRef consoleWriterActor = MyActorSystem.ActorOf(consoleWriterProps,"ConsoleWriterActor");
            var validatorProps = Props.Create(() => new ValidationActor(consoleWriterActor));
            IActorRef validatorActor = MyActorSystem.ActorOf(validatorProps,"ValidatorActor");
            var consoleReaderProps = Props.Create(() => new ConsoleReaderActor(validatorActor));
            IActorRef consoleReaderActor = MyActorSystem.ActorOf(consoleReaderProps,"ConsoleReaderActor");

            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);
            MyActorSystem.AwaitTermination();
        }
        
    }
    #endregion
}
