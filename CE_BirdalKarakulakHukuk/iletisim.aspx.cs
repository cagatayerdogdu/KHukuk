using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace CE_KarakulakHukuk
{
    public partial class iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage(); 
            //mail.IsBodyHtml = true; 
            mail.To.Add("info@karakulakhukuk.com");
            
            mail.From = new MailAddress("sitemailgonderimi@karakulakhukuk.com", "Site Üzerinden Gelen Mesaj", System.Text.Encoding.UTF8);
            mail.Subject = txtKonu.Text;    //"Siteden Gelen Mesaj - " +

            //Label lbl = new Label();
            //lbl.Visible = false;
            //lbl.Text = @"Mesaj Atan Kullanıcı E-Posta:  " + txtEMail.Text +
            //            "İsim: " + txtAdi.Text +
            //            "Konu: " + txtKonu.Text +
            //            "Içerik: " + txtMesaj.InnerText;

            string MailIcerik = "Mesaj Atan Kullanıcı E-Posta:  " + txtEMail.Text + Environment.NewLine + "İsim: " + txtAdi.Text + Environment.NewLine + "Konu: " + txtKonu.Text + Environment.NewLine + "Içerik: " + txtMesaj.InnerText;
            //@"Mesaj Atan Kullanıcı E-Posta:  " + txtEMail.Text +
            //                "\r\n\r\nİsim: " + txtAdi.Text +
            //                "\r\n\r\nKonu: " + txtKonu.Text +
            //                "\r\n\r\nIçerik: " + txtMesaj.InnerText;

            mail.Body = MailIcerik;
            mail.IsBodyHtml = true;
            SmtpClient stmp = new SmtpClient("mail.karakulakhukuk.com");// "mail.karakulakhukuk.com"

            stmp.Credentials = new System.Net.NetworkCredential("sitemailgonderimi@karakulakhukuk.com", "AVukat12");  //"sitemailgonderimi@karakulakhukuk.com", "AVukat12" //"karakulakhukuk@gmail.com","Seymabirdal1234"
            stmp.Port = 587;
            //stmp.Host = "smtp.gmail.com";
            //stmp.UseDefaultCredentials = false;
            //stmp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //stmp.EnableSsl = true;
            stmp.Send(mail);

            ClientScript.RegisterClientScriptBlock(typeof(Page), DateTime.Now.Ticks.ToString(), "setTimeout(function(){alert('Mesajınız başarıyla gönderilmiştir.');},1000);", true);

            txtAdi.Text = "";
            txtKonu.Text = "";
            txtEMail.Text = "";
            txtMesaj.InnerText = "";
        }
    }
}