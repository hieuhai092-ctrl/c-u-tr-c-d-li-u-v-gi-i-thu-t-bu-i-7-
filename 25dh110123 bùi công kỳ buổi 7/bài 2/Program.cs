using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bài_2
{
    class ArrayQueue
    {
        private int[] quArray;
        private int quMax;
        private int quFront;
        private int quRear;
        private int quCount;

        public ArrayQueue(int max = 0)
        {
            quMax = max;
            quArray = new int[max];
            quFront = 0;
            quRear = -1;
            quCount = 0;
        }

        public bool IsEmpty() => quCount == 0;
        public bool IsFull() => quCount == quMax;

        public bool EnQueue(int x)
        {
            if (IsFull()) return false;
            quRear = (quRear + 1) % quMax;
            quArray[quRear] = x;
            quCount++;
            return true;
        }

        public bool DeQueue(out int outItem)
        {
            if (IsEmpty()) { outItem = 0; return false; }
            outItem = quArray[quFront];
            quFront = (quFront + 1) % quMax;
            quCount--;
            return true;
        }

        public bool GetFront(out int frontItem)
        {
            if (IsEmpty()) { frontItem = 0; return false; }
            frontItem = quArray[quFront];
            return true;
        }

        public bool GetRear(out int rearItem)
        {
            if (IsEmpty()) { rearItem = 0; return false; }
            rearItem = quArray[quRear];
            return true;
        }
    }

    internal class Program
    {
        static void Input(ArrayQueue arrQueue)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập các số nguyên vào queue (Nhập số âm để dừng):");
            while (true)
            {
                Console.Write("Nhập giá trị: ");
                int x = int.Parse(Console.ReadLine());

                if (x < 0) break;

                if (!arrQueue.EnQueue(x))
                {
                    Console.WriteLine("Hàng đợi đã đầy!");
                    break;
                }
            }
        }
        static void Output(ArrayQueue arrQueue)
        {
            int frontVal, rearVal;
            if (arrQueue.GetFront(out frontVal))
                Console.WriteLine($"+ Phần tử ở đầu hàng đợi (Front): {frontVal}");

            if (arrQueue.GetRear(out rearVal))
                Console.WriteLine($"+ Phần tử ở cuối hàng đợi (Rear): {rearVal}");

            Console.WriteLine("\nĐang lấy các phần tử ra khỏi hàng đợi:");
            int item;
            while (!arrQueue.IsEmpty())
            {
                if (arrQueue.DeQueue(out item))
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
        static void TestArrayQueue()
        {
            ArrayQueue arrQueue = new ArrayQueue(3);
            Input(arrQueue);
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("Values in the queue:");
            Output(arrQueue);
        }

        static void Main(string[] args)
        {
            TestArrayQueue();
            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}