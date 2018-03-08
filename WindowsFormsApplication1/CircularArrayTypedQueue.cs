﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CircularArrayTypedQueue : IQueue
    {
        private Kisi[] Queue;
        private int front = -1;
        private int rear = -1;
        private int size = 0;
        private int count = 0;
        public CircularArrayTypedQueue(int size)
        {
            this.size = size;
            Queue = new Kisi[size];
        }
        public void Insert(Kisi o)
        {
            if (count == size)
                throw new Exception("Queue dolu.");

            if (front == -1)
                front = 0;

            //Circular Code Değişikliği
            if (rear == size - 1)
            {
                rear = 0;
                Queue[rear] = o;
            }
            else
                Queue[++rear] = o;

            count++;
        }

        public Kisi Remove()
        {
            if (IsEmpty())
                throw new Exception("Queue boş.");

            Kisi temp = Queue[front];
            Queue[front] = null;

            //Circular Code Değişikliği
            if (front == size - 1)
                front = 0;
            else
                front++;

            count--;

            return temp;
        }

        public Kisi Peek()
        {
            return Queue[front];
        }

        public bool IsEmpty()
        {
            return (count == 0);
        }
    }
}
