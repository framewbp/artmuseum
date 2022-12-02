using artmuseum.Helpers;
using artmuseum.Models;
using artmuseum.Views;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace artmuseum.ViewModels
{
    public class VMLogin : BaseViewModel
    {
        public ICommand btnLogin { get; set; }
        private Users _users { get; set; }

        private string _message { get; set; }
        public string message
        {
            get
            { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public Users users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private bool _isActivity { get; set; }

        public bool isActivity
        {
            get { return _isActivity; }
            set
            {
                _isActivity = value;
                OnPropertyChanged();
            }
        }
        public VMLogin()
        {
            users = new Users();
            users.username = "";
            message = "";
            btnLogin = new Command(async () => await userLogin());
        }

        private async Task userLogin()
        {
            try
            {
                string webURL = APIHelper.loginAPI;
                HttpHelper httpHelper = new HttpHelper();
                isActivity = true;
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(users));
                isActivity = false;
                if (res.result)
                {
                    UserDetails details = new UserDetails();
                    string obj = JsonConvert.SerializeObject(res.response);
                    details = JsonConvert.DeserializeObject<UserDetails>(obj);
                    Application.Current.MainPage = new Home(details);
                }
                else
                    message = res.message;

                isActivity = false;
            }
            catch (Exception ex)
            {
                isActivity = false;
                message = ex.Message.ToString();
            }
        }
    }
}
