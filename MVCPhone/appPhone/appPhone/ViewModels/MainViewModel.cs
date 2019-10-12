namespace appPhone.ViewModels
{
    using System.Collections.Generic;
    using appPhone.Models;

    public class MainViewModel
    {

        #region Properties

        public  List<Phone> ListPhone { get; set; }

        #endregion

        #region ViewModels

        public PhoneBookViewModel phoneBookViewModel { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {

            instance = this;
            phoneBookViewModel = new PhoneBookViewModel();

        }
        
        #endregion

        #region Singleton

        private static  MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }

      //  internal class GetInstance : MainViewModel
       // {
       // }

        #endregion
    }
}
