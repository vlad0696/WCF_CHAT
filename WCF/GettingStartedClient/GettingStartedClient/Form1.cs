using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using GettingStartedClient.ServiceReference1;
using System.Net;

namespace GettingStartedClient
{
    public partial class Form1 : Form
    {
        Sender obj = new Sender();
        public Form1()
        {
            InitializeComponent();
        }

        #region Client actions
        private void Form1_Load(object sender, EventArgs e)
        {
            obj.listener.GotMess += GotMessMeth;
            obj.listener.GotCheckRoom += GotAddInCheckbox;
            obj.listener.GotPeopleList += GotAddPeople;
            check_room.SelectedIndex = 0;
            panel1.Visible = true;
            panel2.Visible = false;
        }
           
        private void button2_Click(object sender, EventArgs e)
        {
            obj.BeginConnection(text_login.Text);
            MessageBox.Show("Now, you are connected to the chat");
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void buttonExitClick(object sender, EventArgs e)
        {
            obj.listener.Dispose();
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void buttonCreateRoomClick(object sender, EventArgs e)
        {
            string name_of_room = text_create.Text;
            text_create.Text = "";
            obj.CreateRoom(name_of_room);
        }

        private void buttonSendClick(object sender, EventArgs e)
        {
            string message = richTextBox2.Text;
            richTextBox2.Text = String.Empty;
            obj.SendNewMessage(message);
            obj.Dispose();
        }

        private void buttonNewManClick(object sender, EventArgs e)
        {
            string name_of_usver = list_of_people.SelectedItem.ToString();
            string private_room = check_room.SelectedItem.ToString();
            obj.AddUsverToPrivateRoom(name_of_usver, private_room);
            obj.Dispose();
        }

        private void SegueInTheRoom(object sender, EventArgs e)
        {
            txtChat.AppendText("Вы перешли в комнату: "+check_room.SelectedItem.ToString()+"\n");
        }

        private void button1Click_1(object sender, EventArgs e)
        {
            string message = richTextBox2.Text;
            string private_room = check_room.SelectedItem.ToString();
            obj.SendPrivateMessage(message, private_room);
            obj.Dispose();

        }
        #endregion

        #region Event on callback
        private void GotMessMeth(string message)
        {
           txtChat.AppendText( message+ "\n");
        }

       
        private void GotAddInCheckbox(string RoomName)
        {
            check_room.Items.Add(RoomName);
        }

        private void GotAddPeople(string UserName)
        {
            list_of_people.Items.Add(UserName);
        }
        #endregion

    }



    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class Sender : IChatCallback, IDisposable
    {

        public Listener listener = new Listener();
        public static GettingStartedLib.People currentUser { get; set; }

        #region Client request
        public void BeginConnection(string name)
        {
            currentUser = new GettingStartedLib.People() { Name = name };
            currentUser.Rooms = new string[10];
            currentUser.Rooms[0] = "Общая";
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            if (listener.ClientProxy.Subscribe(name))
            {
                CreateNewMan(name);
            }
               
        }


        public void SendNewMessage(string strMessage)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            
            GettingStartedLib.Message newMessage = new GettingStartedLib.Message()
            {
                
                CurrentUser = currentUser.Name,
                UserMessage = strMessage
            };
            listener.ClientProxy.SendMessage(newMessage);
        }


        public void CreateRoom(string name_of_room)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            MessageBox.Show("Now, you are create room: "+name_of_room);
            listener.ClientProxy.CreatePrivateRoom(currentUser, name_of_room);
           
        }

        public void CreateNewMan(string people)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            listener.ClientProxy.CreateNewMan(people);
        }

        public void AddUsverToPrivateRoom(string name_of_usver, string private_room)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            listener.ClientProxy.AddUserToPrivateRoom(name_of_usver, private_room);
        }

        public void SendPrivateMessage(string message, string private_room)
        {
            try {
                InstanceContext context = new InstanceContext(this);
                listener.initialiaze(context);
                GettingStartedLib.Message new_message = new GettingStartedLib.Message();
                new_message.CurrentUser = currentUser.Name;
                new_message.UserMessage = message;
                listener.ClientProxy.SendPrivateMessage(new_message, private_room);
            }
            finally
            {

            }
        }

        public void Dispose()
        {
            try
            {
                listener.ClientProxy.Close();
            }
            catch { }

        }
        #endregion

        #region  NotImplementedException Callback
        public void OnCreateNewRoom(string room_name)
        {
            throw new NotImplementedException();
        }
        public void OnNewMessage(string newMessage)
        {
            throw new NotImplementedException();
        }
        public void OnNewUser(string Usver_name)
        {
           throw new NotImplementedException();
        }
        #endregion


    }

    public delegate void GotMessDelegate(string message);
    public delegate void GotAddInCheckRoom(string room_name);
    public delegate void GotAddInPeopleList(string room_name);

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class Listener : IChatCallback, IDisposable
    {
        #region CAllback event       
        public event GotMessDelegate GotMess;
        public event GotAddInCheckRoom GotCheckRoom;
        public event GotAddInPeopleList GotPeopleList;
        #endregion

        public ChatClient ClientProxy;

        public void initialiaze(InstanceContext context)
        {
            InstanceContext context1 = new InstanceContext(this);
           ClientProxy = new ChatClient(context1, "WSDualHttpBinding_IChat");
        }

        #region Client Callback
        public void OnNewMessage(string new_message)
        {
            if (GotMess != null)
                GotMess(new_message);
        }
        public void OnCreateNewRoom(string room_name)
        {
            if (GotCheckRoom != null)
                GotCheckRoom(room_name);
        }

        public void OnNewUser(string UserName)
        {
            if (GotPeopleList != null)
                GotPeopleList(UserName);
        }
        #endregion

        public void Dispose()
        {
            ClientProxy.UnSubscribe();
            ClientProxy.Close();
        }

    }



}
