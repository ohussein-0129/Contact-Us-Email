<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInput.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.1.1.js"></script>
    <title>Send Email</title>
    <link rel="stylesheet" type="text/css" href="css/StyleSheet.css" />
 </head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server">Contact Us</asp:Label>
        <p>
            <asp:Label ID="LabelName" runat="server" CssClass="label">Your Name</asp:Label>
            <asp:TextBox ID="Name" runat="server" CssClass="tbox"></asp:TextBox>
            <asp:CustomValidator ID="ValidateName" ControlToValidate="Name" ValidateEmptyText="true" runat="server" ErrorMessage="Empty Name" Display="Dynamic" ClientValidationFunction="validateName" OnServerValidate="ValidateName_ServerValidate" CssClass="val"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelEmail" runat="server" CssClass="label">Your Email</asp:Label>
            <asp:TextBox ID="Email" runat="server" CssClass="tbox"></asp:TextBox>
            <asp:CustomValidator ID="ValidateEmail" ControlToValidate="Email" runat="server" ValidateEmptyText="true" ErrorMessage="Email is not valid" Display="Dynamic" OnServerValidate="ValidateEmail_ServerValidate" CssClass="val"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelSubject" runat="server" CssClass="label">Subject</asp:Label>
            <asp:TextBox ID="Subject" runat="server" CssClass="tbox"></asp:TextBox>
            <asp:CustomValidator ID="ValidateSubject" runat="server" ErrorMessage="Empty Subject" ValidateEmptyText="true" OnServerValidate="ValidateSubject_ServerValidate" ClientValidationFunction="validateSubject" Display="Dynamic" CssClass="val"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelMessage" runat="server" >Your Message<br /></asp:Label>
            <asp:TextBox ID="Msg" TextMode="MultiLine" Rows="20" Width="300" runat="server" Wrap="True"></asp:TextBox>
            <asp:CustomValidator ID="ValidateBody" ControlToValidate="Msg" runat="server" ValidateEmptyText="true" ErrorMessage="Message cannot be empty" OnServerValidate="ValidateBody_ServerValidate" ClientValidationFunction="validateMsg" CssClass="val"></asp:CustomValidator>
        </p>
        <asp:FileUpload ID="fileUp" runat="server" AllowMultiple="false"/> <br />
        <asp:Button ID="bSend" runat="server" Text="Submit" OnClick="bSend_Click" />
    </div>
    </form>
    <script src="js/cl_validate.js"></script>
    <script src="js/styling_javascript.js"></script>
</body>
</html>
