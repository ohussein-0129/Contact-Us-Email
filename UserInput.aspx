<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInput.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.1.1.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <script src="cl_validate.js"></script>

        <asp:Label ID="Label1" runat="server" Text="Contact Us"></asp:Label>
        <p>
            <asp:Label ID="LabelName" runat="server">Your Name</asp:Label>
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="ValidateName" ControlToValidate="Name" ValidateEmptyText="true" runat="server" ErrorMessage="Empty Name" Display="Dynamic" ClientValidationFunction="validateName" OnServerValidate="ValidateName_ServerValidate"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelEmail" runat="server">Your Email</asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="ValidateEmail" ControlToValidate="Email" runat="server" ValidateEmptyText="true" ErrorMessage="Email is not valid" Display="Dynamic" OnServerValidate="ValidateEmail_ServerValidate"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelSubject" runat="server">Subject</asp:Label>
            <asp:TextBox ID="Subject" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="ValidateSubject" runat="server" ErrorMessage="Empty Subject" ValidateEmptyText="true" OnServerValidate="ValidateSubject_ServerValidate" ClientValidationFunction="validateSubject" Display="Dynamic"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="LabelMeassage" runat="server">Your Message:<br /></asp:Label>
            <asp:TextBox ID="Msg" TextMode="MultiLine" Rows="20" Width="300" runat="server" CssClass="msg_box"></asp:TextBox>
            <asp:CustomValidator ID="ValidateBody" ControlToValidate="Msg" runat="server" ValidateEmptyText="true" ErrorMessage="Message cannot be empty" OnServerValidate="ValidateBody_ServerValidate" ClientValidationFunction="validateMsg"></asp:CustomValidator>
        </p>
        <asp:Button ID="bSend" runat="server" Text="Submit" OnClick="bSend_Click"/>

    </div>
    </form>
</body>
</html>
