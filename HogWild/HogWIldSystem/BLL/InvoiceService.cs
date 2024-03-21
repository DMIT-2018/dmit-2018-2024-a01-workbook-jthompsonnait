using HogWildSystem.DAL;
using HogWIldSystem.Entities;
using HogWIldSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogWIldSystem.BLL
{
    public class InvoiceService
    {
        #region Fields

        /// <summary>
        /// The hog wild context
        /// </summary>
        private readonly HogWildContext _hogWildContext;

        #endregion

        // Constructor for the WorkingVersionService class.
        internal InvoiceService(HogWildContext hogWildContext)
        {
            // Initialize the _hogWildContext field with the provided HogWildContext instance.
            _hogWildContext = hogWildContext;
        }

        public List<InvoiceView> GetCustomerInvoices(int customerId)
        {
            return _hogWildContext.Invoices
            .Where(x => x.CustomerID == customerId
            && !x.RemoveFromViewFlag)
            .Select(x => new InvoiceView
            {
                InvoiceID = x.InvoiceID,
                InvoiceDate = new DateTime(x.InvoiceDate.Year,
                                                            x.InvoiceDate.Month,
                                                            x.InvoiceDate.Day),
                CustomerID = x.CustomerID,
                SubTotal = x.SubTotal,
                Tax = x.Tax
            }).ToList();
        }


        //	Get the customer full name
        public string GetCustomerFullName(int customerID)
        {
            return _hogWildContext.Customers
                .Where(x => x.CustomerID == customerID)
                .Select(x => $"{x.FirstName} {x.LastName}").FirstOrDefault();
        }
        //	Get the employee full name
        public string GetEmployeeFullName(int employeeId)
        {
            {
                return _hogWildContext.Employees
                    .Where(x => x.EmployeeID == employeeId)
                    .Select(x => $"{x.FirstName} {x.LastName}").FirstOrDefault();
            }
        }

        // Get invoice
        public InvoiceView GetInvoice(int invoiceID, int customerID, int employeeID)
        {
            //	Handles both new and existing invoice
            //  For a new invoice the following information is needed
            //		Customer & Employee ID
            //  For a existing invoice the following information is needed
            //		Invoice & Employee ID (We maybe updating an invoice at a later date
            //			and we need the current employee who is handling the transaction.

            InvoiceView invoice = null;
            //  new invoice for customer
            if (customerID > 0 && invoiceID == 0)
            {
                invoice = new InvoiceView();
                invoice.CustomerID = customerID;
                invoice.EmployeeID = employeeID;
                invoice.InvoiceDate = DateTime.Now;
            }
            else
            {
                invoice = _hogWildContext.Invoices
                    .Where(x => x.InvoiceID == invoiceID
                     && !x.RemoveFromViewFlag
                    )
                    .Select(x => new InvoiceView
                    {
                        InvoiceID = invoiceID,
                        InvoiceDate = new DateTime(x.InvoiceDate.Year,
                                                            x.InvoiceDate.Month,
                                                            x.InvoiceDate.Day),
                        CustomerID = x.CustomerID,
                        EmployeeID = x.EmployeeID,
                        SubTotal = x.SubTotal,
                        Tax = x.Tax,
                        InvoiceLines = x.InvoiceLines
                                    .Select(x => new InvoiceLineView
                                    {
                                        InvoiceLineID = x.InvoiceLineID,
                                        InvoiceID = x.InvoiceID,
                                        PartID = x.PartID,
                                        Quantity = x.Quantity,
                                        Description = x.Part.Description,
                                        Price = x.Price,
                                        Taxable = (bool)x.Part.Taxable,
                                        RemoveFromViewFlag = x.RemoveFromViewFlag
                                    }).ToList()
                    }).FirstOrDefault();
                customerID = invoice.CustomerID;
            }
            invoice.CustomerName = GetCustomerFullName(customerID);
            invoice.EmployeeName = GetEmployeeFullName(employeeID);
            return invoice;
        }

    }
}
