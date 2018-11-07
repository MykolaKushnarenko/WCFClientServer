using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml;
using DataBasesUtil;
using Service.DateObjectSender;
using Ionic.Zip;
using DetailsAnalysis;
namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceContract" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceContract.svc or ServiceContract.svc.cs at the Solution Explorer and start debugging.
    public class ServiceContract : IServiceContract
    {

        private static readonly string _path = HostingEnvironment.MapPath("~/Document/");
        private static readonly string stringConnection = ConfigurationManager.ConnectionStrings["CompareCodeSqlProvider"].ConnectionString;
        private List<string> _allCompileType = new List<string>();
        private ZipFile _zip;
        private ResultCompareObject _resultCompare = new ResultCompareObject();
        private DBUtil _db = new DBUtil(stringConnection);
        private AnalysisRoslyn _analysis;
        private void GetAnalysisRoslyn(string solutionFilePath)
        {
            try
            {
                
                _analysis = new AnalysisRoslyn(solutionFilePath);
                _analysis.GetAllTypeInProgram();

            }
            catch(Exception ex)
            {
                // ignored
            }
        }
        private void RunFullAnalysis(string path)
        {
            IEnumerable<string> getPathSolution = Directory.GetFiles(path).Where(p => p.Split('.')[1] == "sln").Select(p => p);
            string fullPathSolutionFile = getPathSolution.Single();
            GetAnalysisRoslyn(fullPathSolutionFile);
        }
        private void ExportFromZip(string path, string filePath)
        {

            using (_zip = ZipFile.Read(filePath))
            {
                foreach (ZipEntry file in _zip)
                {
                    file.Extract(path);
                }
            }
        }
        private void CreateZipFromSream(byte[] zipFile)
        {
            string guid = $"{Guid.NewGuid()}";
            Directory.CreateDirectory(_path + guid);
            string fullPath = $"{_path}{guid}\\{guid}.zip";
            using (FileStream file = new FileStream(fullPath, FileMode.Create))
            {
                file.Write(zipFile,0,zipFile.Length);
            }
            ExportFromZip(_path + guid, fullPath);
            RunFullAnalysis(_path + guid);

        }
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }
        private void GetResultList()
        {
            //TODO: improve this method 
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
            //TODO: Don't forgot remove direction to project!!!
            //GetAnalysisRoslyn(@"D:\repos\TempleForRoslyn\TempleForRoslyn.sln");
            List<string> result = await Task.Run(() =>
            {
                _allCompileType = _db.GetCompile(lang);
                return _allCompileType;
            });
            return result;
        }

        public async Task<ResultCompareObject> AddCode(AddingCodeObject param)
        {
            if (param.Solution != null)
            {
                CreateZipFromSream(param.Solution);
            }
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
            return _resultCompare;
        }

        public List<string> GetListSubmit()
        {
            List<string> listAllSubmit = _db.DescSubm();
            return listAllSubmit;
        }

        public ResultCompareObject SearchFromListSubmit(string tagForSearch)
        {
            _db.SearchIn(tagForSearch);
            GetResultList();
            return _resultCompare;
        }

        public List<string> GetListHistory()
        {
            List<string> listAllHistory = _db.GetListHistory();
            return listAllHistory;
        }

        public bool Registration(RegistrationObject regInfo)
        {
            _db.RegistsAccount(regInfo.Name, regInfo.EMail, regInfo.Password);
            return true;
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
            return resultAfterAutif;
        }

        public bool ChangeUserImage(UserInformationObject information)
        {
            _db.UpdateImage(information.Name, information.Image);
            return true;
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
