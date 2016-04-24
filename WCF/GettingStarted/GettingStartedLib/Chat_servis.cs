using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;


namespace GettingStartedLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Chat_Servis : IChat
    {
        private static List<MyCallback> creating_rooms = new List<MyCallback>();
        private static List<People> AllUser = new List<People>();
    
        public void CreatePrivateRoom(People usver, string name_of_room)
        {
            Console.WriteLine("Create room: " + name_of_room);

            for (int i = 0; i < AllUser.Count; i++)
                if (AllUser[i].Name == usver.Name)
                {
                    AllUser[i].Rooms.Add(name_of_room);
                    if (((ICommunicationObject)AllUser[i].Callback).State == CommunicationState.Opened)
                        AllUser[i].Callback.OnCreateNewRoom(name_of_room);
                    else
                        AllUser[i].Callback = null;
                }
        }

        public void SendPrivateMessage(Message new_message, string private_room)
        {
            Console.WriteLine(new_message.UserMessage);
            string newMessage = String.Format("in room {2} {0} says : {1}",
                new_message.CurrentUser,
                new_message.UserMessage,
                private_room
                );
            for (int i = 0; i < AllUser.Count; i++)
                if (AllUser[i].Rooms.Contains(private_room))
                    {                
                    if (((ICommunicationObject)AllUser[i].Callback).State == CommunicationState.Opened)
                        AllUser[i].Callback.OnNewMessage(newMessage);
                    else
                        AllUser[i].Callback = null;
                    }
        }

    
        public void CreateNewMan(string name)
        {
            for (int i = 0; i < AllUser.Count; i++)
                if (((ICommunicationObject)AllUser[i].Callback).State == CommunicationState.Opened)
                    AllUser[i].Callback.OnNewUser(name);
                else
                    AllUser[i].Callback = null;
            update();

        }

        public void AddUserToPrivateRoom(string usver_name, string room)
        {
            for (int i = 0; i < AllUser.Count; i++)
                if (AllUser[i].Name == usver_name)
                {
                    AllUser[i].Rooms.Add(room);
                    if (((ICommunicationObject)AllUser[i].Callback).State == CommunicationState.Opened)
                        AllUser[i].Callback.OnCreateNewRoom(room);
                    else
                        AllUser[i].Callback = null;
                }
        }

        private void update()
        {
            for (int i = 0; i < AllUser.Count - 1; i++)
                if (((ICommunicationObject)AllUser[i].Callback).State == CommunicationState.Opened)
                    AllUser[AllUser.Count - 1].Callback.OnNewUser(AllUser[i].Name);
                else
                    AllUser[AllUser.Count - 1].Callback = null;
        }


        public bool Subscribe(string Name)
        {
            MyCallback current = OperationContext.Current.GetCallbackChannel<MyCallback>();
            Console.WriteLine("hi " + Name);
            People Usver = new People();
            if (AllUser.Count == 0)
            {
                Usver.Name = Name;
                Usver.Rooms.Add("Общая");
                Usver.Callback = current;
                AllUser.Add(Usver);
                return true;
            }
            else
            {
                for (int i = 0; i < AllUser.Count; i++)
                    if (AllUser[i].Name == Name)
                        return false;

            }
            Usver.Name = Name;
            Usver.Rooms.Add("Общая");
            Usver.Callback = current;
            AllUser.Add(Usver);
            return true;
        }

        public bool UnSubscribe()
        {
            MyCallback currentContext = OperationContext.Current.GetCallbackChannel<MyCallback>();
            for (int i = 0; i < AllUser.Count; i++)
            {
               if (AllUser[i].Callback== currentContext)
                {
                    Console.WriteLine("Goodbye " + AllUser[i].Name);
                    AllUser.Remove(AllUser[i]);
                    return true;
                }
            }
            return false;
         }

        public void SendMessage(Message message)
        {
            Console.WriteLine(message.UserMessage);
            string newMessage = String.Format(" {0} says : {1}",
                message.CurrentUser,
                message.UserMessage);
            for (int i = 0; i < AllUser.Count; i++)
            {
                if (((ICommunicationObject)AllUser[i].Callback).State == CommunicationState.Opened)
                    AllUser[i].Callback.OnNewMessage(newMessage);
                else
                    AllUser[i].Callback = null;
            }
        }
    }
}