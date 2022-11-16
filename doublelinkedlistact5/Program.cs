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

            if (START == null || rollNo <= START.rollNumber);
            {
                if ((START != null) && (rollNo <= START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null && rollNo >= current.rollNumber; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null && rollNo != current.rollNumber; previous = current, current = current.next)
            { }
            return (current != null);
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\n List is Empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of" + "roll numbers are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "" + currentNode.name + "\n");
            }
        }
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("List Empty");
            else
            {
                Console.WriteLine("\nRecords in the descending order of" + "roll numbers are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + "" + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            doublelinkedlist obj = new doublelinkedlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Add a record to the list" +
                        "\n 2. Delete a record from the list" +
                        "\n 3. View all records in the ascending order of roll numbers" +
                        "\n 4. View all records in the descending order of roll numbers" +
                        "\n 5. Search for a record in the list" +
                        "\n 6. Exit\n" +
                        "\n Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Console.WriteLine("\n Enter the roll number of the student" + "whose" +
                                    "record id to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "delete \n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                obj.revtraverse();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Enter the roll number of the student whose record id to Search");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("Record not found");
                                else
                                {
                                    Console.WriteLine("\n Record found");
                                    Console.WriteLine("\n Roll number: " + curr.rollNumber);
                                    Console.WriteLine("\n Name: " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\n Invalid Option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Check for the values entered.");
                }
            }
        }
    }
}

