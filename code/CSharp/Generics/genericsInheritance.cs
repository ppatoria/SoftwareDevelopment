using System;

public class ProgramOne
{
    internal sealed class 
    Node<T> {
        public 
        T m_data;
        
        public 
        Node<T> m_next;

        public 
        Node(T data) : this(data, null) 
        { }

        public 
        Node(T data, Node<T> next) {
            m_data = data; m_next = next;
        }

        public override 
        String ToString() {
            return 
                m_data.ToString() + 
                ((m_next != null) ? m_next.ToString() : String.Empty);
        }
    }

    private static void 
    SameDataLinkedList() {
        Node<Char> head = new Node<Char>('C');
        head = new Node<Char>('B', head);
        head = new Node<Char>('A', head);
        Console.WriteLine(head.ToString());  // Displays "ABC"
    }

    public static void
    Main(){
        SameDataLinkedList();
    }
}

public class ProgramTwo
{
    internal class 
    Node {
        protected 
        Node m_next;
        
        public 
        Node(Node next) {
            m_next = next;
        }
    }   

    internal sealed class 
    TypedNode<T> : Node {
        public 
        T m_data;
    
        public 
        TypedNode(T data) : this(data, null) { }

        public 
        TypedNode(T data, Node next) : base(next) {
            m_data = data;
        }
    
        public override String 
        ToString() {
            return m_data.ToString() +
                ((m_next != null) ? m_next.ToString() : String.Empty);
        }
    }    
 
    private static void 
    DifferentDataLinkedList() {
        Node head = new TypedNode<Char>('.');
        head = new TypedNode<DateTime>(DateTime.Now, head);
        head = new TypedNode<String>("Today is ", head);
        Console.WriteLine(head.ToString());
    }
}