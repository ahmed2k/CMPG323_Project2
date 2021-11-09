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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AlbumID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
                    <asp:BoundField DataField="AlbumID" HeaderText="AlbumID" ReadOnly="True" SortExpression="AlbumID" InsertVisible="False" />
                    <asp:BoundField DataField="Album_Name" HeaderText="Album_Name" SortExpression="Album_Name" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ImageGalleryConnectionString1 %>" DeleteCommand="DELETE FROM [Albums] WHERE [AlbumID] = @AlbumID" InsertCommand="INSERT INTO Albums([Album Name]) VALUES ('Gallery')" SelectCommand="SELECT [AlbumID], [Album Name] AS Album_Name FROM [Albums]" UpdateCommand="UPDATE [Albums] SET [Album Name] = @Album_Name WHERE [AlbumID] = @AlbumID">
                <DeleteParameters>
                    <asp:Parameter Name="AlbumID" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Album_Name" Type="String" />
                    <asp:Parameter Name="AlbumID" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                     <asp:Parameter Name="Album_Name" Type="String" />
                    <asp:Parameter Name="AlbumID" Type="Int32" />
                </InsertParameters>
            </asp:SqlDataSource>
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
