﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestAssistant.ServiceReference_MES {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://device.service.moresoft.com/", ConfigurationName="ServiceReference_MES.MesFrameWorkSoap")]
    public interface MesFrameWorkSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/es_Laser_coding", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string es_Laser_coding(string WorkOrder, string ReelNo, string MSN, string NGSN, string M_WORKSTATION_SN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/es_Laser_coding", ReplyAction="*")]
        System.Threading.Tasks.Task<string> es_Laser_codingAsync(string WorkOrder, string ReelNo, string MSN, string NGSN, string M_WORKSTATION_SN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/RESTGREATEMOSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string RESTGREATEMOSN(string projectno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/RESTGREATEMOSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> RESTGREATEMOSNAsync(string projectno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Check_Route", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_Check_Route(string M_WORKSTATION_SN, string M_SN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Check_Route", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_Check_RouteAsync(string M_WORKSTATION_SN, string M_SN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_PcbID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_Upload_PcbID(string M_WORKSTATION_SN, string M_SN, string M_EMP, string M_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_PcbID", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_Upload_PcbIDAsync(string M_WORKSTATION_SN, string M_SN, string M_EMP, string M_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_SNReturnID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_SNReturnID(string M_WORKSTATION_SN, string M_SN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_SNReturnID", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_SNReturnIDAsync(string M_WORKSTATION_SN, string M_SN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_SN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_Upload_SN(string M_WORKSTATION_SN, string M_SN, string M_PRODUCT_SN, string M_EMP, string M_ERROR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_SN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_Upload_SNAsync(string M_WORKSTATION_SN, string M_SN, string M_PRODUCT_SN, string M_EMP, string M_ERROR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_Before_Ageing", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_Upload_Before_Ageing(string M_WORKSTATION_SN, string M_PRODUCT_SN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_Before_Ageing", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_Upload_Before_AgeingAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_After_Ageing", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_Upload_After_Ageing(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_After_Ageing", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_Upload_After_AgeingAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/AUTO_PACK_ITEMSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AUTO_PACK_ITEMSN(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_BOXSN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/AUTO_PACK_ITEMSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> AUTO_PACK_ITEMSNAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_BOXSN, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_BOX_CODE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_Upload_BOX_CODE(string M_PROJECTNO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_BOX_CODE", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_Upload_BOX_CODEAsync(string M_PROJECTNO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_CONTAINER_PC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_Upload_CONTAINER_PC(string M_WORKSTATION_SN, string EmpNo, string M_BOX_SN, string M_CONTAINER_SN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_Upload_CONTAINER_PC", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_Upload_CONTAINER_PCAsync(string M_WORKSTATION_SN, string EmpNo, string M_BOX_SN, string M_CONTAINER_SN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/es_Laser_Check_Para", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string es_Laser_Check_Para(string M_WORKSTATION, string M_MO, string M_USERNO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/es_Laser_Check_Para", ReplyAction="*")]
        System.Threading.Tasks.Task<string> es_Laser_Check_ParaAsync(string M_WORKSTATION, string M_MO, string M_USERNO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_PCB_TEST", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Auto_PCB_TEST(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EC_ALL_DATA, string M_EMP, string M_PCBID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/Auto_PCB_TEST", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Auto_PCB_TESTAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EC_ALL_DATA, string M_EMP, string M_PCBID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/GetSNStateData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetSNStateData(string SerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/GetSNStateData", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetSNStateDataAsync(string SerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/UploadSNData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadSNData(string SerialNumber, string MachineSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/UploadSNData", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadSNDataAsync(string SerialNumber, string MachineSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/ASSYUPMATERIAL", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ASSYUPMATERIAL(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/ASSYUPMATERIAL", ReplyAction="*")]
        System.Threading.Tasks.Task<string> ASSYUPMATERIALAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EMP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/AGV_TASKLIST", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AGV_TASKLIST();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/AGV_TASKLIST", ReplyAction="*")]
        System.Threading.Tasks.Task<string> AGV_TASKLISTAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/AGVFINISH_TASK", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AGVFINISH_TASK(string rfid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/AGVFINISH_TASK", ReplyAction="*")]
        System.Threading.Tasks.Task<string> AGVFINISH_TASKAsync(string rfid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/UploadFixtureTestData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadFixtureTestData(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://device.service.moresoft.com/UploadFixtureTestData", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadFixtureTestDataAsync(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MesFrameWorkSoapChannel : TestAssistant.ServiceReference_MES.MesFrameWorkSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MesFrameWorkSoapClient : System.ServiceModel.ClientBase<TestAssistant.ServiceReference_MES.MesFrameWorkSoap>, TestAssistant.ServiceReference_MES.MesFrameWorkSoap {
        
        public MesFrameWorkSoapClient() {
        }
        
        public MesFrameWorkSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MesFrameWorkSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MesFrameWorkSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MesFrameWorkSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string es_Laser_coding(string WorkOrder, string ReelNo, string MSN, string NGSN, string M_WORKSTATION_SN, string M_EMP) {
            return base.Channel.es_Laser_coding(WorkOrder, ReelNo, MSN, NGSN, M_WORKSTATION_SN, M_EMP);
        }
        
        public System.Threading.Tasks.Task<string> es_Laser_codingAsync(string WorkOrder, string ReelNo, string MSN, string NGSN, string M_WORKSTATION_SN, string M_EMP) {
            return base.Channel.es_Laser_codingAsync(WorkOrder, ReelNo, MSN, NGSN, M_WORKSTATION_SN, M_EMP);
        }
        
        public string RESTGREATEMOSN(string projectno) {
            return base.Channel.RESTGREATEMOSN(projectno);
        }
        
        public System.Threading.Tasks.Task<string> RESTGREATEMOSNAsync(string projectno) {
            return base.Channel.RESTGREATEMOSNAsync(projectno);
        }
        
        public string Auto_Check_Route(string M_WORKSTATION_SN, string M_SN, string M_EMP) {
            return base.Channel.Auto_Check_Route(M_WORKSTATION_SN, M_SN, M_EMP);
        }
        
        public System.Threading.Tasks.Task<string> Auto_Check_RouteAsync(string M_WORKSTATION_SN, string M_SN, string M_EMP) {
            return base.Channel.Auto_Check_RouteAsync(M_WORKSTATION_SN, M_SN, M_EMP);
        }
        
        public string Auto_Upload_PcbID(string M_WORKSTATION_SN, string M_SN, string M_EMP, string M_ID) {
            return base.Channel.Auto_Upload_PcbID(M_WORKSTATION_SN, M_SN, M_EMP, M_ID);
        }
        
        public System.Threading.Tasks.Task<string> Auto_Upload_PcbIDAsync(string M_WORKSTATION_SN, string M_SN, string M_EMP, string M_ID) {
            return base.Channel.Auto_Upload_PcbIDAsync(M_WORKSTATION_SN, M_SN, M_EMP, M_ID);
        }
        
        public string Auto_SNReturnID(string M_WORKSTATION_SN, string M_SN, string M_EMP) {
            return base.Channel.Auto_SNReturnID(M_WORKSTATION_SN, M_SN, M_EMP);
        }
        
        public System.Threading.Tasks.Task<string> Auto_SNReturnIDAsync(string M_WORKSTATION_SN, string M_SN, string M_EMP) {
            return base.Channel.Auto_SNReturnIDAsync(M_WORKSTATION_SN, M_SN, M_EMP);
        }
        
        public string Auto_Upload_SN(string M_WORKSTATION_SN, string M_SN, string M_PRODUCT_SN, string M_EMP, string M_ERROR) {
            return base.Channel.Auto_Upload_SN(M_WORKSTATION_SN, M_SN, M_PRODUCT_SN, M_EMP, M_ERROR);
        }
        
        public System.Threading.Tasks.Task<string> Auto_Upload_SNAsync(string M_WORKSTATION_SN, string M_SN, string M_PRODUCT_SN, string M_EMP, string M_ERROR) {
            return base.Channel.Auto_Upload_SNAsync(M_WORKSTATION_SN, M_SN, M_PRODUCT_SN, M_EMP, M_ERROR);
        }
        
        public string Auto_Upload_Before_Ageing(string M_WORKSTATION_SN, string M_PRODUCT_SN) {
            return base.Channel.Auto_Upload_Before_Ageing(M_WORKSTATION_SN, M_PRODUCT_SN);
        }
        
        public System.Threading.Tasks.Task<string> Auto_Upload_Before_AgeingAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN) {
            return base.Channel.Auto_Upload_Before_AgeingAsync(M_WORKSTATION_SN, M_PRODUCT_SN);
        }
        
        public string Auto_Upload_After_Ageing(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_TestResult) {
            return base.Channel.Auto_Upload_After_Ageing(M_WORKSTATION_SN, M_PRODUCT_SN, M_TestResult);
        }
        
        public System.Threading.Tasks.Task<string> Auto_Upload_After_AgeingAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_TestResult) {
            return base.Channel.Auto_Upload_After_AgeingAsync(M_WORKSTATION_SN, M_PRODUCT_SN, M_TestResult);
        }
        
        public string AUTO_PACK_ITEMSN(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_BOXSN, string M_EMP) {
            return base.Channel.AUTO_PACK_ITEMSN(M_WORKSTATION_SN, M_PRODUCT_SN, M_MO, M_BOXSN, M_EMP);
        }
        
        public System.Threading.Tasks.Task<string> AUTO_PACK_ITEMSNAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_BOXSN, string M_EMP) {
            return base.Channel.AUTO_PACK_ITEMSNAsync(M_WORKSTATION_SN, M_PRODUCT_SN, M_MO, M_BOXSN, M_EMP);
        }
        
        public string Auto_Upload_BOX_CODE(string M_PROJECTNO) {
            return base.Channel.Auto_Upload_BOX_CODE(M_PROJECTNO);
        }
        
        public System.Threading.Tasks.Task<string> Auto_Upload_BOX_CODEAsync(string M_PROJECTNO) {
            return base.Channel.Auto_Upload_BOX_CODEAsync(M_PROJECTNO);
        }
        
        public string Auto_Upload_CONTAINER_PC(string M_WORKSTATION_SN, string EmpNo, string M_BOX_SN, string M_CONTAINER_SN) {
            return base.Channel.Auto_Upload_CONTAINER_PC(M_WORKSTATION_SN, EmpNo, M_BOX_SN, M_CONTAINER_SN);
        }
        
        public System.Threading.Tasks.Task<string> Auto_Upload_CONTAINER_PCAsync(string M_WORKSTATION_SN, string EmpNo, string M_BOX_SN, string M_CONTAINER_SN) {
            return base.Channel.Auto_Upload_CONTAINER_PCAsync(M_WORKSTATION_SN, EmpNo, M_BOX_SN, M_CONTAINER_SN);
        }
        
        public string es_Laser_Check_Para(string M_WORKSTATION, string M_MO, string M_USERNO) {
            return base.Channel.es_Laser_Check_Para(M_WORKSTATION, M_MO, M_USERNO);
        }
        
        public System.Threading.Tasks.Task<string> es_Laser_Check_ParaAsync(string M_WORKSTATION, string M_MO, string M_USERNO) {
            return base.Channel.es_Laser_Check_ParaAsync(M_WORKSTATION, M_MO, M_USERNO);
        }
        
        public string Auto_PCB_TEST(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EC_ALL_DATA, string M_EMP, string M_PCBID) {
            return base.Channel.Auto_PCB_TEST(M_WORKSTATION_SN, M_PRODUCT_SN, M_MO, M_EC_ALL_DATA, M_EMP, M_PCBID);
        }
        
        public System.Threading.Tasks.Task<string> Auto_PCB_TESTAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EC_ALL_DATA, string M_EMP, string M_PCBID) {
            return base.Channel.Auto_PCB_TESTAsync(M_WORKSTATION_SN, M_PRODUCT_SN, M_MO, M_EC_ALL_DATA, M_EMP, M_PCBID);
        }
        
        public string GetSNStateData(string SerialNumber) {
            return base.Channel.GetSNStateData(SerialNumber);
        }
        
        public System.Threading.Tasks.Task<string> GetSNStateDataAsync(string SerialNumber) {
            return base.Channel.GetSNStateDataAsync(SerialNumber);
        }
        
        public string UploadSNData(string SerialNumber, string MachineSN) {
            return base.Channel.UploadSNData(SerialNumber, MachineSN);
        }
        
        public System.Threading.Tasks.Task<string> UploadSNDataAsync(string SerialNumber, string MachineSN) {
            return base.Channel.UploadSNDataAsync(SerialNumber, MachineSN);
        }
        
        public string ASSYUPMATERIAL(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EMP) {
            return base.Channel.ASSYUPMATERIAL(M_WORKSTATION_SN, M_PRODUCT_SN, M_MO, M_EMP);
        }
        
        public System.Threading.Tasks.Task<string> ASSYUPMATERIALAsync(string M_WORKSTATION_SN, string M_PRODUCT_SN, string M_MO, string M_EMP) {
            return base.Channel.ASSYUPMATERIALAsync(M_WORKSTATION_SN, M_PRODUCT_SN, M_MO, M_EMP);
        }
        
        public string AGV_TASKLIST() {
            return base.Channel.AGV_TASKLIST();
        }
        
        public System.Threading.Tasks.Task<string> AGV_TASKLISTAsync() {
            return base.Channel.AGV_TASKLISTAsync();
        }
        
        public string AGVFINISH_TASK(string rfid) {
            return base.Channel.AGVFINISH_TASK(rfid);
        }
        
        public System.Threading.Tasks.Task<string> AGVFINISH_TASKAsync(string rfid) {
            return base.Channel.AGVFINISH_TASKAsync(rfid);
        }
        
        public string UploadFixtureTestData(string msg) {
            return base.Channel.UploadFixtureTestData(msg);
        }
        
        public System.Threading.Tasks.Task<string> UploadFixtureTestDataAsync(string msg) {
            return base.Channel.UploadFixtureTestDataAsync(msg);
        }
    }
}
