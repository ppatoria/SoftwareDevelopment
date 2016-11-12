using System;
using System.Collections.Generic;
using System.Text;
//namespace AgoraConnection
//{
    public enum ConnectionType
    {
        GEN2,
        GEN3
    }

 
    public class Message
    {
        public string Key()
        {
            return "Name";
        }
        public string Value()
        {
            return "Value";
        }
    }

    public class AgoraConnection
    {
        private ConnectionType _connType;
        public string ConnType()
        {            
            if (_connType == ConnectionType.GEN2) {
                return ("New Connection for GEN2");
            }
            else if (_connType == ConnectionType.GEN3) {
                return ("New Connection for GEN3");
            }
            else {
                return "Nothing";
            }
        }
        public AgoraConnection()
        {            
            Console.WriteLine("New Connection");
        }

        public Message Send()
        {
            return new Message();
        }
        public string IsUp()
        {
            return "IsUp";
        }

        public AgoraConnection(ConnectionType connType)
        {
            _connType = connType;
            if(connType == ConnectionType.GEN2){
                Console.WriteLine("New Connection for GEN2");
                
            }
            else if(connType == ConnectionType.GEN3){
                Console.WriteLine("New Connection for GEN3");
            }
        }

        public string GetConnection(ConnectionType connType)
        {
            if (connType == ConnectionType.GEN2) {
                return ("New Connection for GEN2");
            }
            else if (connType == ConnectionType.GEN3) {
                return ("New Connection for GEN3");
            }
            else {
                return "Nothing";
            }
        }
    }

    public class Factory
    {
        public static AgoraConnection GetConnection()
        {
            return new AgoraConnection();
        }

        public static AgoraConnection GetConnection(ConnectionType connType)
        {
            return new AgoraConnection(connType);
        }
    }
//}
