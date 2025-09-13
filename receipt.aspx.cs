using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.tool.xml;


namespace Pratice1
{
    public partial class receipt : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                ClearDetails();
                
            }
        }

        
        protected void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEmployeeID.Text, out int employeeID))
            {
                FetchEmployeeDetails(employeeID);
            }
            else
            {
                ClearDetails();
            }
        }

        private void balance()
        {
            string s = "select sum(Fees) as Bal from receipt where Email='" + lblEmail.Text + "'";
            SqlCommand c = new SqlCommand(s, conn);
            SqlDataReader r = c.ExecuteReader();

            if (r.HasRows)
            {
                r.Read();
                lblBalance.Text = r["Bal"].ToString();
            }
            else
            {
                lblBalance.Text = "0";
            }
        }

        private void showBal()
        {
            string s = "select top 1 * from receipt where Email='" + lblEmail.Text + "' order by Balance";
            SqlCommand c = new SqlCommand(s, conn);
            SqlDataReader r = c.ExecuteReader();

            if (r.HasRows)
            {
                r.Read();
                lblBal.Text = r["Balance"].ToString();
            }
            else
            {
                lblBal.Text = "30000";
            }
        }

        private void FetchEmployeeDetails(int employeeID)
        {

            string query = "SELECT id,Fees,Name, Email, Contact, Date FROM emptbl WHERE id = '" + employeeID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblId.Text = reader["id"].ToString();
                        lblName.Text = reader["Name"].ToString();
                        lblEmail.Text = reader["Email"].ToString();
                        lblContact.Text = reader["Contact"].ToString();
                        lblFees.Text = reader["Fees"].ToString();
                        
                        showBal();
                        balance();
                    }
                    else
                    {
                        ClearDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // lblError.Text = "Error occurred: " + ex.Message;
            }

        }

        private void ClearDetails()
        {
            lblName.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblContact.Text = string.Empty;
            //lblDate.Text = string.Empty;
            txtPaid.Text = string.Empty;
            lblBalance.Text = string.Empty;
        }

        protected void btnSendReceipt_Click(object sender, EventArgs e)
        {
            
            double bal;
            if ((lblBalance.Text).Equals(""))
            {
                bal = double.Parse(lblFees.Text) - double.Parse(txtPaid.Text);

                string q = "insert into receipt(Name,Contact,Email,Date,Fees,Balance) values('" + lblName.Text + "','" + lblContact.Text + "','" + lblEmail.Text + "','" + TextBox1.Text + "','" + txtPaid.Text + "','" + bal + "')";
                SqlCommand c = new SqlCommand(q, conn);
                c.ExecuteNonQuery();
                balance();
                
            }
            else
            {
                //showBal();
                //if (double.Parse(txtPaid.Text)> double.Parse(lblBal.Text))
                //{
                //    Response.Write("<script>alert('enter fees again');window.location.href='receipt.aspx';</script>");
                //}
                //else
                //{
                    bal = double.Parse(lblFees.Text) - double.Parse(lblBalance.Text) - double.Parse(txtPaid.Text);

                    string q = "insert into receipt(Name,Contact,Email,Date,Fees,Balance) values('" + lblName.Text + "','" + lblContact.Text + "','" + lblEmail.Text + "','" + TextBox1.Text + "','" + txtPaid.Text + "','" + bal + "')";
                    SqlCommand c = new SqlCommand(q, conn);
                    c.ExecuteNonQuery();
                    balance();
                //}
                
                
            }
            showBal();
            //int balance = 30000 - int.Parse(txtPaid.Text);
            string s = @"
<style>
body {
  font-family: Arial, sans-serif;
  background-color: #f4f4f4;
  padding: 20px;
}

.invoice {
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  padding: 30px;
  max-width: 600px;
  margin: 0 auto;
}

.invoice-header {
  border-bottom: 2px solid #f1f1f1;
  padding-bottom: 20px;
  margin-bottom: 20px;
}

.invoice-header h1 {
  font-size: 28px;
  margin: 0;
}

.invoice-info {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
}

.invoice-info p {
  margin: 5px 0;
}

.invoice-table {
  width: 100%;
  border-collapse: collapse;
  margin-bottom: 20px;
}

.invoice-table th, .invoice-table td {
  padding: 10px;
  border-bottom: 1px solid #f1f1f1;
}

.invoice-table th {
  background-color: #f1f1f1;
}

.invoice-total {
  display: flex;
  justify-content: space-between;
  font-weight: bold;
}

.footer {
  margin-top: 20px;
  text-align: center;
  color: #888;
}
</style>
<body>
<div class='invoice'>
<div class='invoice-header'>
<h1 align='center'>Fees Receipt</h1>
<div class='invoice-info'>
<p><strong>Invoice Number:</strong> INV-00"+ $"{lblId.Text}" + @"</p>
<p><strong>Name:</strong> " + $"{lblName.Text}" + @"</p>
<p><strong>Date:</strong> " + $"{TextBox1.Text}" + @"</p>
</div>
<div class='invoice-info'>
<p><strong>Email ID:</strong>" + $"{lblEmail.Text}"+@"</p>
<p><strong>Contact No:</strong> "+$"{lblContact.Text}"+@"</p>
</div>
</div>
<table class='invoice-table'>
<thead>
<tr>
<th>Course</th>
<th>Total Fees</th>
<th>Paid Fees</th>
<th>Balance Fees</th>
</tr>
</thead>
<tbody>
<tr>
<td>Dot Net Full Stack Developer</td>
<td>30000</td>
<td>"+$"{txtPaid.Text}"+@"</td>
<td>"+$"{lblBal.Text}"+@"</td>
</tr>
</tbody>
</table>
<div class='invoice-total'>
<p><strong>Total Paid Fees:</strong></p>
<p>"+$"{lblBalance.Text}"+@"</p>
</div>
<div class='footer'>
<p>Feel Free to Connect Krish Kheloji(7208921898)!</p>
</div>
</div></body>";


            byte[] pdfBytes = GeneratePdfFromHtml(s);    

            // Send email with PDF attachment
            SendEmailWithAttachment(pdfBytes);
        }

        private byte[] GeneratePdfFromHtml(string htmlContent)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                using (StringReader stringReader = new StringReader(htmlContent))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, stringReader);
                }

                document.Close();
                return memoryStream.ToArray();
            }
        }

        private void SendEmailWithAttachment(byte[] attachmentBytes)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("khelojikrish@gmail.com");
            mailMessage.To.Add(lblEmail.Text);
            mailMessage.Subject = "Fees Receipt";
            mailMessage.Body = "Please find the Fees Receipt attachment.";
            mailMessage.IsBodyHtml = true;

            // Attach PDF
            MemoryStream stream = new MemoryStream(attachmentBytes);
            mailMessage.Attachments.Add(new Attachment(stream, "Receipt.pdf", "application/pdf"));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("khelojikrish@gmail.com", "pcrluqlodjnnhgmj");
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
            finally
            {
                // Clean up resources
                stream.Dispose();
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayEmp.aspx");
        }
    }
}