<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="PhotoAlbum.Albums" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Albums<br />
            <br />
            <asp:GridView ID="albumGrid" runat="server">
            </asp:GridView>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="connect" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
