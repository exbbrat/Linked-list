using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list.Model
{/// <summary>
///   Двухсвязный    список
/// </summary>
/// <typeparam name="T"> Двухсвязный список</typeparam>
    public  class DuplexLinkedList <T>: IEnumerable<T>
    {/// <summary>
    ///  Голова Списка
    /// </summary>
        public DuplexItem <T> Head { get; set; }
       /// <summary>
       /// Хвост списка
       /// </summary>
        public DuplexItem<T> Tail { get; set; }
        /// <summary>
        /// Колличество элементов списка
        /// </summary>
        public int Count { get; set; }

        public DuplexLinkedList() {    }

        public DuplexLinkedList(T data)
        {
            var item = new DuplexItem<T>(data);

            Head = item;
            Tail = item;
            Count = 1;

        }
        public void Add(T data)
        {
            var item = new DuplexItem<T>(data);

            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }
            else
            {
                Tail.Next = item;
                item.Previous = Tail;
                Tail = item;
                Count++;
            }
            
            
        }

        public void Delete( T data)
        {
            
            var current = Head;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }
                    current = current.Next;

            }
        }
        /// <summary>
        /// Реверс двухсвязного списка
        /// </summary>
        /// <returns></returns>
        public DuplexLinkedList<T> Reverse()
        {
            var result = new DuplexLinkedList<T>();

            var current = Tail;

            while(current != null)
            {
                result.Add(current.Data);
                current = current.Previous;
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
