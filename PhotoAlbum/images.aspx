<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="images.aspx.cs" Inherits="PhotoAlbum.images" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body style="height: 246px">
    <form id="form1" runat="server">
&nbsp;select image:
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ImageID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ImageID" HeaderText="ImageID" ReadOnly="True" SortExpression="ImageID" />
                <asp:BoundField DataField="ImagesName" HeaderText="ImagesName" SortExpression="ImagesName" />
                <asp:BoundField DataField="AlbumID" HeaderText="AlbumID" SortExpression="AlbumID" />
                <asp:BoundField DataField="capturedBy" HeaderText="capturedBy" SortExpression="capturedBy" />
                <asp:BoundField DataField="tags" HeaderText="tags" SortExpression="tags" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ImageGalleryConnectionString1 %>" DeleteCommand="DELETE FROM [Images] WHERE [ImageID] = @ImageID" InsertCommand="INSERT INTO [Images] ([ImagesName], [AlbumID], [capturedBy], [tags], [Location]) VALUES (@ImagesName, @AlbumID, @capturedBy, @tags, @Location)" SelectCommand="SELECT [ImageID], [ImagesName], [AlbumID], [capturedBy], [tags], [Location] FROM [Images]" UpdateCommand="UPDATE [Images] SET [ImagesName] = @ImagesName, [AlbumID] = @AlbumID, [capturedBy] = @capturedBy, [tags] = @tags, [Location] = @Location WHERE [ImageID] = @ImageID">
            <DeleteParameters>
                <asp:Parameter Name="ImageID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ImagesName" Type="String" />
                <asp:Parameter Name="AlbumID" Type="Int32" />
                <asp:Parameter Name="capturedBy" Type="String" />
                <asp:Parameter Name="tags" Type="String" />
                <asp:Parameter Name="Location" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ImagesName" Type="String" />
                <asp:Parameter Name="AlbumID" Type="Int32" />
                <asp:Parameter Name="capturedBy" Type="String" />
                <asp:Parameter Name="tags" Type="String" />
                <asp:Parameter Name="Location" Type="String" />
                <asp:Parameter Name="ImageID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
