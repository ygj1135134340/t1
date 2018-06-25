<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="discussBolge.aspx.cs" Inherits="bogleaspx_discussBolge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">
    <style type="text/css">
         #ds1
        {
            position:absolute;
           left:150px;
           top:640px;
          width: 864px;
          height: 134px;
      }
          #bs2
        {
            position:absolute;
           left:150px;
           top:810px;
        }
          #ds3
        {
            position:absolute;
           left:150px;
           top:1109px;
        }
  </style>
   <div id="ds1">
      <div style=" background:#fae0e0; color :Black ; text-align :center ; font-size :large ; font-weight :bold ;">
          <asp:Label ID="Label1" runat="server" Text="日志"></asp:Label></div>
      <div>
            <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label>
      </div>
           
      <div>
           <asp:Label ID="lbltime" runat="server" Text="">
           </asp:Label><asp:LinkButton ID="lbtnname"  runat="server"></asp:LinkButton>
      </div>
      <div>
          <asp:Label ID="lbldetails" runat="server" Text=""></asp:Label>
      </div>
      <div>
        <!--  <asp:Label ID="lbldiscussd" ForeColor ="red" runat="server" Text=""></asp:Label>
          <asp:Label ID="lblclick" ForeColor ="red"  runat="server" Text=""></asp:Label>-->
      </div>
  </div>
      <div id="bs2">
          <asp:Repeater ID="Repeater1" runat="server" 
              onitemcommand="Repeater1_ItemCommand">
               <ItemTemplate >
                   <asp:Label ID="lblfloor" runat="server" Text="评论"></asp:Label><br>
                   <asp:Label ID="lblNowtime" runat="server" Text='<%# Eval("commenttime")%>'>'></asp:Label>
                   <asp:Label ID="lblvisitorname" runat="server" Text='<%# Eval("commentname ")%>' ></asp:Label><br />
                   <asp:Label ID="lblNowdetail" runat="server" Text='<%# Eval("comments") %>'></asp:Label>
               </ItemTemplate>
               <SeparatorTemplate>
                    <hr />
                </SeparatorTemplate>
          </asp:Repeater>
          <br />

      </div>
      <div id="ds3" style=" text-align :center ; font-size :large ; font-weight :bold;">
          <div><asp:Label ID="Label2" runat="server" Text="评论"></asp:Label></div>
          <asp:TextBox ID="txtdiscuss" runat="server" TextMode="MultiLine" 
              Height="99px" Width="531px"></asp:TextBox><br />
          <asp:CheckBox ID="CheckBoxdiscuss" runat="server"  Text ="匿名选项"/>
          <br />
          &nbsp;<asp:Button ID="btnsubmit" runat="server" Text="提交评论" 
              ForeColor ="#6e0d0d"  Font-Size="Large" Font-Bold="True" 
              onclick="btnsubmit_Click" />

      </div>
</asp:Content>

