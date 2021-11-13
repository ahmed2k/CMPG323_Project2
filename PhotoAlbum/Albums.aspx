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
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Store user" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AlbumID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="AlbumID" HeaderText="AlbumID" ReadOnly="True" SortExpression="AlbumID" />
                    <asp:BoundField DataField="Album_Name" HeaderText="Album_Name" SortExpression="Album_Name" />
                    <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ImageGalleryConnectionString1 %>" DeleteCommand="DELETE FROM [Albums] WHERE [AlbumID] = @AlbumID" InsertCommand="INSERT INTO [Albums] ([Album_Name], [User]) VALUES (@Album_Name, @User)" SelectCommand="SELECT [AlbumID], [Album_Name], [User] FROM [Albums]" UpdateCommand="UPDATE [Albums] SET [Album_Name] = @Album_Name, [User] = @User WHERE [AlbumID] = @AlbumID">
                <DeleteParameters>
                    <asp:Parameter Name="AlbumID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Album_Name" Type="String" />
                    <asp:Parameter Name="User" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Album_Name" Type="String" />
                    <asp:Parameter Name="User" Type="String" />
                    <asp:Parameter Name="AlbumID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="images.aspx">view images</asp:HyperLink>
            <br />
            <br />
&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
