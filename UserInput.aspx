<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInput.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.1.1.js"></script>
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
 </head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server">Contact Us</asp:Label>
        <p>
            <asp:Label ID="LabelName" runat="server" CssClass="label">Your Name</asp:Label>
            <asp:TextBox ID="Name" runat="server" CssClass="tbox"></asp:TextBox>
            <asp:CustomValidator ID="ValidateName" ControlToValidate="Name" ValidateEmptyText="true" runat="server" ErrorMessage="Empty Name" Display="Dynamic" ClientValidationFunction="validateName" OnServerValidate="ValidateName_ServerValidate"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelEmail" runat="server" CssClass="label">Your Email</asp:Label>
            <asp:TextBox ID="Email" runat="server" CssClass="tbox"></asp:TextBox>
            <asp:CustomValidator ID="ValidateEmail" ControlToValidate="Email" runat="server" ValidateEmptyText="true" ErrorMessage="Email is not valid" Display="Dynamic" OnServerValidate="ValidateEmail_ServerValidate"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelSubject" runat="server" CssClass="label">Subject</asp:Label>
            <asp:TextBox ID="Subject" runat="server" CssClass="tbox"></asp:TextBox>
            <asp:CustomValidator ID="ValidateSubject" runat="server" ErrorMessage="Empty Subject" ValidateEmptyText="true" OnServerValidate="ValidateSubject_ServerValidate" ClientValidationFunction="validateSubject" Display="Dynamic"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelMeassage" runat="server" CssClass="msgLabel">Your Message<br /></asp:Label>
            <asp:TextBox ID="Msg" TextMode="MultiLine" Rows="20" Width="300" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="ValidateBody" ControlToValidate="Msg" runat="server" ValidateEmptyText="true" ErrorMessage="Message cannot be empty" OnServerValidate="ValidateBody_ServerValidate" ClientValidationFunction="validateMsg"></asp:CustomValidator>
        </p>
        <asp:Button ID="bSend" runat="server" Text="Submit" OnClick="bSend_Click"/>
    </div>
    </form>
    <script src="cl_validate.js"></script>
    <script src="styling_javascript.js"></script>
</body>
</html>
