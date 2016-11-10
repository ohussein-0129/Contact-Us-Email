using System;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.ComponentModel.DataAnnotations;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void bSend_Click(object sender, EventArgs e)
    {
        if(IsValid==true)
        {
            MailMessage mailmsg = new MailMessage();
            mailmsg.Subject = this.Subject.Text;
            mailmsg.Body = generateBody(this.Msg.Text, this.Email.Text, this.Name.Text);
            mailmsg.IsBodyHtml = true;

            mailmsg.To.Add(new MailAddress("destination@gmail.com", "FirstName LastName"));
            SmtpClient scl = new SmtpClient();
            try
            {
                scl.Send(mailmsg);
            }
            catch (SmtpException)
            {
                System.Diagnostics.Debug.WriteLine("Email Provider may be blocking access");
            }
        }
    }
    
    protected string generateBody(string msg, string email, string name)
    {
        msg = msg.Replace("\n", "<br>");
        string final_body = "";
        StreamReader rd = null;

        try
        {
            rd = new StreamReader(Server.MapPath("~/EmailTemplate.html"));
            final_body = rd.ReadToEnd();
        }
        catch (IOException) {
            System.Diagnostics.Debug.WriteLine("Problem with reading HTML file");
        }
        finally
        {
            if (rd != null)
                rd.Dispose();
        }
        final_body = final_body.Replace("[[MsgBody]]", msg).Replace("[[SenderEmail]]", email).Replace("[[SenderName]]", name);
        return final_body;
    }

    protected void ValidateName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(this.Name.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    protected void ValidateEmail_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (new EmailAddressAttribute().IsValid(this.Email.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    protected void ValidateBody_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(this.Msg.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    protected void ValidateSubject_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(this.Subject.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
}

