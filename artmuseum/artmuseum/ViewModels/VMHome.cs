using System;
using artmuseum.Models;
namespace artmuseum.ViewModels
{
    public class VMHome : BaseViewModel
    {

        private UserDetails _userDetails { get; set; }

        public UserDetails userDetails
        {
            get { return _userDetails; }
            set
            {
                _userDetails = value;
                OnPropertyChanged();
            }
        }
        public VMHome(UserDetails detail)
        {
            userDetails = detail;

        }

    }
}