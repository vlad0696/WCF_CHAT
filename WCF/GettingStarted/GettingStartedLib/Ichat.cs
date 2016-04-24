using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedLib
{
    [ServiceContract(CallbackContract = typeof(MyCallback), SessionMode =SessionMode.Required)]
    public interface IChat
    {
        [OperationContract]
        bool Subscribe(string Name);

        [OperationContract]
        bool UnSubscribe();
        
        [OperationContract]
        void CreatePrivateRoom(People Man, string NameOfRoom);

        [OperationContract]
        void AddUserToPrivateRoom(string UserName, string Room);

        [OperationContract]
        void SendPrivateMessage(Message NewMessage, string PrivateRoom);

        [OperationContract]
        void CreateNewMan(string name);

        [OperationContract]
        void SendMessage(Message message);
    }

    [ServiceContract]
    public interface MyCallback
    {
        [OperationContract(IsOneWay =true)]
        void OnNewMessage(string new_message);

        [OperationContract(IsOneWay = true)]
        void OnNewUser(string Usver_name);
        
        [OperationContract(IsOneWay = true)]
        void OnCreateNewRoom(string new_room);
    }


    [DataContract(Name = "People")]
    public class People
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public MyCallback Callback { get; set; }
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
