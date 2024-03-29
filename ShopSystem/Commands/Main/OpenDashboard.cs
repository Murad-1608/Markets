﻿using ShopSystem.DataContext;
using ShopSystem.ViewModels;
using ShopSystem.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Commands.Main
{
    internal class OpenDashboard : BaseControlCommand
    {
        private readonly MainViewModel viewModel;
        public OpenDashboard(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            DashBoard dashboard = new DashBoard();
            dashboard.DataContext = viewModel;

            DataProvider data = new DataProvider(Global.DB);

            var GetProducts = data.Products();
            var GetBranches = data.Branches();
            var GetCompies = data.Companies();
            var GetUsers = data.Users();

            viewModel.ProductCount = GetProducts.Count;
            viewModel.BranchCount = GetBranches.Count;
            viewModel.CompanyCount = GetCompies.Count;
            viewModel.UserCount = GetUsers.Count;

            viewModel.CenterGrid.Children.Add(dashboard);


        }
        public override void Timer_Tick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
