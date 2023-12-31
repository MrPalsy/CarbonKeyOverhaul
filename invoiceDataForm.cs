﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarbonKeyOverhaul
{
    public partial class invoiceDataForm : Form
    {
        private string unspscCategory;
        private string supplierName;


        public invoiceDataForm(string unspscCategory, string supplierName)
        {
            InitializeComponent();
            this.unspscCategory = unspscCategory;
            this.supplierName = supplierName;
            ShowInvoiceData(unspscCategory, supplierName);
            ShowInvoiceData2();
            ShowInvoiceDataDestinct();
        }

        private void ShowInvoiceData(string unspscCategory, string supplierName)
        {
            string query = "/*Declare Input to isolate wanted invoices*/\r\nDeclare @UNSPSCClassID nvarchar (10) = '" + unspscCategory + "'\r\nDeclare @SupplierName nvarchar (200) = '" + supplierName + "'\r\nDeclare @Municipality nvarchar (200) = 'Sønderborg Kommune'--'Samsø kommune'--'Odense kommune'--''Sønderborg Kommune'--'Samsø kommune'--\r\n\r\n\r\n--Sager der er opstartet faktureres 50%Sagsnummer:2022-97012022-92082022-103312022-10770\r\n\r\n/*Place to test modification rule*/\r\nIF OBJECT_ID(N'tempdb..#FactSpendAnalysisLines_Filtered') IS NOT NULL\r\nBEGIN\r\nDROP TABLE #FactSpendAnalysisLines_Filtered\r\nEND\r\n\r\n\r\nSELECT\r\n\t\ta.Date_YearMonthNumber\r\n\t\t,a.Supplier_SupplierName\r\n\t\t,a.UNSPSC_UNSPSCClassDescription\r\n\t\t,a.InvoiceLineItem_ItemDescription\r\n\t\t,a.InvoiceLineItem_ItemID\r\n\t\t,a.InvoiceLineItem_Unit\r\n\t\t,case when a.InvoiceLineItem_Unit = 'EA' and a.InvoiceLineItem_ItemDescription LIKE '%KG%' then 'KGM' else a.InvoiceLineItem_Unit end as [Quantity_Adjusted]\r\n\t\t,case when a.InvoiceLineItem_Unit = 'EA' AND a.InvoiceLineItem_ItemDescription LIKE '%Timer%' then 'HUR' else a.InvoiceLineItem_Unit end as [Unit_Adjusted]\r\n\t\t,a.SumOfLineAmount as LineAmount\r\n\t\t,a.SpendAnalysisLines_InvoicedQuantity as Invoiced_Quantity\r\n\t\t,a.Organization_OrganizationDescription\r\n\t\t--,a.*\r\n\t\t--,i.*\r\n\t\t--,c.*\r\n  into #FactSpendAnalysisLines_Filtered\r\n  FROM [dbo].[JonathanCSV] a\r\n  where 1 = 1\r\n and a.UNSPSC_UNSPSCClassID = @UNSPSCClassID\r\n  and a.Supplier_SupplierName = @SupplierName\r\n\r\n select * from #FactSpendAnalysisLines_Filtered\r\n order by LineAmount desc";

            DbConnector dbConnector = new DbConnector("MyConnectionString");
            DataTable dataTable = dbConnector.InvoiceDataQuery(query);
            dataGridInvoiceData.DataSource = dataTable;
        }
        private void ShowInvoiceData2()
        {
            DbConnector dbConnector = new DbConnector("MyConnectionString");
            string query2= "IF OBJECT_ID(N'tempdb..#FactSpendAnalysisLines_Filtered') IS NOT NULL\r\nBEGIN\r\nDROP TABLE #FactSpendAnalysisLines_Filtered\r\nEND\r\n\r\n\r\n\r\nSELECT\r\n\t\ta.Date_YearMonthNumber\r\n\t\t,a.Supplier_SupplierName\r\n\t\t,a.Supplier_SupplierID\r\n\t\t,a.UNSPSC_UNSPSCClassDescription\r\n\t\t,a.InvoiceLineItem_ItemDescription\r\n\t\t,a.InvoiceLineItem_ItemID\r\n\t\t,a.InvoiceLineItem_Unit\r\n\t\t,a.SumOfLineAmount\r\n\t\t,a.SpendAnalysisLines_InvoicedQuantity\r\n\t\t\t\t--,a.LineAmount/a.InvoicedQuantity as unitcost\r\n\t\t,a.Organization_OrganizationDescription\r\n\t\t--,i.*\r\n\t\t--,inv.*\r\n -- into #FactSpendAnalysisLines_Filtered\r\n  FROM [dbo].[JonathanCSV] a\r\n  where 1 = 1\r\n and a.UNSPSC_UNSPSCClassID ='" + unspscCategory + "'\r\n and a.Supplier_SupplierName ='" + supplierName + "'\r\n order by a.SumOfLineAmount desc";
            DataTable datatable2 = dbConnector.InvoiceDataQuery2(query2);
            dataGridInvoice2.DataSource = datatable2;

        }
        private void ShowInvoiceDataDestinct() 
        {
            DbConnector dbConnector = new DbConnector("MyConnectionString");
            string queryDestinct = "SELECT distinct\r\n\t\t--DW_SK_Date_SpendAnalysis\r\n\t\t--,c.GUID\r\n\t\t--,a.DW_SK_Invoice\r\n\t\ta.Supplier_SupplierName\r\n\t\t,a.UNSPSC_UNSPSCClassDescription\r\n\t\t,a.InvoiceLineItem_ItemDescription\r\n\t\t,a.InvoiceLineItem_ItemID\r\n\t\t,a.InvoiceLineItem_Unit\r\n\t\t--,a.LineAmount\r\n\t\t--,a.InvoicedQuantity\r\n\t\t--,o.OrganizationDescription\r\n\t\t--,e.*\r\n\t\t--,c.*\r\n\t\t--,p.*\r\n\r\n  FROM [dbo].[JonathanCSV] a\r\n  where 1 = 1\r\n and a.UNSPSC_UNSPSCClassID ='" + unspscCategory + "'\r\n and a.Supplier_SupplierName ='" + supplierName + "' \r\n";
            DataTable dataTableDestinct = dbConnector.InvoiceDataDestinct(queryDestinct);
            dataGridViewDestinct.DataSource = dataTableDestinct;
            dataGridViewDestinct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewDestinct.AutoResizeColumns();

        }

        private void suggestRuleBtn_Click(object sender, EventArgs e)
        {
            RuleSuggestionForm ruleSuggestionForm = new RuleSuggestionForm();
            ruleSuggestionForm.Show();
        }
    }
}
