﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Shop.Contracts.Entities;
using Shop.Contracts.Services;
using Shop.Management.Messages;

namespace Shop.Management.ViewModels
{
    public class StockReceiptViewModel : Screen
    {
        public StockReceiptViewModel(IEventAggregator eventAggregator, IProductService productService)
        {
            EventAggregator = eventAggregator;
            ProductService = productService;
        }

        public IEventAggregator EventAggregator { get; private set; }

        public IProductService ProductService { get; private set; }

        public Product Product { get; set; }

        #region Code Property

        private string _Code;

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                if (value != _Code)
                {
                    _Code = value;
                    NotifyOfPropertyChange(() => Code);
                }
            }
        }

        #endregion

        #region Description Property

        private string _Description;

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (value != _Description)
                {
                    _Description = value;
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }

        #endregion

        #region Quantity Property

        private int _Quantity;

        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                if (value != _Quantity)
                {
                    _Quantity = value;
                    NotifyOfPropertyChange(() => Quantity);
                }
            }
        }

        #endregion

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Code = Product.Code;
            Description = Product.Description;
            Quantity = 0;
        }

        public void Save()
        {            
            var movement = new ProductMovement
            {
                Id = Guid.NewGuid(),
                ProductId = Product.Id,
                DateTime = DateTimeOffset.Now,
                MovementType = ProductMovementType.Receipt,
                Quantity = Quantity
            };

            ProductService.AddMovement(movement);

            Close();
        }

        public void Cancel()
        {
            Close();
        }

        public void Close()
        {
            EventAggregator.Publish(new DeactivateItem { Item = this });
        }
    }
}
