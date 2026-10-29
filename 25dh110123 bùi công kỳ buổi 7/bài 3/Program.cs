using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bài_3
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int val)
        {
            data = val;
            next = null;
        }
    }
    class ListQueue
    {
        private Node front; 
        private Node rear;  

        public ListQueue()
        {
            front = null;
            rear = null;
        }
        public bool IsEmpty()
        {
            return front == null;
        }
        public bool IsFull()
        {
            return false;
        }
        public bool EnQueue(int x)
        {
            Node newNode = new Node(x);
            if (IsEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
            return true;
        }

       
        public bool DeQueue(out int outItem)
        {
            if (IsEmpty())
            {
                outItem = 0;
                return false; 
            }

            outItem = front.data;
            front = front.next;

            if (front == null) 
            {
                rear = null;
            }
            return true;
        }
        public bool GetFront(out int frontItem)
        {
            if (IsEmpty())
            {
                frontItem = 0;
                return false;
            }
            frontItem = front.data;
            return true;
        }
        public bool GetRear(out int rearItem)
        {
            if (IsEmpty())
            {
                rearItem = 0;
                return false;
            }
            rearItem = rear.data;
            return true;
        }
    }

    internal class Program
    {
        static void Input(ListQueue listQueue)
        {
            Console.WriteLine("Nhập các số nguyên vào ListQueue (Nhập số âm để dừng):");
            while (true)
            {
                Console.Write("Nhập giá trị: ");
                int x = int.Parse(Console.ReadLine());

                if (x < 0)
                {
                    break; 
                }
                listQueue.EnQueue(x);
            }
        }
        static void Output(ListQueue listQueue)
        {
            int frontVal, rearVal;
            if (listQueue.GetFront(out frontVal))
            {
                Console.WriteLine($"+ Phần tử ở đầu hàng đợi (Front): {frontVal}");
            }
            if (listQueue.GetRear(out rearVal))
            {
                Console.WriteLine($"+ Phần tử ở cuối hàng đợi (Rear): {rearVal}");
            }

            Console.WriteLine("\nĐang lấy các phần tử ra khỏi hàng đợi:");
            int item;
            while (!listQueue.IsEmpty())
            {
                if (listQueue.DeQueue(out item))
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
        static void TestListQueue()
        {
            ListQueue listQueue = new ListQueue();
            Input(listQueue);
            Console.WriteLine("\n- --");
            Console.WriteLine("Values in the queue:");
            Output(listQueue);
        }

        static void Main(string[] args)
        {
      
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TestListQueue();

            Console.WriteLine("\nNhấn phím bất kỳ để thoát..");
            Console.ReadKey();
        }
    }
}