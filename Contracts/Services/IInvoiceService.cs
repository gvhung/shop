﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Shop.Contracts.Entities;

namespace Shop.Contracts.Services
{
    [ServiceContract]
    public interface IInvoiceService
    {
        [OperationContract]
        void AddInvoice(Invoice invoice, IEnumerable<InvoiceItem> items, decimal payment);

        [OperationContract]
        void AddReceipt(Invoice invoice, IEnumerable<InvoiceItem> items);

        [OperationContract]
        IEnumerable<InvoiceItem> GetInvoiceItems(Guid invoiceId);
    }
}
