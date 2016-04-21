using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedLib
{
    [ServiceContract(CallbackContract = typeof(mycallback), SessionMode =SessionMode.Required)]
    public interface IChat
    {
        [OperationContract]
        bool Subscribe(string Name);

        [OperationContract]
        bool UnSubscribe();
        
        [OperationContract]
        void create_private_room(People man, string name_of_room);

        [OperationContract]
        void add_usver_to_private_room(string usver_name, string room);

        [OperationContract]
        void send_private_message(Message new_message, string private_room);

        [OperationContract]
        void craete_new_man(string name);

        [OperationContract]
        void SendMessage(Message message);
    }

    [ServiceContract]
    public interface mycallback
    {
        [OperationContract(IsOneWay =true)]
        void on_new_message(string new_message);

        [OperationContract(IsOneWay = true)]
        void on_new_usver(string Usver_name);
        
        [OperationContract(IsOneWay = true)]
        void on_create_new_room(string new_room);
    }


    [DataContract(Name="people")]
    public class People
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public mycallback callback;
        [DataMember]
        public List<string> Rooms = new List<string>();
    }

    [DataContract(Name ="Message")]
    public class Message
    {
        [DataMember]
        public string CurrentUser { get; set; }
        [DataMember]
        public string UserMessage { get; set; }
    }

}
