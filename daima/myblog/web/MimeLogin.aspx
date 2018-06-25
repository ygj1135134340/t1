<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MimeLogin.aspx.cs" Inherits="MimeLogin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">

<style type="text/css">
    
    la1 {
	font-family:幼圆;
	font-size:23px;
	position:absolute;
	color:White;
	left:250px;
	top:800px;
padding:0px,border-radius:20px,border:20px solid #96C2F1;
	width: 1212px;
}
 la2 {
	font-family:幼圆;
	font-size:23px;
	position:absolute;
	color:White;
	left:250px;
	top:850px;
padding:0px,border-radius:20px,border:20px solid #96C2F1;
	width: 1212px;
}
      #l{

	position:absolute;
	left:400px;
	top:800px;

}
   #l1{

	position:absolute;
	left:250px;
	top:950px;
	font-family:幼圆;
	font-size:23px;

}
   #l2{

	position:absolute;
	left:480px;
	top:950px;

}
</style>

   <la1>用 户 名：</la1>   
   <la2>密      码：</la2> 
    <div id="l"><asp:TextBox ID="txtname" runat="server" Width="212px" Height ="35px"   Font-Size="20"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtpassword" runat="server" Width="212px" Height ="35px" 
            Font-Size="20" TextMode="Password"></asp:TextBox>
    </div> 
    <div id="l1">
       <asp:Button ID="Button1" runat="server"   Width="120px" Height ="36px" text="登  录"  
            Style=" background-position:center; background-repeat :no-repeat" 
            onclick="Button1_Click" BackColor="Black" Font-Names="华文新魏" 
            Font-Size="Larger" ForeColor="White"   />        
    </div> 
    <div id="l2">
         <asp:Button ID="Button2" runat="server"   Width="120px" Height ="36px" text="注  册"
             Style=" background-position:center; background-repeat :no-repeat" 
             onclick="Button2_Click" BackColor="Black" Font-Names="华文新魏" 
             Font-Size="Larger" ForeColor="White"/>
    </div>

<%--background: url(image / btnlogin03.gif);--%>
</asp:Content>

