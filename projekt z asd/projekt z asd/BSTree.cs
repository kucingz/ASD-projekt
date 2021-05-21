using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_z_asd
{
    class BSTree
    {
        public static int changeToDate(string value)
        {
            int infodata;
            string[] svalue = value.Split('-');
            infodata = (Convert.ToInt32(svalue[0]) * 100 + Convert.ToInt32(svalue[1])) * 100 + Convert.ToInt32(svalue[2]);
            return infodata;
        }

        public BSTreeNode root;

        //dodawanie do drzewka
        public bool Add(connectionData value)
        {
            BSTreeNode current = root;
            BSTreeNode previous = null;
            while (current != null)
            {
                previous = current;
                if (changeToDate(value.date) < changeToDate(current.data.date))
                { current = current.leftNode; }

                else if (changeToDate(value.date) > changeToDate(current.data.date))
                { current = current.rightNode; }

                else
                {
                    if (Convert.ToInt32(value.begid_station) < Convert.ToInt32(current.data.begid_station))
                    {
                        current = current.leftNode;
                    }

                    else if (Convert.ToInt32(value.begid_station) > Convert.ToInt32(current.data.begid_station))
                    {
                        current = current.rightNode;
                    }
                    else return false;
                }
            }
            BSTreeNode newNode = new BSTreeNode();
            newNode.data = value;
            //drzewo nie ma wartosci 
            if (root == null) root = newNode;
            else
            {
                if (changeToDate(value.date) < changeToDate(previous.data.date))
                { previous.leftNode = newNode; }
                else previous.rightNode = newNode;
            }
            return true;
        }
        public void Insert(connectionData value)
        {
            BSTreeNode newNode = new BSTreeNode();
            newNode.data = value;
            if (root == null) root = newNode;
            else
            {
                BSTreeNode current = root;
                BSTreeNode parent;
                while (1 == 1)
                {
                    parent = current;
                    if (changeToDate(value.date) < changeToDate(current.data.date))
                    {
                        current = current.leftNode;
                        if (current == null)
                        {
                            parent.leftNode = newNode; 
                            break;
                        }
                    }
                    parent = current;
                    if (changeToDate(value.date) > changeToDate(current.data.date))
                    {
                        current = current.rightNode;
                        if (current == null)
                        {
                            parent.rightNode = newNode;
                            break;
                        }
                    }
                    parent = current;
                    if (changeToDate(value.date) == changeToDate(current.data.date))
                    {

                        if (Convert.ToInt32(value.begid_station) > Convert.ToInt32(current.data.begid_station))
                        {
                            current = current.leftNode;
                            if (current == null)
                            {
                                parent.leftNode = newNode;
                                break;
                            }
                        }
                        else if(Convert.ToInt32(value.begid_station) < Convert.ToInt32(current.data.begid_station))
                        {
                            current = current.rightNode;
                            if (current == null)
                            {
                                parent.rightNode = newNode;
                                break;
                            }
                        }
                        else
                        {     
                            if (Convert.ToInt32(value.endid_station) < Convert.ToInt32(current.data.endid_station))
                            {
                                current = current.leftNode;
                                if (current == null)
                                {
                                    parent.leftNode = newNode;
                                    break;
                                }
                            }
                            else
                            {
                                current = current.rightNode;
                                if (current == null)
                                {
                                    parent.rightNode = newNode;
                                    break;
                                }
                            } 
                        }
                    }
                }
            }
        }

        public BSTreeNode Search(string date, string begid_station, string endid_station, BSTreeNode parent)
        {
            while (parent != null)
            {
                if(changeToDate(date) > changeToDate(parent.data.date))
                {
                    parent = parent.rightNode;
                }
                else if (changeToDate(date) < changeToDate(parent.data.date))
                {
                    parent = parent.leftNode;
                }
                else
                {
                    if (Convert.ToInt32(begid_station) > Convert.ToInt32(parent.data.begid_station))
                    {
                        parent = parent.leftNode;
                    }
                    else if (Convert.ToInt32(begid_station) < Convert.ToInt32(parent.data.begid_station))
                    {
                        parent = parent.rightNode;
                    }
                    else
                    {
                        if (Convert.ToInt32(endid_station) < Convert.ToInt32(parent.data.endid_station))
                        {
                            parent = parent.leftNode;
                        }
                        else if (Convert.ToInt32(endid_station) > Convert.ToInt32(parent.data.endid_station))
                        {
                            parent = parent.rightNode;
                        }
                        else
                        {
                            Console.WriteLine("TAK");
                            return parent;
                        }
                    }
                    
                }
            }
            Console.WriteLine("NIE");
            return null;
        }

        public BSTreeNode Search(string date, string begid_station, string endid_station)
        {
            return Search(date, begid_station, endid_station, root);
        }
        //

        BSTreeNode MinV(BSTreeNode root)
        {
            BSTreeNode min = root;
            while (root.leftNode != null)
            {
                min = root.leftNode;
                root = root.leftNode;

            }
            return min;
        }

        public BSTreeNode Remove(BSTreeNode parent, string date, string begid_station, string endid_station)
        {
            if (parent == null) return parent;

            if (changeToDate(date) < changeToDate(parent.data.date))
            { parent.leftNode = Remove(parent.leftNode, date, begid_station, endid_station); }

            if (changeToDate(date) > changeToDate(parent.data.date))
            { parent.rightNode = Remove(parent.rightNode, date, begid_station, endid_station); }

            if (date == parent.data.date)
            {
                if (Convert.ToInt32(begid_station) < parent.data.begid_station)
                { parent.rightNode = Remove(parent.rightNode, date, begid_station, endid_station); }

                else if (Convert.ToInt32(begid_station) > parent.data.begid_station)
                { parent.leftNode = Remove(parent.leftNode, date, begid_station, endid_station); }

                else 
                {
                    if (Convert.ToInt32(endid_station) > parent.data.endid_station)
                    { parent.rightNode = Remove(parent.rightNode, date, begid_station, endid_station); }

                    else if (Convert.ToInt32(endid_station) < parent.data.endid_station)
                    { parent.leftNode = Remove(parent.leftNode, date, begid_station, endid_station); }
                    
                    else 
                    {
                        if (parent.leftNode == null) return parent.rightNode;

                        else if (parent.rightNode == null) return parent.leftNode;
                        parent.data.date = MinV(parent.rightNode).data.date;
                        parent.data.begid_station = MinV(parent.rightNode).data.begid_station;
                        parent.data.endid_station = MinV(parent.rightNode).data.endid_station;
                        parent.rightNode = Remove(parent.rightNode, parent.data.date, Convert.ToString(parent.data.begid_station), Convert.ToString(parent.data.endid_station));
                    }
                }
            }

            return parent;
        }

        public void Remove(string date, int begid_station, int endid_station)
        {
            root = Remove(root, date, Convert.ToString(begid_station), Convert.ToString(endid_station));
        }
        //

        public int CountinRange(BSTreeNode parent, string date1, string date2)
        {
            if (parent == null) return 0; 

            else if (changeToDate(parent.data.date) >= changeToDate(date1) && changeToDate(parent.data.date) <= changeToDate(date2))
            { return 1 + CountinRange(parent.leftNode, date1, date2) + CountinRange(parent.rightNode, date1, date2); }

            else if (changeToDate(parent.data.date) > changeToDate(date1) && changeToDate(parent.data.date) > changeToDate(date2))
            { return CountinRange(parent.leftNode, date1, date2); }

            else
            { return CountinRange(parent.rightNode, date1, date2); }
        }

        public void CountinRange(string date1, string date2)
        {
            Console.WriteLine(CountinRange(root, date1, date2));
        }


        //
        public void Print()
        {
            root.PrintPretty("", NodePosition.center, true,false);
        }
    }
}
