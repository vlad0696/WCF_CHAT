﻿using System;
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
        Listener listener = new Listener();

        public static RichTextBox TxtChat { get; private set; }
        public static ComboBox combo { get; private set; }
        public static ComboBox List_of_people { get; private set; }
        public struct person
        {
            public string login;
            public List<string> rooms;
        };
        public List<person> Persons = new List<person>();
        public Form1()
        {
            InitializeComponent();
            //check_room.
            Form1.TxtChat = this.txtChat;
            combo = check_room;
            Form1.List_of_people = this.list_of_people;
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create_new_men();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            check_room.SelectedIndex = 0;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void Create_new_men()
        {
         //   richTextBox1.AppendText(client.craete_new_man(text_login.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listener.BeginConnection(text_login.Text);
            //Entry_in_chat();
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void Entry_in_chat()
        {
          //  ChatClient client = new ChatClient();
        //    txtChat.AppendText(client.craete_new_man(text_login.Text));
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            listener.Dispose();
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button_create_room_Click(object sender, EventArgs e)
        {
            string name_of_room = text_create.Text;
            text_create.Text = "";
            Sender objSender = new Sender();
            objSender.Create_Room(name_of_room);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string message = richTextBox2.Text;
            richTextBox2.Text = String.Empty;

            Sender objSender = new Sender();
            objSender.SendNewMessage(message);
            objSender.Dispose();
        }

        private void button_new_man_Click(object sender, EventArgs e)
        {
            string name_of_usver = list_of_people.SelectedItem.ToString();
            string private_room = check_room.SelectedItem.ToString();
            Sender objSender = new Sender();
            objSender.add_usver_to_private_room(name_of_usver, private_room);
            objSender.Dispose();
        }

        private void go(object sender, EventArgs e)
        {
            txtChat.AppendText("Вы перешли в комнату: "+check_room.SelectedItem.ToString()+"\n");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = richTextBox2.Text;
            string private_room = check_room.SelectedItem.ToString();
            Sender objSender = new Sender();
            objSender.send_private_message(message, private_room);
            objSender.Dispose();

        }
    }



    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class Sender : IChatCallback, IDisposable
    {

        Listener listener = new Listener();

        public void SendNewMessage(string strMessage)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            
            GettingStartedLib.Message newMessage = new GettingStartedLib.Message()
            {
                CurrentUser = Listener.currentUser.Name,
                UserMessage = strMessage
            };
            listener.clientProxy.SendMessage(newMessage);
        }


        public void Create_Room(string name_of_room)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            if (listener.clientProxy.Subscribe_room(name_of_room)) { 
                MessageBox.Show("Now, you are create room: "+name_of_room);
                listener.clientProxy.create_private_room(Listener.currentUser, name_of_room);
               }
            else
                MessageBox.Show("An error has occurred");
            
        }

        public void create_new_man(string people)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            listener.clientProxy.craete_new_man(people);
        }

        public void add_usver_to_private_room(string name_of_usver, string private_room)
        {
            InstanceContext context = new InstanceContext(this);
            listener.initialiaze(context);
            listener.clientProxy.add_usver_to_private_room(name_of_usver, private_room);
        }

        public void send_private_message(string message, string private_room)
        {
            try {
                Listener listener = new Listener();
                InstanceContext context = new InstanceContext(this);
                listener.initialiaze(context);
                GettingStartedLib.Message new_message = new GettingStartedLib.Message();
                new_message.CurrentUser = Listener.currentUser.Name;
                new_message.UserMessage = message;
                listener.clientProxy.send_private_message(new_message, private_room);
            }
            finally
            {

            }
        }
        public void on_create_new_room(string room_name)
        {
            throw new NotImplementedException();
        }
        public void on_new_message(string newMessage)
        {
            throw new NotImplementedException();
        }
        public void on_new_usver(string Usver_name)
        {
           throw new NotImplementedException();
        }

        public void Dispose()
        {
            listener.clientProxy.Close();
        }
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class Listener : IChatCallback, IDisposable
    {
        public ChatClient clientProxy;

        public void initialiaze(InstanceContext context)
        {
           clientProxy = new ChatClient(context, "WSDualHttpBinding_IChat");
        }

        public static GettingStartedLib.people currentUser { get; set; }
        //public static GettingStartedLib.rooms currentRoom;
        public void BeginConnection(string name)
        {
            Listener.currentUser = new GettingStartedLib.people() { Name = name };
            Listener.currentUser.Rooms= new string[10];
            Listener.currentUser.Rooms[0]= "Общая";
            InstanceContext context = new InstanceContext(this);
            initialiaze(context);
            if (clientProxy.Subscribe(name))
            {
                MessageBox.Show("Now, you are connected to the chat");
                Sender obj = new Sender();
                obj.create_new_man(name);
            }
            else
                MessageBox.Show("An error has occurred");
        }

        public void on_new_message(string new_message)
        {
           Form1.TxtChat.AppendText(new_message+"\n");
        }
        public void on_create_new_room(string room_name)
        {
            Form1.combo.Items.Add(room_name);
        }

        public void on_new_usver(string Usver_name)
        {
            Form1.List_of_people.Items.Add(Usver_name);
        }
        public void Dispose()
        {
            clientProxy.UnSubscribe();
            clientProxy.Close();
        }

    }

}