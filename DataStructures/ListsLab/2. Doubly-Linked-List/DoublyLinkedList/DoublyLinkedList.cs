using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode<T> Last { get; set; }
    }

    public int Count { get; private set; }

    private ListNode<T> head;

    private ListNode<T> tail;

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var prevHead = this.head;
            this.head = new ListNode<T>(element);
            this.head.Next = prevHead;
            prevHead.Last = this.head;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var lastTail = this.tail;
            this.tail.Next = new ListNode<T>(element);
            this.tail = this.tail.Next;
            this.tail.Last = lastTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("No such node!");
        }

        var value = this.head.Value;
        this.head = this.head.Next;
        if (this.head != null)
        {
            this.head.Last = null;
        }
        else
        {
            this.tail = null;
        }
        this.Count--;
        return value;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("No such node!");
        }

        var value = this.tail.Value;
        this.tail = this.tail.Last;
        if (this.tail != null)
        {
            this.tail.Next = null;
        }
        else
        {
            this.head = null;
        }
        this.Count--;
        return value;
    }

    public void ForEach(Action<T> action)
    {
        var iterator = this.GetEnumerator();
        while (iterator.MoveNext())
        {
            action(iterator.Current);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this.head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        int counter = 0;
        this.ForEach(x => array[counter++] = x);
        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
