using System;
using System.Collections.Generic;
using System.Linq;

namespace bars4
{
    class Program
    {
        //eto uzhas polniy)))
        public class lger : ILoger
        {
            private readonly string typemessage;
            public lger(string name)
            {
                typemessage = typeof(string).Name;
            }

            public void LogInfo(string message) =>
                Console.WriteLine($"[Ifo]:{typemessage} :{message}");
            public void LogWarning(string message) =>
                Console.WriteLine($"[Warning]:{typemessage}:{message}");
            public void LogError(string message, Exception ex) =>
                Console.WriteLine($"[Error]:{typemessage}:{message}.{ex.Message}");

        }   

        public interface ILoger
        {
            public void LogInfo(string message) => Loger.GetLog(this.GetType().Name).LogInfo(message);


            public void LogWarning(string message) => Loger.GetLog(this.GetType().Name).LogWarning(message);

            public void LogError(string message, Exception ex) => Loger.GetLog(this.GetType().Name).LogError(message, ex);

        }

        //public class LocalFileLogger<T>
        //{

        //}

        public class LocalFileLogger : ILoger
        {
            public void LLogInfo(string message)
            {
                ((ILoger)this).LogInfo(message);
            }
            public void LLogWarning(string message)
            {
                ((ILoger)this).LogWarning(message);
            }
            public void LLogError(string message, Exception ex)
            {
                ((ILoger)this).LogError(message, ex);
            }
        }


        public static class Loger
        {
            public static ILoger GetLog(string name) => new lger(name);
        }

        public void Write()
        {
            LocalFileLogger localfilelogger = new LocalFileLogger(); 
            DivideByZeroException exMessage = new DivideByZeroException();
            string message = "Message";
            localfilelogger.LLogInfo(message);
            localfilelogger.LLogWarning(message);
            localfilelogger.LLogError(message, exMessage);
        }


      static void Main(string[] args)
        {
            new Program().Write();
           
           

          
        }
    }

    }



