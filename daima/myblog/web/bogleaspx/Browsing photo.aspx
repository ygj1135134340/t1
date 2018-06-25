<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Browsing photo.aspx.cs" Inherits="bogleaspx_Browsing_photo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">

<style type="text/css">
     #tp1
        {
            position:absolute;
           left:100px;
           top:640px;
        }
</style>

      <div id="tp1" style ="  font-size :14px; font-weight :bold ;">
          <asp:Repeater ID="Repeater1" runat="server" 
              onitemcommand="Repeater1_ItemCommand">
                 <ItemTemplate >
                   <div >
                   <ul >
                      <li>
                     <asp:ImageButton ID="ImageButton1" runat="server" Width="200px" Height="200px"  CommandName ="image" CommandArgument='<%# Eval("photoalbumID ") %>'
                     ImageUrl='<%# iamgeurl(Convert.ToInt32(Eval("photoalbumID"))) %>' /><br />
                     <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("photobumName ") %>'></asp:Label>
                      </li>
                   </ul>              
                     </div>
                 </ItemTemplate>
          </asp:Repeater>
      </div>
      <div  style ="  text-align :center ;" >
          <asp:ScriptManager ID="ScriptManager1" runat="server"> 
          </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
              <ContentTemplate >
                  <asp:Timer ID="Timer" runat="server" Interval="1000" Enabled="False" ontick="Timer_Tick">
                  </asp:Timer>
                  <asp:Image ID="Imagephoto" runat="server" Width ="500px" Height ="450px"/><br />
                  <asp:LinkButton ID="Lbtnprev" runat="server" Text ="上一张" 
                      onclick="Lbtnprev_Click"></asp:LinkButton>
                  &nbsp;<asp:LinkButton ID="lbtnautoplay" runat="server" Text ="自动播放" 
                      onclick="lbtnautoplay_Click"></asp:LinkButton>
                  &nbsp;<asp:LinkButton ID="Lbtnnextpage" runat="server" Text ="下一张" 
                      onclick="Lbtnnextpage_Click"></asp:LinkButton>    
              </ContentTemplate>
          </asp:UpdatePanel>
      </div>
</asp:Content>

