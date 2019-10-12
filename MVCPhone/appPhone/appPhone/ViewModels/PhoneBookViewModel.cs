

namespace appPhone.ViewModels
{
    using appPhone.Models;
    using appPhone.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class PhoneBookViewModel:BaseViewModel

    {

        #region Attributes
        private ObservableCollection<Phone> phones;
        private ApiService apiService;
        #endregion

        #region Properties

        public ObservableCollection<Phone> Phones
        {
            get { return this.phones; }
            set { SetValue(ref this.phones, value); }
        }

        #endregion

        #region Constructor

        public PhoneBookViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPhones();

        }

        #endregion



        #region Methods

        private async void LoadPhones()
        {

            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Connection Error",
                    connection.Message,
                    "Accept");
                return;
            }

            var response = await this.apiService.GetList<Phone>(
                "http://localhost:51071/",
                "api/",
                "Phones");
            if (!response.IsSuccess)

            {
                await Application.Current.MainPage.DisplayAlert(
                    "Phone GET Error",
                    response.Message,
                    "Accept");
                return;
            }

            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ListPhone = (List<Phone>)response.Result;

            this.Phones = new ObservableCollection<Phone>(this.ToPhoneView());

        }

        private IEnumerable<Phone> ToPhoneView()
        {
            ObservableCollection<Phone> collection = new ObservableCollection<Phone>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.ListPhone)
            {
                Phone numero = new Phone();
                numero.PhoneID = lista.PhoneID;
                numero.Name = lista.Name;
                numero.Type = lista.Type;
                numero.Contact = lista.Contact;
                collection.Add(numero);
            }
            return collection;
        }

        #endregion
    }
}