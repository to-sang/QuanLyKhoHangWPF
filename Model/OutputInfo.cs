//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhom13_Quan_ly_kho_hang.Model
{
    using Nhom13_Quan_ly_kho_hang.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class OutputInfo : BaseViewModel
    {
        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged(); }
        }
        private string _IdObject;

        public string IdObject
        {
            get { return _IdObject; }
            set { _IdObject = value; OnPropertyChanged(); }
        }
        private string _IdOutput;

        public string IdOutput
        {
            get { return _IdOutput; }
            set { _IdOutput = value; OnPropertyChanged(); }
        }
        private int _IdCustomer;

        public int IdCustomer
        {
            get { return _IdCustomer; }
            set { _IdCustomer = value; OnPropertyChanged(); }
        }
        private Nullable<int> _Count;

        public Nullable<int> Count
        {
            get { return _Count; }
            set { _Count = value; OnPropertyChanged(); }
        }


        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; OnPropertyChanged(); }
        }
        private Nullable<double> _OutputPrice;

        public Nullable<double> OutputPrice
        {
            get { return _OutputPrice; }
            set { _OutputPrice = value; OnPropertyChanged(); }
        }


        public virtual Customer Customer { get; set; }
        public virtual Object Object { get; set; }
        public virtual Output Output { get; set; }
    }
}
