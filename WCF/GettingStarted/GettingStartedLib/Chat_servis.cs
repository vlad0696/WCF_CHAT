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
        private static List<mycallback> creating_rooms = new List<mycallback>();
        private static List<People> All_usver = new List<People>();
    
        public void create_private_room(People usver, string name_of_room)
        {
            Console.WriteLine("Create room: " + name_of_room);

            for (int i = 0; i < All_usver.Count; i++)
                if (All_usver[i].Name == usver.Name)
                {
                    All_usver[i].Rooms.Add(name_of_room);
                    if (((ICommunicationObject)All_usver[i].callback).State == CommunicationState.Opened)
                        All_usver[i].callback.on_create_new_room(name_of_room);
                    else
                        All_usver[i].callback = null;
                }
        }

        public void send_private_message(Message new_message, string private_room)
        {
            Console.WriteLine(new_message.UserMessage);
            string newMessage = String.Format("in room {2} {0} says : {1}",
                new_message.CurrentUser,
                new_message.UserMessage,
                private_room
                );
            for (int i = 0; i < All_usver.Count; i++)
                if (All_usver[i].Rooms.Contains(private_room))
                    {                
                    if (((ICommunicationObject)All_usver[i].callback).State == CommunicationState.Opened)
                        All_usver[i].callback.on_new_message(newMessage);
                    else
                        All_usver[i].callback = null;
                    }
        }

    
        public void craete_new_man(string name)
        {
            for (int i = 0; i < All_usver.Count; i++)
                if (((ICommunicationObject)All_usver[i].callback).State == CommunicationState.Opened)
                    All_usver[i].callback.on_new_usver(name);
                else
                    All_usver[i].callback = null;
            update();

        }

        public void add_usver_to_private_room(string usver_name, string room)
        {
            for (int i = 0; i < All_usver.Count; i++)
                if (All_usver[i].Name == usver_name)
                {
                    All_usver[i].Rooms.Add(room);
                    if (((ICommunicationObject)All_usver[i].callback).State == CommunicationState.Opened)
                        All_usver[i].callback.on_create_new_room(room);
                    else
                        All_usver[i].callback = null;
                }
        }

        private void update()
        {
            for (int i = 0; i < All_usver.Count - 1; i++)
                if (((ICommunicationObject)All_usver[i].callback).State == CommunicationState.Opened)
                    All_usver[All_usver.Count - 1].callback.on_new_usver(All_usver[i].Name);
                else
                    All_usver[All_usver.Count - 1].callback = null;
        }

        public bool Subscribe_room(string Name)
        {
            return true;
        }

        public bool Subscribe(string Name)
        {
            mycallback current = OperationContext.Current.GetCallbackChannel<mycallback>();
            Console.WriteLine("hi " + Name);
            People Usver = new People();
            if (All_usver.Count == 0)
            {
                Usver.Name = Name;
                Usver.Rooms.Add("Общая");
                Usver.callback = current;
                All_usver.Add(Usver);
                return true;
            }
            else
            {
                for (int i = 0; i < All_usver.Count; i++)
                    if (All_usver[i].Name == Name)
                        return false;

            }
            Usver.Name = Name;
            Usver.Rooms.Add("Общая");
            Usver.callback = current;
            All_usver.Add(Usver);
            return true;
        }

        public bool UnSubscribe()
        {
            mycallback currentContext = OperationContext.Current.GetCallbackChannel<mycallback>();

            return true;
          
        }

        public void SendMessage(Message message)
        {
            Console.WriteLine(message.UserMessage);
            string newMessage = String.Format(" {0} says : {1}",
                message.CurrentUser,
                message.UserMessage);
            for (int i = 0; i < All_usver.Count; i++)
            {
                if (((ICommunicationObject)All_usver[i].callback).State == CommunicationState.Opened)
                    All_usver[i].callback.on_new_message(newMessage);
                else
                    All_usver[i].callback = null;
            }
        }
    }
}