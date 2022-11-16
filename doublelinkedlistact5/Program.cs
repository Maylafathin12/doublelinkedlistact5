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
    }
}
