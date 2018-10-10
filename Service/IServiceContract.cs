using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Service.DateObjectSender;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceContract" in both code and config file together.
    [ServiceContract]
    public interface IServiceContract
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "xml/{value}")]
        string GetData(string value);

        [OperationContract]
        bool CreateNewDB();

        [OperationContract]
        Task<List<string>> GetComipeType(string lang);
        [OperationContract]
        Task<ResultCompareObject> AddCode(AddingCodeObject param);

        [OperationContract]
        List<string> GetListSubmit();

        [OperationContract]
        ResultCompareObject SearchFromListSubmit(string tagForSearch);

        [OperationContract]
        List<string> GetListHistory();

        [OperationContract]
        bool Registration(RegistrationObject regInfo);

        [OperationContract]
        List<object> Autification(UserInformationObject information);

        [OperationContract]
        bool ChangeUserImage(UserInformationObject information);

        [OperationContract]
        void UpdateUserInfo(UserInformationObject information);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
