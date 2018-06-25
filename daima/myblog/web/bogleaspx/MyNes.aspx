<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyNes.aspx.cs" Inherits="bogleaspx_MyNes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        .style2
        {
            width: 376px;
        }
        .style3
        {
            width: 81px;
        }
        .style4
        {
            width: 81px;
            height: 146px;
        }
        .style5
        {
            width: 376px;
            height: 146px;
        }
        .style6
        {
            width: 81px;
            height: 160px;
        }
        .style7
        {
            width: 376px;
            height: 160px;
        }
         #gr1
        {
            position:absolute;
           left:170px;
           top:640px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">

<div id="gr1">

           <table id="MyNesbogle"  >
                   
                   <tr>
                       <td class="style3">博客名称
                       </td>
                       <td class="style2">
                           <asp:TextBox ID="txtname" runat="server" Width="194px"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                               ErrorMessage="博客名称不能为空" ControlToValidate="txtname"  ForeColor="#ff0000"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td class="style4" >博客描述
                       </td>                      
                       <td class="style5"> 
                           <asp:TextBox ID="txtdescribe" runat="server" Rows="3" TextMode="MultiLine" 
                               Width="194px" Height="91px"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                               ErrorMessage="描述内容不能为空" ControlToValidate="txtdescribe"  ForeColor="#FF3300"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td class="style6">博客图像
                       </td>
                       <td id="MyNesiamge" class="style7">
                          <div> 
                              <br />
                              <asp:FileUpload ID="fulpath" runat="server" />
                              <br />
                           </div>
                           <asp:Image ID="Image1" runat="server" Height="148px" Width="141px" />
                           &nbsp;&nbsp;
                           <br />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                               ErrorMessage="请选择图片路径" ControlToValidate="fulpath"  ForeColor="#FF3300"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <th colspan="2" class="style1" style =" text-align :center" >
                           <asp:Button ID="Button1" runat="server" Text="保存" BackColor="Yellow" 
                               Width="56px" onclick="Button1_Click"  /></th>
                   </tr>
           </table>
 </div>

</asp:Content>

