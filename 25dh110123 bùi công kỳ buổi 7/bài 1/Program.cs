using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bài_1
{
    class ArrayQueue
    {
        private int[] quArray;     
        private int quMax;         
        private int quFront;       
        private int quRear;        
        private int quCount;       

        public int[] QuArray { get => quArray; set => quArray = value; }
        public int QuMax { get => quMax; set => quMax = value; }
        public int QuFront { get => quFront; set => quFront = value; }
        public int QuRear { get => quRear; set => quRear = value; }
        public int QuCount { get => quCount; set => quCount = value; }

        public ArrayQueue(int max = 0)
        {
            quMax = max;
            quArray = new int[max];
            quFront = 0;
            quRear = -1;
            quCount = 0;
        }

        public bool IsEmpty()
        {
            return quCount == 0;
        }

        public bool IsFull()
        {
            return quCount == quMax;
        }

        public bool EnQueue(int x)
        {
            if (IsFull())
            {
                return false; 
            }
            quRear = (quRear + 1) % quMax;
            quArray[quRear] = x;
            quCount++;
            return true;
        }

        public bool DeQueue(out int outItem)
        {
            if (IsEmpty())
            {
                outItem = 0;
                return false; 
            }
            outItem = quArray[quFront];
            quFront = (quFront + 1) % quMax;
            quCount--;
            return true;
        }

        public bool GetFront(out int frontItem)
        {
            if (IsEmpty())
            {
                frontItem = 0;
                return false;
            }
            frontItem = quArray[quFront];
            return true;
        }
        public bool GetRear(out int rearItem)
        {
            if (IsEmpty())
            {
                rearItem = 0;
                return false;
            }
            rearItem = quArray[quRear];
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ArrayQueue queue = new ArrayQueue(5);

            Console.WriteLine("--- KIỂM TRA HÀNG ĐỢT (ARRAY QUEUE) ---");
            Console.WriteLine("Is Empty? " + queue.IsEmpty()); 
            queue.EnQueue(10);
            queue.EnQueue(20);
            queue.EnQueue(30);

            int item;
            if (queue.DeQueue(out item))
            {
                Console.WriteLine("DeQueued (Lấy ra): " + item); 
            }
            if (queue.GetFront(out item))
            {
                Console.WriteLine("Front item (Đầu queue): " + item); 
            }

            if (queue.GetRear(out item))
            {
                Console.WriteLine("Rear item (Cuối queue): " + item); 
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}