using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    //public delegate void ArrToFileDelegate(int[] array, string fileName);
    /* class SaveAsThread
     {
         private Thread thread;
         private ArrToFileDelegate threadStart;
         private int[] array;
         private string fileName;
         public SaveAsThread(ArrToFileDelegate threadStart, int[] array, string fileName)
         {

             this.threadStart = threadStart;
             this.array = array;
             this.fileName = fileName;
             thread = new Thread(new ThreadStart(ThreadMethod));
         }

         public void Start()
         {
             thread.Start();
         }
          private void ThreadMethod()
         {
             threadStart.Invoke(array, fileName);
         }
     }*/
    public class SaveAsThread
    {
        private int[] array;
        private string fileName;
        private Thread thread;
        public SaveAsThread(int[] array, string fileName)
        {
            this.array = array;
            this.fileName = fileName;

        }

        public void SaveToFile()
        {
            Stopwatch stopwatch = new Stopwatch();
            StreamWriter writer = new StreamWriter(fileName);
            stopwatch.Start();
            foreach (int item in array)
            {
                writer.Write(item + "; ");
            }
            stopwatch.Stop();
            writer.Close();
            Console.WriteLine($"масив було сбережено у файл: {fileName}");
            Console.WriteLine("час виконання: " + stopwatch.Elapsed);
        }
        public void Start()
        {
            if (thread == null || thread.ThreadState == System.Threading.ThreadState.Unstarted || thread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                thread = new Thread(SaveToFile);
                thread.Start();
            }
            else
            {
                Console.WriteLine("Потік вже запущено");
            }
        }
        public void Stop()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    thread.Interrupt();
                }
                else
                {
                    Console.WriteLine("Потік не запущено");
                }
            }
            else
            {
                Console.WriteLine("Потік не ініціалізовано");
            }
        }
    }
    public class InitializeArThread
    {
        private int[] array;
        private Thread thread;
        Random rand;
        public InitializeArThread(int[] array)
        {
            rand = new Random();
            this.array = array;
        }

        public void Init()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(10566);
            }
            stopwatch.Stop();
            Console.WriteLine("масив було ініціалізовано числами");
            Console.WriteLine("час виконання: " + stopwatch.Elapsed);

        }
        public void Start()
        {

            if (thread == null || thread.ThreadState == System.Threading.ThreadState.Unstarted || thread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                thread = new Thread(Init);
                thread.Start();
            }
            else
            {
                Console.WriteLine("Потік вже запущено");
            }
        }
        public void Stop()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    thread.Interrupt();
                }
                else
                {
                    Console.WriteLine("Потік не запущено");
                }
            }
            else
            {
                Console.WriteLine("Потік не ініціалізовано");
            }
        }
    }
}
