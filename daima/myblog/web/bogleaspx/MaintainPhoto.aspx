<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaintainPhoto.aspx.cs" Inherits="bogleaspx_MaintainPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 116px;
        }
        .style2
        {
            width: 286px;
        }
         #pho1
        {
            position:absolute;
           left:170px;
           top:640px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">
    <div id="pho1">
        <table style="height: 143px; width: 765px ; background-color :#1b1b1b;">
             <tr >
                <th class="style2"></th>
                <th></th>
                <th class="style1"></th>
             </tr>
             <tr>
                 <td colspan="3" id="MaintainPhotoGridview">
                     <asp:GridView ID="GVwMaintainPhoto" runat="server" Width="768px" 
                         AutoGenerateColumns="False" DataKeyNames="photoalbumID" 
                         onrowcancelingedit="GVwMaintainPhoto_RowCancelingEdit" 
                         onrowdeleting="GVwMaintainPhoto_RowDeleting" 
                         onrowediting="GVwMaintainPhoto_RowEditing" 
                         onrowupdating="GVwMaintainPhoto_RowUpdating" BackColor="#333333">
                         <Columns>
                             <asp:TemplateField HeaderText="名称">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("photobumName") %>' ForeColor="White"></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("photobumName") %>' ForeColor="White"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="描述">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("photobumcribe") %>' ForeColor="White"></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("photobumcribe") %>' ForeColor="White"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:CommandField ShowEditButton="True" HeaderText="编辑列"  >
                             <ControlStyle Width="30px" ForeColor="White" />
                             </asp:CommandField>
                             <asp:CommandField ShowDeleteButton="True" HeaderText="删除列"  >
                             <ControlStyle Width="30px" ForeColor="White" />
                             </asp:CommandField>
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
             <tr>
             <td class="style2">
                 <asp:TextBox ID="txtphotoname" runat="server"></asp:TextBox>
                 </td>
             <td>
                 <asp:TextBox ID="txtcribe" runat="server"></asp:TextBox>
                 </td>
             <td class="style1">
                 <asp:Button ID="btnadd" runat="server" Text="添加" onclick="btnadd_Click" /></td>
             </tr>


             
        </table>
    </div>
    
</asp:Content>

