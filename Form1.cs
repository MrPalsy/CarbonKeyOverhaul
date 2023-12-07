using System.Configuration;
using System.Data;

namespace CarbonKeyOverhaul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void supplierbtn_Click(object sender, EventArgs e)
        {
            string textboxContent = textBox1.Text;

            DbConnector dbConnector = new DbConnector("MyConnectionString");
            DataTable dataTable = dbConnector.ExecuteQuery("DECLARE @MyList TABLE (Value NVARCHAR(50))\r\nINSERT INTO @MyList VALUES ('" + textboxContent + "')\r\n\r\nDECLARE @value VARCHAR(50)\r\n\r\nDECLARE db_cursor CURSOR FOR  \r\nSELECT Value FROM @MyList\r\nOPEN db_cursor   \r\nFETCH NEXT FROM db_cursor INTO @value   \r\n\r\nWHILE @@FETCH_STATUS = 0   \r\nBEGIN   \r\n --      PRINT @value\r\n\r\n       -- PUT YOUR LOGIC HERE\r\n       -- MAKE USE OR VARIABLE @value wich is Data1, Data2, etc...\r\n\t   SELECT \r\n\t  a.UNSPSC_UNSPSCClassDescription\r\n\t  ,a.UNSPSC_UNSPSCClassID\r\n\t  ,a.Supplier_SupplierName\r\n\t  ,a.Supplier_SupplierID\r\n      ,sum(a.SumOfLineAmount) as [LineAmount]\r\n      ,sum(a.SpendAnalysisLines_InvoicedQuantity) as [InvoicedQuantity]\r\n\t  ,convert(decimal(30,10),count(*)) as InvoiceLines\r\n\t  ,(sum(a.SumOfLineAmount)/j.TotalLineAmount)*100 as PercentageLineAmount\r\n\t  ,(sum(a.SpendAnalysisLines_InvoicedQuantity)/j.TotalInvoicedQuantity)*100 as PercentageInvoicedQuantity\r\n\t  ,(convert(decimal(30,10),count(*))/j.TotalInvoiceLines)*100 as PercentageInvoiceLines\r\n\r\n  FROM [dbo].[JonathanCSV] a\r\n  left join (\r\n\t\t      SELECT \r\n\t\t\t  sum(a.SumOfLineAmount) as [TotalLineAmount]\r\n\t\t\t  ,sum(a.SpendAnalysisLines_InvoicedQuantity) as [TotalInvoicedQuantity]\r\n\t          ,convert(decimal(30,10),count(*)) as TotalInvoiceLines\r\n\t\t\t  FROM [dbo].[JonathanCSV] a\t\t  \r\n\t\t\t  where 1 = 1\r\n\t\t\t  and a.UNSPSC_UNSPSCClassID = @value\r\n\t\t\t  )  j on 1 = 1\r\n  where 1 = 1\r\n  and a.UNSPSC_UNSPSCClassID = @value\r\n  group by\r\n  a.UNSPSC_UNSPSCClassDescription\r\n ,a.UNSPSC_UNSPSCClassID\r\n ,a.Supplier_SupplierName\r\n ,a.Supplier_SupplierID\r\n ,j.TotalLineAmount\r\n ,j.TotalInvoicedQuantity\r\n ,j.TotalInvoiceLines\r\n  order by 5 desc\r\n\r\n       FETCH NEXT FROM db_cursor INTO @value   \r\nEND   \r\n\r\nCLOSE db_cursor   \r\nDEALLOCATE db_cursor");
            dataGridView1.DataSource = dataTable;
            DataGridViewButtonColumn dataGridviewButtonColumn = new DataGridViewButtonColumn();
            dataGridviewButtonColumn.Text = "Invoice Data";
            dataGridView1.Columns.Insert(0, dataGridviewButtonColumn);
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in the desired column and row type
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 0) // Assuming the button column is at index 0
            {
                e.Value = "Invoice Data"; // Set the text you want to display on the button
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string textboxContent = textBox1.Text;
            string supplierName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            // Check if the clicked cell is a button cell and the column index matches the button column
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                // Create an instance of invoiceDataForm
                invoiceDataForm form2 = new invoiceDataForm(textboxContent,supplierName);

                // Show invoiceDataForm
                form2.Show();
            }
        }
    }
}