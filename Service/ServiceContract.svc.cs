using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBasesUtil;
using Service.DateObjectSender;
using FullAnelysisRos;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceContract" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceContract.svc or ServiceContract.svc.cs at the Solution Explorer and start debugging.
    public class ServiceContract : IServiceContract
    {
        

        private List<string> _allCompileType = new List<string>();
        private ResultCompareObject _resultCompare = new ResultCompareObject();
        private DBUtil _db = new DBUtil();
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public bool CreateNewDB()
        {
            DBUtil db = new DBUtil();
            if (db != null)
            {
                return true;
            }

            return false;
        }
        private void GetResultList()
        {
            _resultCompare.MainCodeText = _db.GetOrignCodeFromId(_db.IdMainFileForHist);
            _resultCompare.ChildCodeText = _db.GetOrignCodeFromId(_db.IdiDenticalFie);
            _db.SetCodeMain(_db.IdMainFileForHist);
            _db.SetCodeChild(_db.IdiDenticalFie);
            double resVarnFish = _db.GetResult(1);
            double resVShiling = _db.GetResult(2);
            double resHeskel = _db.GetResult(0);
            _resultCompare.ResultCompare.Add(String.Format("Levenshtein Distance : {0:0.##}", resVarnFish));
            _resultCompare.ResultCompare.Add(String.Format("WShiling : {0:0.##}", resVShiling));
            _resultCompare.ResultCompare.Add(String.Format("Haskel : {0:0.##}", resHeskel));
            _db.AddingHistiry(resVarnFish, resVShiling, resHeskel);
        }

        public async Task<List<string>> GetComipeType(string lang)
        {
            List<string> result = await Task.Run(() =>
            {
                _allCompileType = _db.GetCompile(lang);
                string s = ""; /*JsonConvert.SerializeObject(_allCompileType);*/
                return _allCompileType;
            });
            DetailsAnalysis ver = new DetailsAnalysis("123");
            return result;
        }

        public async Task<ResultCompareObject> AddCode(AddingCodeObject param)
        {
            bool isOver = await _db.AddingSubmit(param.Name, param.Description, param.CompileType, param.Code, param.IsSearch, param.FileMane);
            if (param.IsSearch)
            {
                GetResultList();
            }

            if (param.CompareLocal)
            {
                _resultCompare.TokkingMainCode = _db.GetMainCodeList();
                _resultCompare.TokkingChildCode = _db.GetChildCodeList();
            }
            return _resultCompare; /*JsonConvert.SerializeObject(_resultCompare);*/
        }

        public List<string> GetListSubmit()
        {
            List<string> listAllSubmit = _db.DescSubm();
            string result = "";/*JsonConvert.SerializeObject(listAllSubmit);*/
            return listAllSubmit;
        }

        public ResultCompareObject SearchFromListSubmit(string tagForSearch)
        {
            _db.SearchIn(tagForSearch);
            GetResultList();
            return _resultCompare; /*JsonConvert.SerializeObject(_resultCompare);*/
        }

        public List<string> GetListHistory()
        {
            List<string> listAllHistory = _db.GetListHistory();
            /*JsonConvert.SerializeObject(listAllHistory);*/
            return listAllHistory;
        }

        public bool Registration(RegistrationObject regInfo)
        {
            _db.RegistsAccount(regInfo.Name, regInfo.EMail, regInfo.Password);
            return true; /*JsonConvert.SerializeObject(true);*/
        }

        public List<object> Autification(UserInformationObject information)
        {
            List<object> resultAfterAutif = new List<object>()
            {
                _db.Autification(information.Login, information.Password).ToString(),
                _db.GetNameFromLogin(information.Login),
                _db.GetImageUser(information.Login)
                //JsonConvert.SerializeObject(_db.GetImageUser(login))
            };
            return resultAfterAutif; /*JsonConvert.SerializeObject(resultAfterAutif);*/
        }

        public bool ChangeUserImage(UserInformationObject information)
        {
            _db.UpdateImage(information.Name, information.Image);
            return true; /*JsonConvert.SerializeObject(true);*/
        }

        public void UpdateUserInfo(UserInformationObject information)
        {
            if (information.Name != null)
            {
                _db.ChangeName(information.Name, information.Email);
            }
            if (information.Password != null)
            {
                _db.ChangePassword(information.Password, information.Email);
            }
        }
    }
}
