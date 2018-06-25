<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadPhotos.aspx.cs" Inherits="bogleaspx_UploadPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">
  <style type="text/css">
         #up1
        {
            position:absolute;
           left:150px;
           top:640px;
        }
  </style>
    <div id="up1">
         <div id="UpPhfirst">
            <asp:Label ID="Label1" runat="server" Text="上传图片个数"></asp:Label>
            <asp:TextBox ID="txtcount" runat="server"></asp:TextBox>
            <asp:Button ID="btnset" runat="server" Text ="设置" onclick="btnset_Click"/>
            <asp:Button ID="btnupdown" runat="server" Text="上传图片" 
                 onclick="btnupdown_Click" />
        </div>

        <div id ="UpGridview">
            <asp:GridView ID="gvPic" runat="server" Height="189px" Width="855px" 
        AutoGenerateColumns="False" onrowdatabound="gvPic_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblPicAdress" runat="server" Font-Size="Large" ForeColor="#f7fa01" Text="图片源"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:FileUpload ID="fuphotoAdress" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblPicName" runat="server" Font-Size="Large" ForeColor="#f7fa01" Text="标题"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"  ControlToValidate="txtName" ErrorMessage="不能为空" ForeColor="Red"   ValidationGroup="a"></asp:RequiredFieldValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblPicAbout" runat="server" Font-Size="Large" ForeColor="#f7fa01"  Text="描述"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtAbout" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAbout" runat="server"    ControlToValidate="txtAbout" ErrorMessage="不能为空" ForeColor="Red"  ValidationGroup="a"></asp:RequiredFieldValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblPicClass" runat="server" Font-Size="Large" ForeColor="#f7fa01"  Text="相册"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlClass" runat="server" Width ="50px" >
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        </div>
</div>
</asp:Content>

