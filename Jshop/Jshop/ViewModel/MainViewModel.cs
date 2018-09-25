using System;
using System.Collections.Generic;
using System.Text;

namespace Jshop.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            instance = this;
        }

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            return instance ?? (instance = new MainViewModel());
        }
        #endregion
    }


}
