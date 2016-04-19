namespace GettingStartedClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.button_input = new System.Windows.Forms.Button();
            this.text_login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.list_of_people = new System.Windows.Forms.ComboBox();
            this.check_room = new System.Windows.Forms.ComboBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_new_man = new System.Windows.Forms.Button();
            this.button_create_room = new System.Windows.Forms.Button();
            this.text_create = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.AcceptsTab = true;
            resources.ApplyResources(this.txtChat, "txtChat");
            this.txtChat.Name = "txtChat";
            // 
            // button_input
            // 
            resources.ApplyResources(this.button_input, "button_input");
            this.button_input.Name = "button_input";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button2_Click);
            // 
            // text_login
            // 
            resources.ApplyResources(this.text_login, "text_login");
            this.text_login.Name = "text_login";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_input);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.text_login);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.list_of_people);
            this.panel2.Controls.Add(this.check_room);
            this.panel2.Controls.Add(this.button_exit);
            this.panel2.Controls.Add(this.button_new_man);
            this.panel2.Controls.Add(this.button_create_room);
            this.panel2.Controls.Add(this.text_create);
            this.panel2.Controls.Add(this.button_send);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.richTextBox2);
            this.panel2.Name = "panel2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // list_of_people
            // 
            resources.ApplyResources(this.list_of_people, "list_of_people");
            this.list_of_people.FormattingEnabled = true;
            this.list_of_people.Name = "list_of_people";
            // 
            // check_room
            // 
            resources.ApplyResources(this.check_room, "check_room");
            this.check_room.DisplayMember = "Общая комната";
            this.check_room.FormattingEnabled = true;
            this.check_room.Items.AddRange(new object[] {
            resources.GetString("check_room.Items")});
            this.check_room.Name = "check_room";
            this.check_room.SelectedValueChanged += new System.EventHandler(this.go);
            // 
            // button_exit
            // 
            resources.ApplyResources(this.button_exit, "button_exit");
            this.button_exit.Name = "button_exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_new_man
            // 
            resources.ApplyResources(this.button_new_man, "button_new_man");
            this.button_new_man.Name = "button_new_man";
            this.button_new_man.UseVisualStyleBackColor = true;
            this.button_new_man.Click += new System.EventHandler(this.button_new_man_Click);
            // 
            // button_create_room
            // 
            resources.ApplyResources(this.button_create_room, "button_create_room");
            this.button_create_room.Name = "button_create_room";
            this.button_create_room.UseVisualStyleBackColor = true;
            this.button_create_room.Click += new System.EventHandler(this.button_create_room_Click);
            // 
            // text_create
            // 
            resources.ApplyResources(this.text_create, "text_create");
            this.text_create.Name = "text_create";
            // 
            // button_send
            // 
            resources.ApplyResources(this.button_send, "button_send");
            this.button_send.Name = "button_send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // richTextBox2
            // 
            resources.ApplyResources(this.richTextBox2, "richTextBox2");
            this.richTextBox2.Name = "richTextBox2";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.TextBox text_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_create_room;
        private System.Windows.Forms.TextBox text_create;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_new_man;
        private System.Windows.Forms.ComboBox check_room;
        public System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.ComboBox list_of_people;
        private System.Windows.Forms.Button button1;
    }
}

