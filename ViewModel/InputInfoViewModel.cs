﻿using Nhom13_Quan_ly_kho_hang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Nhom13_Quan_ly_kho_hang.ViewModel
{
    public class InputInfoViewModel : BaseViewModel
    {
        private ObservableCollection<InputInfo> _List;

        public ObservableCollection<InputInfo> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Model.Object> _ObjectList;

        public ObservableCollection<Model.Object> ObjectList
        {
            get { return _ObjectList; }
            set { _ObjectList = value; OnPropertyChanged(); }
        }
        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged(); }
        }

        private DateTime _DateInput;

        public DateTime DateInput
        {
            get { return _DateInput; }
            set { _DateInput = value; OnPropertyChanged(); }
        }

        private int _Count;

        public int Count
        {
            get { return _Count; }
            set { _Count = value; OnPropertyChanged(); }
        }

        private double _PriceInput;

        public double PriceInput
        {
            get { return _PriceInput; }
            set { _PriceInput = value; OnPropertyChanged(); }
        }

        private Model.Object _SelectedObject;

        public Model.Object SelectedObject
        {
            get { return _SelectedObject; }
            set { _SelectedObject = value; OnPropertyChanged(); }
        }
        private double _PriceOutput;

        public double PriceOutput
        {
            get { return _PriceOutput; }
            set { _PriceOutput = value; OnPropertyChanged(); }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; OnPropertyChanged(); }
        }

        private InputInfo _SelectedItem;

        public InputInfo SelectedItem
        {
            get { return _SelectedItem; }
            set 
            { 
                _SelectedItem = value; 
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    DateInput = SelectedItem.Input.DateInput.Value;
                    Count = SelectedItem.Count.Value;
                    PriceInput = SelectedItem.InputPrice.Value;
                    PriceOutput = SelectedItem.OutputPrice.Value;
                    Status = SelectedItem.Status;
                    SelectedObject = SelectedItem.Object;
                }
                else
                {
                    Id = null;
                    DateInput = DateTime.Today;
                    Count = 0;
                    PriceInput = 0;
                    PriceOutput = 0;
                    Status = "";
                }
            }
        }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        public InputInfoViewModel()
        {
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var inp = DataProvider.Ins.DB.Inputs.Where(x => x.DateInput == DateInput);
                Console.WriteLine(inp.Count());
                if (!(inp == null || inp.Count() != 0))
                {
                    var input = new Model.Input() { DateInput = DateInput, Id = Guid.NewGuid().ToString() };
                    DataProvider.Ins.DB.Inputs.Add(input);
                    DataProvider.Ins.DB.SaveChanges();
                }
                var inpo = DataProvider.Ins.DB.Inputs.Where(x => x.DateInput == DateInput).SingleOrDefault();
                var inputinfor = new InputInfo()
                {
                    IdObject = SelectedObject.Id,
                    IdInput = inpo.Id,
                    Count = Count,
                    InputPrice = PriceInput,
                    OutputPrice = PriceOutput,
                    Status = Status,
                    Id = Guid.NewGuid().ToString()
                };
                DataProvider.Ins.DB.InputInfoes.Add(inputinfor);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(inputinfor);
            });

            EditCommand = new RelayCommand<object>((p) => 
            { 
                return true; 
            }, (p) =>
            {
                var inp = DataProvider.Ins.DB.Inputs.Where(x => x.DateInput == DateInput);
                Console.WriteLine(inp.Count());
                if (!(inp == null || inp.Count() != 0))
                {
                    var input = new Model.Input() { DateInput = DateInput, Id = Guid.NewGuid().ToString() };
                    DataProvider.Ins.DB.Inputs.Add(input);
                    DataProvider.Ins.DB.SaveChanges();
                }
                var inpo = DataProvider.Ins.DB.Inputs.Where(x => x.DateInput == DateInput).SingleOrDefault();
                var inputInfo = DataProvider.Ins.DB.InputInfoes.Where(x => x.Id == Id).SingleOrDefault();
                inputInfo.IdObject = SelectedObject.Id;
                inputInfo.IdInput = inpo.Id;
                inputInfo.Count = Count;
                inputInfo.InputPrice = PriceInput;
                inputInfo.OutputPrice = PriceOutput;
                inputInfo.Status = Status;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem = inputInfo;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Bạn có chắc chắn muốn xóa đơn nhập không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {    
                    DataProvider.Ins.DB.InputInfoes.Remove(DataProvider.Ins.DB.InputInfoes.First(x => x.Id == SelectedItem.Id)) ;
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoadData();
            });

        }

        void LoadData()
        {
            List = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfoes);
            ObjectList = new ObservableCollection<Model.Object>(DataProvider.Ins.DB.Objects);
            SelectedObject = ObjectList[0];
        }
    }
}
