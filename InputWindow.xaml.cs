﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nhom13_Quan_ly_kho_hang
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SetZero(object sender, TextChangedEventArgs e)
        {
            if (txtCount is null)
            {
                txtCount = new TextBox();
                txtCount.Text = "0";
            }
            if (txtInputPrice is null)
            {
                txtInputPrice = new TextBox();
                txtInputPrice.Text = "0";
            }
            if (txtOutputPrice is null)
            {
                txtOutputPrice = new TextBox();
                txtOutputPrice.Text = "0";
            }
            if (string.IsNullOrEmpty(txtCount.Text))
                txtCount.Text = "0";
            if (string.IsNullOrEmpty(txtInputPrice.Text))
                txtInputPrice.Text = "0";
            if (string.IsNullOrEmpty(txtOutputPrice.Text))
                txtOutputPrice.Text = "0";
        }
    }
}
