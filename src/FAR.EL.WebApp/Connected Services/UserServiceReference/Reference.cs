﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FAR.EL.WebApp.UserServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        FAR.EL.Common.ELResult Login(FAR.EL.Models.LoginModel model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        System.Threading.Tasks.Task<FAR.EL.Common.ELResult> LoginAsync(FAR.EL.Models.LoginModel model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Register", ReplyAction="http://tempuri.org/IUserService/RegisterResponse")]
        FAR.EL.Common.ELResult Register(FAR.EL.Models.RegisterModel model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Register", ReplyAction="http://tempuri.org/IUserService/RegisterResponse")]
        System.Threading.Tasks.Task<FAR.EL.Common.ELResult> RegisterAsync(FAR.EL.Models.RegisterModel model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetDr", ReplyAction="http://tempuri.org/IUserService/GetDrResponse")]
        FAR.EL.Models.GetDrModel[] GetDr();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetDr", ReplyAction="http://tempuri.org/IUserService/GetDrResponse")]
        System.Threading.Tasks.Task<FAR.EL.Models.GetDrModel[]> GetDrAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : FAR.EL.WebApp.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<FAR.EL.WebApp.UserServiceReference.IUserService>, FAR.EL.WebApp.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FAR.EL.Common.ELResult Login(FAR.EL.Models.LoginModel model) {
            return base.Channel.Login(model);
        }
        
        public System.Threading.Tasks.Task<FAR.EL.Common.ELResult> LoginAsync(FAR.EL.Models.LoginModel model) {
            return base.Channel.LoginAsync(model);
        }
        
        public FAR.EL.Common.ELResult Register(FAR.EL.Models.RegisterModel model) {
            return base.Channel.Register(model);
        }
        
        public System.Threading.Tasks.Task<FAR.EL.Common.ELResult> RegisterAsync(FAR.EL.Models.RegisterModel model) {
            return base.Channel.RegisterAsync(model);
        }
        
        public FAR.EL.Models.GetDrModel[] GetDr() {
            return base.Channel.GetDr();
        }
        
        public System.Threading.Tasks.Task<FAR.EL.Models.GetDrModel[]> GetDrAsync() {
            return base.Channel.GetDrAsync();
        }
    }
}
