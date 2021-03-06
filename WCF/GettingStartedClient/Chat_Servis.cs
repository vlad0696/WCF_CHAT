﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GettingStartedLib
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="rooms", Namespace="http://schemas.datacontract.org/2004/07/GettingStartedLib")]
    public partial class rooms : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string[] people_spisokField;
        
        private string roomsMemberField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] people_spisok
        {
            get
            {
                return this.people_spisokField;
            }
            set
            {
                this.people_spisokField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="rooms")]
        public string roomsMember
        {
            get
            {
                return this.roomsMemberField;
            }
            set
            {
                this.roomsMemberField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/GettingStartedLib")]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private GettingStartedLib.people CurrentUserField;
        
        private string UserMessageField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GettingStartedLib.people CurrentUser
        {
            get
            {
                return this.CurrentUserField;
            }
            set
            {
                this.CurrentUserField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserMessage
        {
            get
            {
                return this.UserMessageField;
            }
            set
            {
                this.UserMessageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="people", Namespace="http://schemas.datacontract.org/2004/07/GettingStartedLib")]
    public partial class people : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NameField;
        
        private string[] RoomsField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Rooms
        {
            get
            {
                return this.RoomsField;
            }
            set
            {
                this.RoomsField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IChat", CallbackContract=typeof(IChatCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
public interface IChat
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Subscribe", ReplyAction="http://tempuri.org/IChat/SubscribeResponse")]
    bool Subscribe(string Name);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Subscribe", ReplyAction="http://tempuri.org/IChat/SubscribeResponse")]
    System.Threading.Tasks.Task<bool> SubscribeAsync(string Name);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/UnSubscribe", ReplyAction="http://tempuri.org/IChat/UnSubscribeResponse")]
    bool UnSubscribe();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/UnSubscribe", ReplyAction="http://tempuri.org/IChat/UnSubscribeResponse")]
    System.Threading.Tasks.Task<bool> UnSubscribeAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetData", ReplyAction="http://tempuri.org/IChat/GetDataResponse")]
    string GetData(int value);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetData", ReplyAction="http://tempuri.org/IChat/GetDataResponse")]
    System.Threading.Tasks.Task<string> GetDataAsync(int value);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/send_all", ReplyAction="http://tempuri.org/IChat/send_allResponse")]
    string send_all();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/send_all", ReplyAction="http://tempuri.org/IChat/send_allResponse")]
    System.Threading.Tasks.Task<string> send_allAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/create_private_room", ReplyAction="http://tempuri.org/IChat/create_private_roomResponse")]
    void create_private_room(GettingStartedLib.rooms room);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/create_private_room", ReplyAction="http://tempuri.org/IChat/create_private_roomResponse")]
    System.Threading.Tasks.Task create_private_roomAsync(GettingStartedLib.rooms room);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/send_private_message", ReplyAction="http://tempuri.org/IChat/send_private_messageResponse")]
    string send_private_message();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/send_private_message", ReplyAction="http://tempuri.org/IChat/send_private_messageResponse")]
    System.Threading.Tasks.Task<string> send_private_messageAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/entry_in_chat", ReplyAction="http://tempuri.org/IChat/entry_in_chatResponse")]
    string entry_in_chat();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/entry_in_chat", ReplyAction="http://tempuri.org/IChat/entry_in_chatResponse")]
    System.Threading.Tasks.Task<string> entry_in_chatAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/craete_new_man", ReplyAction="http://tempuri.org/IChat/craete_new_manResponse")]
    string craete_new_man(string name);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/craete_new_man", ReplyAction="http://tempuri.org/IChat/craete_new_manResponse")]
    System.Threading.Tasks.Task<string> craete_new_manAsync(string name);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Subscribe_room", ReplyAction="http://tempuri.org/IChat/Subscribe_roomResponse")]
    bool Subscribe_room(string Name);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Subscribe_room", ReplyAction="http://tempuri.org/IChat/Subscribe_roomResponse")]
    System.Threading.Tasks.Task<bool> Subscribe_roomAsync(string Name);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendMessage", ReplyAction="http://tempuri.org/IChat/SendMessageResponse")]
    void SendMessage(GettingStartedLib.Message message);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendMessage", ReplyAction="http://tempuri.org/IChat/SendMessageResponse")]
    System.Threading.Tasks.Task SendMessageAsync(GettingStartedLib.Message message);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IChatCallback
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/on_new_message")]
    void on_new_message(string new_message);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/on_create_new_room")]
    void on_create_new_room(string new_room);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IChatChannel : IChat, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ChatClient : System.ServiceModel.DuplexClientBase<IChat>, IChat
{
    
    public ChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
            base(callbackInstance)
    {
    }
    
    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
            base(callbackInstance, endpointConfigurationName)
    {
    }
    
    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, binding, remoteAddress)
    {
    }
    
    public bool Subscribe(string Name)
    {
        return base.Channel.Subscribe(Name);
    }
    
    public System.Threading.Tasks.Task<bool> SubscribeAsync(string Name)
    {
        return base.Channel.SubscribeAsync(Name);
    }
    
    public bool UnSubscribe()
    {
        return base.Channel.UnSubscribe();
    }
    
    public System.Threading.Tasks.Task<bool> UnSubscribeAsync()
    {
        return base.Channel.UnSubscribeAsync();
    }
    
    public string GetData(int value)
    {
        return base.Channel.GetData(value);
    }
    
    public System.Threading.Tasks.Task<string> GetDataAsync(int value)
    {
        return base.Channel.GetDataAsync(value);
    }
    
    public string send_all()
    {
        return base.Channel.send_all();
    }
    
    public System.Threading.Tasks.Task<string> send_allAsync()
    {
        return base.Channel.send_allAsync();
    }
    
    public void create_private_room(GettingStartedLib.rooms room)
    {
        base.Channel.create_private_room(room);
    }
    
    public System.Threading.Tasks.Task create_private_roomAsync(GettingStartedLib.rooms room)
    {
        return base.Channel.create_private_roomAsync(room);
    }
    
    public string send_private_message()
    {
        return base.Channel.send_private_message();
    }
    
    public System.Threading.Tasks.Task<string> send_private_messageAsync()
    {
        return base.Channel.send_private_messageAsync();
    }
    
    public string entry_in_chat()
    {
        return base.Channel.entry_in_chat();
    }
    
    public System.Threading.Tasks.Task<string> entry_in_chatAsync()
    {
        return base.Channel.entry_in_chatAsync();
    }
    
    public string craete_new_man(string name)
    {
        return base.Channel.craete_new_man(name);
    }
    
    public System.Threading.Tasks.Task<string> craete_new_manAsync(string name)
    {
        return base.Channel.craete_new_manAsync(name);
    }
    
    public bool Subscribe_room(string Name)
    {
        return base.Channel.Subscribe_room(Name);
    }
    
    public System.Threading.Tasks.Task<bool> Subscribe_roomAsync(string Name)
    {
        return base.Channel.Subscribe_roomAsync(Name);
    }
    
    public void SendMessage(GettingStartedLib.Message message)
    {
        base.Channel.SendMessage(message);
    }
    
    public System.Threading.Tasks.Task SendMessageAsync(GettingStartedLib.Message message)
    {
        return base.Channel.SendMessageAsync(message);
    }
}
