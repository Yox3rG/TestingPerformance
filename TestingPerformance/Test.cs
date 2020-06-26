using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestingPerformance
{
    abstract class Test
    {
        protected IEnumerable<TestData> collection;

        public abstract void Fill(int amount);
        public abstract void Clear();
        public abstract void Operation();
    }

    class QueueTest : Test
    {
        public QueueTest()
        {
            collection = (IEnumerable<TestData>)new Queue<TestData>();
        }

        public override void Fill(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                ((Queue<TestData>)collection).Enqueue(new TestData());
            }
        }

        // Done manually on purpose.
        public override void Clear()
        {
            while (((Queue<TestData>)collection).Count > 0)
            {
                ((Queue<TestData>)collection).Dequeue();
            }
        }

        public override void Operation()
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TestData data = ((Queue<TestData>)collection).Dequeue();
                    ((Queue<TestData>)collection).Enqueue(data);
                }
            }
        }
    }

    class StackTest : Test
    {
        public StackTest()
        {
            collection = (IEnumerable<TestData>)new Stack<TestData>();
        }

        public override void Fill(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                ((Stack<TestData>)collection).Push(new TestData());
            }
        }

        // Done manually on purpose.
        public override void Clear()
        {
            while (((Stack<TestData>)collection).Count > 0)
            {
                ((Stack<TestData>)collection).Pop();
            }
        }

        public override void Operation()
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TestData data = ((Stack<TestData>)collection).Pop();
                    ((Stack<TestData>)collection).Push(data);
                }
            }
        }
    }

    internal class TestData
    {
        public static int nextID = 0;

        public string name;
        public int id;

        public TestData()
        {
            id = nextID++;
            name = "something " + id.ToString();
        }
    }
}
