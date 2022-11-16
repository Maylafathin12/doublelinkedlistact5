using System;

namespace doublelinkedlistact5
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
        public Node prev;
    }

    class doublelinkedlist
    {
        Node START; 
        public doublelinkedlist()
        {
            START = null;
        }
        public void addNode()
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of student");
            rollNo = Convert.ToInt32(Console.ReadLine());
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;


        }
    }
}
