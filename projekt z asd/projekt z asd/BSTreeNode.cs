using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_z_asd
{
    public class BSTreeNode
    {
        public BSTreeNode leftNode;
        public BSTreeNode rightNode;
        public connectionData data;
        public int countlessval;
        private void PrintValue(string value, NodePosition nodePostion)
        {
            switch (nodePostion)
            {
                case NodePosition.left:
                    PrintLeftValue(value);
                    break;
                case NodePosition.right:
                    PrintRightValue(value);
                    break;
                case NodePosition.center:
                    Console.WriteLine(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void PrintLeftValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("L:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintRightValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty)
        {

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }
            var stringValue = empty ? "-" : data.date +" "+data.begid_station+" "+data.endid_station;
            PrintValue(stringValue, nodePosition);

            if (!empty && (this.leftNode != null || this.rightNode != null))
            {
                if (this.leftNode != null)
                    this.leftNode.PrintPretty(indent, NodePosition.left, false, false);
                else
                    PrintPretty(indent, NodePosition.left, false, true);

                if (this.rightNode != null)
                    this.rightNode.PrintPretty(indent, NodePosition.right, true, false);
                else
                    PrintPretty(indent, NodePosition.right, true, true);
            }
        }
    }
}
