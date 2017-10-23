using System;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Inherits the Page class in System.Web.UI namespace
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// Automatically called once this page has loaded, the function contents is empty
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //empty
    }



    /// <summary>
    /// Called once the sumbit button has been clicked
    /// In the end it will send an email if all the fields have been filled properly
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bSend_Click(object sender, EventArgs e)
    {
        //checks if validation has passed
        if(IsValid)
        {
            //MailMessage class
            MailMessage mailmsg = new MailMessage();
            mailmsg.Subject = this.Subject.Text;
            mailmsg.IsBodyHtml = true;

            LinkedResource image = new LinkedResource(Server.MapPath("~/image/business-company-logo-27438277.jpg")); 

            string message = generateMessage(this.Msg.Text, this.Email.Text, this.Name.Text);
            string body = string.Format(@"{0}
                                        <img style='height: 180px; width: 300px' src=""cid:{1}""/>"
                                        , message, image.ContentId); //'@' before the string used so that all of the backslash escapes in the file path.

            AlternateView view = AlternateView.CreateAlternateViewFromString(body, null, "text/html"); //could have plain/text format version before this.
            view.LinkedResources.Add(image);
            mailmsg.AlternateViews.Add(view); //adds the AlternateView;


            string filePath = ""; //string filePath to an empty string. when checking whether there is an uploaded file, there will be no need to check if the string object is null.
            FileUpload fileAtt = this.fileUp;
            Attachment att = null;
            if (fileAtt.HasFiles)
            {
                //if there is a uploaded file
                filePath = Server.MapPath("~/uploads/" + this.fileUp.FileName);
                fileAtt.SaveAs(filePath);
                att = new Attachment(filePath); 
                mailmsg.Attachments.Add(att); //add the uploaded file as a attachment
            }

            mailmsg.From = new MailAddress("from@gmail.com", "Name Surname"); //the sender
            mailmsg.To.Add(new MailAddress("to@gmail.com", "Name Surname")); //the receiver, could also add a carbon copy using "mailMessage.CC"

            SmtpClient sc = new SmtpClient();
            try
            {
                //most of this could be done in the Web.config file under system.net -> mailSettings tags
                sc.DeliveryMethod = SmtpDeliveryMethod.Network; 
                sc.EnableSsl = true; //enables secure socket layer
                sc.Host = "smtp.gmail.com"; //gmail
                sc.Port = 25; //most will use port 25, it's best to check which port does the provider use
                sc.Credentials = new NetworkCredential("from@gmail.com", "password"); //email and password for the sender, email provider may block it. There should be an option to allow less secure connections.
                sc.Send(mailmsg); //sends the email

            }
            catch (SmtpException smtpException)
            {
                System.Diagnostics.Debug.WriteLine("Email Provider may be blocking access"); //Email providors normally block it as this is a less secure connection (i.e the password is visible in the source code, refer to 'NetworkCredential' on line 75)
                System.Diagnostics.Debug.WriteLine(smtpException.Message); //There can be other causes so a message is also displayed 
            }
            finally
            {
                //release resources used and delete uploaded file if it exists
                if (sc != null) sc.Dispose();
                if (image != null) image.Dispose();
                if (view != null) view.Dispose();
                if (att != null) att.Dispose();
                if (mailmsg != null) mailmsg.Dispose();
                if (File.Exists(filePath)) File.Delete(filePath); //deletes uploaded file if it exists
            }
        }
    }


    /// <summary>
    /// The html bodyis stored in the text file, the params are used to replace anything in the double square braces
    /// this will make up most of the body (except for the image)
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="email"></param>
    /// <param name="name"></param>
    /// <returns>String</returns>
    protected string generateMessage(string msg, string email, string name)
    {
        msg = msg.Replace("\n", "<br>"); //change to the html version of new line
        string final_body = File.ReadAllText(Server.MapPath("~/emailTemplate.txt"));
        final_body = final_body.Replace("[[MsgBody]]", msg).Replace("[[SenderEmail]]", email).Replace("[[SenderName]]", name);
        return final_body;
    }

    /// <summary>
    /// this will validate the name field which is call by the custom validator
    /// checks if the text field is empty
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void ValidateName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(this.Name.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    /// <summary>
    /// this will validate the email field which is call by the custom validator
    /// checks if email is valid
    /// an empty field will also throw error however it would be an invalid email
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void ValidateEmail_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (new EmailAddressAttribute().IsValid(this.Email.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    /// <summary>
    /// this will validate the name field which is call by the custom validator
    /// checks if the text area is empty
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void ValidateBody_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(this.Msg.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    /// <summary>
    /// this will validate the name field which is call by the custom validator
    /// checks if the text field is empty
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void ValidateSubject_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(this.Subject.Text))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
}

